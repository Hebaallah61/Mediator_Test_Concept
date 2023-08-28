using MediatorDemoLibrary.Commands;
using MediatorDemoLibrary.DataAccess;
using MediatorDemoLibrary.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDemoLibrary.Handlers
{
    public class InsertUserHandler : IRequestHandler<InsertUserCommand, UserModel>
    {
        
        private readonly IDataAccess _data;

        public InsertUserHandler(IDataAccess data)
        {
            _data = data;
            
        }
        public  Task<UserModel> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_data.AddUser(request.name, request.email));
        }
    }
}
