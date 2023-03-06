using Domain;
using IApplication.Interfaces;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IApplication.Services.UsersServices
{
    public class UsersClass : IUsers
    {
        private readonly IDataBaseContext _context;
        public UsersClass(IDataBaseContext context)
        {
            _context = context;
        }
        public void ChangePassword(string UserName, string Password)
        {
            Users users = _context.Users.Where(c => c.UserName == UserName).SingleOrDefault();
            if (users != null)
            {
                users.Password = Hashing.Encrypt(Password, true);
                _context.Users.Update(users);
                _context.SaveChanges();
            }
        }

        public void CreateUser(string Melli, string Name, string Family, string Password)
        {
            Users users = _context.Users.Where(c => c.UserName == Melli).SingleOrDefault();

            if (users == null)
            {
                users = new Users();
                users.Family = Family;
                users.UserName = Melli;
                users.Level = "0";
                users.Active = true;
                users.Name = Name;
                users.Id = Guid.NewGuid().ToString();
                users.Password = Hashing.Encrypt(Password, true);
                _context.Users.Add(users);

            }
            else
            {
                users.Family = Family;
                users.UserName = Melli;
                users.Name = Name;
                users.Password = Hashing.Encrypt(Password, true);
                _context.Users.Update(users);
            }
            _context.SaveChanges();

        }

        public void EditeUser(Users user)
        {
            var u = _context.Users.Where(c => c.Id == user.Id).SingleOrDefault();
            if (u != null)
            {
                u.Active = user.Active;
                u.Family = user.Family;
                u.Level = user.Level;
                u.Name = user.Name;
                _context.SaveChanges();
            }

        }

        public IQueryable<Users> ListUsers()
        {
            return _context.Users;
        }

        public Users LoginUser(string UserName, string Password)
        {
            //{ var b = Hashing.Encrypt(Password, true);
            //    var bbb = _context.Users.Where(c => c.UserName == UserName);
            Users u = _context.Users.Where(c => c.UserName == UserName && c.Password == Hashing.Encrypt(Password, true)).FirstOrDefault();
            return u;
        }

        public Users SelectUser(string Melli)
        {
            return _context.Users.Where(c => c.UserName == Melli).SingleOrDefault();
        }
    }
}
