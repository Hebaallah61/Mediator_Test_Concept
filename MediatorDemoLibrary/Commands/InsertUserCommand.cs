using MediatorDemoLibrary.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDemoLibrary.Commands
{
    public record InsertUserCommand(string name,string email):IRequest<UserModel>;
}
