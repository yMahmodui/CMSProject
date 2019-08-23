using DAL.Interfaces;
using Models;

namespace DAL.Repositories
{
    internal class UserRepository : IUserRepository
    {
        public UserRepository(DatabaseContext context)
        {
            DatabaseContext = context;
        }

        protected DatabaseContext DatabaseContext { get; set; }

        public void AddUser(User user)
        {
            DatabaseContext.Users.Add(user);
        }
    }
}