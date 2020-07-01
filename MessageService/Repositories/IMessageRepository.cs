using MessageService.Contract;
using System.Linq;

namespace MessageService.Repositories
{
    public interface IMessageRepository
    {
        IQueryable<Message> GetAll();
        Message GetById(int id);
        void Save(Message message);
        void Delete(int id);
    }
}
