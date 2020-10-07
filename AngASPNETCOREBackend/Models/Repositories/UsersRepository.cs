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

        public Users GetUserById(int id)
        {
            return _appDbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public bool SaveChanges()
        {
           return (_appDbContext.SaveChanges() >= 0);
        }

        public void CreateUser(Users user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }    
            else
            {
                _appDbContext.Add(user);
                SaveChanges();
                LoadEntries();
            }
        }

        public void UpdateUser(Users user)
        {
            _appDbContext.Update(user);
            SaveChanges();
        }

        public void DeleteUser(Users user)
        {

            _appDbContext.Remove(user);
            SaveChanges();
            LoadEntries();
        }
    }
}
