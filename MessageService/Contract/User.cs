using System.Collections.Generic;

namespace MessageService.Contract
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
