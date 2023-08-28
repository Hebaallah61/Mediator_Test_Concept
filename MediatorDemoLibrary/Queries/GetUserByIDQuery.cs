using MediatorDemoLibrary.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDemoLibrary.Queries
{
    public record GetUserByIDQuery(int ID):IRequest<UserModel>;
}

/* if we use classes nor records 
public class GetUserByIDQuery(int ID) : IRequest<UserModel>
{
    public int ID { get; set; }
    public GetUserByIDQuery(int id)
    {
        ID = id;
    }
}
*/