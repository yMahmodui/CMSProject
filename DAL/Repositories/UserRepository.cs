using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using Models;

namespace DAL.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly DatabaseContext DatabaseContext;


        public UserRepository(DatabaseContext context)
        {
            DatabaseContext = context;
        }

        public List<User> GetUsers()
        {
            return DatabaseContext.Users.ToList();
        }

        public void AddUser(User user)
        {
            DatabaseContext.Users.Add(user);
        }

        public User FindUserByEmail(string email)
        {
            return DatabaseContext.Users.FirstOrDefault(user => user.Email == email);
        }
    }
}