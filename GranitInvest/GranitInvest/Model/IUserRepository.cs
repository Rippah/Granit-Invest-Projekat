using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GranitInvest.Model
{
    internal interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credential);
        void Add(User userModel);
        void Edit(User userModel);
        void Remove(int id);
        User GetById(int id);
        User GetByUsername(string username);
        IEnumerable<User> GetByAll();
    }
}
