using System.Collections.Generic;
using Models;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetUsers();

        void AddUser(User user);

        User FindUserByEmail(string email);
    }
}