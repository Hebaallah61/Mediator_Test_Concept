using MediatorDemoLibrary.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDemoLibrary.Queries
{
    public record GetUsersListQuery():IRequest<List<UserModel>>;
}
