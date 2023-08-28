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
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, List<UserModel>>
    {
        private readonly IMediator _mediator;
        private readonly IDataAccess _data;
        public DeleteUserHandler(IMediator mediator, IDataAccess data)
        {
            _mediator = mediator;
            _data = data;
        }
        public async Task<List<UserModel>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var R = await _mediator.Send(new GetUsersListQuery());
            var OutPut = R.FirstOrDefault(x => x.Id == request.id);
            if(OutPut != null)
            {
                _data.Users().Remove(OutPut);
            }
            return await _mediator.Send(new GetUsersListQuery());
        }
    }
}
