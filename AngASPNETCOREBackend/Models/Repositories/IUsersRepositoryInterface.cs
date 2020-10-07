using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngASPNETCOREBackend.Models.Repositories
{
    public interface IUsersRepositoryInterface
    {
        bool SaveChanges();
        IEnumerable<Users> GetAllUsers { get; }
        int GetNumberOfUsers { get; }
        Users GetUserById(int id);
        void CreateUser(Users user);
        void UpdateUser(Users user);
        void DeleteUser(Users user);

    }
}
