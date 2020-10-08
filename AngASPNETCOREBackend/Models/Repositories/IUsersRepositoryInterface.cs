using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngASPNETCOREBackend.Models.Repositories
{
    public interface IUsersRepositoryInterface
    {
        Task SaveChanges();
        Task<IEnumerable<Users>> GetAllUsers();
        int GetNumberOfUsers();
        Task<Users> GetUserById(int id);
        Task CreateUser(Users user);
        Task UpdateUser(Users user);
        Task DeleteUser(Users user);

    }
}
