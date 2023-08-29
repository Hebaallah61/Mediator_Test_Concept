using FluentValidation;
using MediatorDemoLibrary.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDemoLibrary.Validation
{
    public class InsertUserCommandValidator: AbstractValidator<InsertUserCommand>
    {
        public InsertUserCommandValidator()
        {
            RuleFor(x=>x.name).NotEmpty().NotNull();
            RuleFor(x=>x.email).NotEmpty().NotNull();
            //after that we regist validator in program file but we already but the project as class library 
            Debug.WriteLine("InsertUserCommandValidator invoked");


        }
    }
}
