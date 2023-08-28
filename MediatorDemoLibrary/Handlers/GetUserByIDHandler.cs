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
    public class GetUserByIDHandler : IRequestHandler<GetUserByIDQuery, UserModel>
    {
        private readonly IMediator _mediator;

        public GetUserByIDHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<UserModel> Handle(GetUserByIDQuery request, CancellationToken cancellationToken)
        {
            var R = await _mediator.Send(new GetUsersListQuery());
            var OutPut=R.FirstOrDefault(x=>x.Id==request.ID);
            return OutPut;
        }
    }
}
