using MediatorDemoLibrary.DataAccess;
using MediatorDemoLibrary.Models;
using MediatorDemoLibrary.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorDemoLibrary.Handlers
{
    public class GetUsersListHandler : IRequestHandler<GetUsersListQuery, List<UserModel>>
    {
        //MediatR Improve DInjection Not replace it
        private readonly IDataAccess data;

        public GetUsersListHandler(IDataAccess data)
        {
            this.data = data;
        }
        public Task<List<UserModel>> Handle(GetUsersListQuery request, CancellationToken cancellationToken) // CancellationToken we can pass it optionally?
        {
            
            return Task.FromResult(data.Users());
        }
    }
}
