using MediatorDemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDemoLibrary.DataAccess
{
    public class DemoDataAccess : IDataAccess
    {
        private List<UserModel> users = new();
        public DemoDataAccess()
        {
            users.Add(new UserModel() { Id = 1, Name = "Ali", Email = "Ali@g.com" });
            users.Add(new UserModel() { Id = 2, Name = "Mohammed", Email = "Mohammed@g.com" });
            users.Add(new UserModel() { Id = 3, Name = "Nor", Email = "Nor@g.com" });
        }

        public List<UserModel> Users()
        {
            return users;
        }

        public UserModel AddUser(string username, string email)
        {
            UserModel user = new() { Name = username, Email = email };
            user.Id = users.Max(id => id.Id) + 1;
            users.Add(user);
            return user;
        }
    }
}
