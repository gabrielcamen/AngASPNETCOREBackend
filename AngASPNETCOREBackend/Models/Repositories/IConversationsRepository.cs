using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngASPNETCOREBackend.Models.Repositories
{
    public interface IConversationsRepository
    {
        Task SaveChanges();
        Task<IEnumerable<Conversations>> GetAllConversations();
        Task<int> GetNumberOfConversations();
        Task<Conversations> GetConversationById(int id);
        Task CreateConversation(Conversations conversation);
        Task UpdateConversation(Conversations conversation);
        Task DeleteConversation(Conversations conversation);
    }
}
