using MediatorDemoLibrary.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDemoLibrary.Commands
{
    public record UpdateUserCommand(int id,string name,string email):IRequest<UserModel>;
    
}
