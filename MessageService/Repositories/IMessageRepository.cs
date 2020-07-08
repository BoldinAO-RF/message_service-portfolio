using MessageService.Contract;
using System.Linq;

namespace MessageService.Repositories
{
    public interface IMessageRepository
    {
        IQueryable<object> GetAll();
        void Save(MessageViewModel message);
        void Delete(int id);
        Message Edit(int id, MessageViewModel message);
    }
}
