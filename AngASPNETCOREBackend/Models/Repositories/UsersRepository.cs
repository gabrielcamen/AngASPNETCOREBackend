using AngASPNETCOREBackend.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngASPNETCOREBackend.Models.Repositories
{
    public class UsersRepository : IUsersRepositoryInterface
    {

        private AppDbContext _appDbContext;
        private List<Users> _users = new List<Users>();
        public UsersRepository(AppDbContext AppDbContext)
        {
            _appDbContext = AppDbContext;
            LoadEntries();
        }

        void LoadEntries()
        {
            _users = _appDbContext.Users.ToList();
        }
        public IEnumerable<Users> GetAllUsers
        {
            get
            {
                return _users;
            }
        }

        public int GetNumberOfUsers
        {
            get
            {
                return _users.Count;
            }
        }
    }
}
