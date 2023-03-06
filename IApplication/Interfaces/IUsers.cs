using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IApplication.Interfaces
{
    public interface IUsers
    {

        Users LoginUser(string UserName, string Password);
        void ChangePassword(string UserName, string Password);
        void EditeUser(Users user);
        void CreateUser(string Melli, string Name, string Family, string Password);
        Users SelectUser(string Melli);
        IQueryable<Users> ListUsers();
    }
}
