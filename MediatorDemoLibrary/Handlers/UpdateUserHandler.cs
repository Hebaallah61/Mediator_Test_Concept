using MediatorDemoLibrary.Commands;
using MediatorDemoLibrary.DataAccess;
using MediatorDemoLibrary.Models;
using MediatorDemoLibrary.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDemoLibrary.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserModel>
    {
        private readonly IMediator _mediator;

        public UpdateUserHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<UserModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var R = await _mediator.Send(new GetUsersListQuery());
            var OutPut = R.FirstOrDefault(x => x.Id == request.id);
            if (OutPut != null)
            {
                OutPut.Email = request.email;
                OutPut.Name = request.name;
            }
            return OutPut;
        }
    }
}
