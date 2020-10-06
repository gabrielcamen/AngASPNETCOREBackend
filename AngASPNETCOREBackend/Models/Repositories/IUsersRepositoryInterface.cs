using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngASPNETCOREBackend.Models.Repositories
{
    public interface IUsersRepositoryInterface
    {
        IEnumerable<Users> GetAllUsers { get; }
        int GetNumberOfUsers { get; }
    }
}
