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
        public UsersRepository(AppDbContext AppDbContext)
        {
            _appDbContext = AppDbContext;

        }

      
        public async Task<IEnumerable<Users>> GetAllUsers()
        { 
            return await _appDbContext.Users.ToListAsync();
        }

        public async Task<int> GetNumberOfUsers()
        {
            return await Task.Run(()=>
                 GetAllUsers().Result.Count() 
                );
               
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
          
        }
    }
}
