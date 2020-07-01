using MessageService.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public IQueryable<Message> GetAll()
        {
            return _context.Set<Message>().AsNoTracking();
        }

        public Message GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
