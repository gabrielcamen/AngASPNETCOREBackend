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
        public async Task<IEnumerable<Users>> GetAllUsers()
        { 
            return await _appDbContext.Users.ToListAsync();
        }

        public int GetNumberOfUsers()
        {
                return _users.Count;   
        }

        public async Task<Users> GetUserById(int id)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task SaveChanges()
        {
           await _appDbContext.SaveChangesAsync();
        }

        public async Task CreateUser(Users user)
        {
            if (user == null)
            {
                throw new  ArgumentNullException(nameof(user));
            }    
            else
            {
                _appDbContext.Add(user);
                await SaveChanges();
                LoadEntries();
            }
        }

        public async Task UpdateUser(Users user)
        {
            _appDbContext.Update(user);
            await SaveChanges();
        }

        public async Task DeleteUser(Users user)
        {
            _appDbContext.Remove(user);
            await SaveChanges();
            LoadEntries();
        }
    }
}
