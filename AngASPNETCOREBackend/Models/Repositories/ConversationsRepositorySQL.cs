using AngASPNETCOREBackend.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngASPNETCOREBackend.Models.Repositories
{
    public class ConversationsRepositorySQL : IConversationsRepository
    {

        private readonly AppDbContext _context;
        public ConversationsRepositorySQL(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }


        public async Task CreateConversation(Conversations conversation)
        {
            _context.Add(conversation);
            await SaveChanges();
        }

        public async Task DeleteConversation(Conversations conversation)
        {
            _context.Remove(conversation);
            await SaveChanges();
        }

        public async Task<IEnumerable<Conversations>> GetAllConversations()
        {
            return await _context.Conversations.ToListAsync();
        }

        public async Task<Conversations> GetConversationById(int id)
        {
            return await _context.Conversations.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<int> GetNumberOfConversations()
        {
            return await _context.Conversations.CountAsync();
           
        }

        public async Task UpdateConversation(Conversations conversation)
        {
            _context.Update(conversation);
            await SaveChanges();
        }
    }
}
