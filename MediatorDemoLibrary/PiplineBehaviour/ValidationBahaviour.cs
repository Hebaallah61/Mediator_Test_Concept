using FluentValidation;
using MediatorDemoLibrary.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDemoLibrary.PiplineBehaviour
{
    public class ValidationBahaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBahaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }


        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            Debug.WriteLine("ValidationBehaviour invoked");

            //we will use pre and next only here
            //pre
            var context = new ValidationContext(request);
            // var failures = _validators.Select(x => x.Validate(context)).SelectMany(x => x.Errors).Where(x => x != null).ToList();
            var failures = _validators.Select(v => v.Validate(new ValidationContext<TRequest>(request)))
                                .SelectMany(result => result.Errors)
                                .Where(error => error != null)
                                .ToList();
            if (failures.Any())
            {

                var errorResponse = new ErrorResponse(Message: "Validation failed.", Errors: failures.Select(failure => failure.ErrorMessage).ToList());
               

                throw new FluentValidation.ValidationException(errorResponse.Message, failures);
               
            }

            return await next();
            //post
        }
    }
}
