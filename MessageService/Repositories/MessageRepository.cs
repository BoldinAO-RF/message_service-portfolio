using MessageService.Contract;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MessageService.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private DbContext _context;

        public MessageRepository(DbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            _context.Set<Message>().Remove(GetMessageById(id));
            _context.SaveChanges();
        }

        private Message GetMessageById(int id)
        {
            return _context.Set<Message>().AsNoTracking().Single(m => m.Id == id);
        }

        public Message Edit(int id, MessageViewModel message)
        {
            var m = new Message()
            {
                Id = id,
                MessageText = message.MessageText,
                UserId = message.UserId
            };

            _context.Entry(m).State = EntityState.Modified;
            _context.SaveChanges();

            return m;
        }

        public IQueryable<object> GetAll()
        {
            return from message in _context.Set<Message>().AsNoTracking()
                   join u in _context.Set<User>().AsNoTracking() on message.UserId equals u.Id
                   select new
                   {
                       MessageText = message.MessageText,
                       UserFullName = u.FullName
                   };
        }

        public void Save(MessageViewModel message)
        {
            _context.Set<Message>().Add(new Message() { 
                MessageText = message.MessageText,
                UserId = message.UserId
            });
            _context.SaveChanges();
        }
    }
}
