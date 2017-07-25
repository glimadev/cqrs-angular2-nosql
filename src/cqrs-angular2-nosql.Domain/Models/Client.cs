using cqrs_angular2_nosql.Domain.Core.Models;

namespace cqrs_angular2_nosql.Domain.Models
{
    public class Client : EntityBase
    {
        public Client(string xid, string name, string email)
        {
            id = xid;
            Name = name;
            Email = email;
        }

        protected Client() { }

        public string Name { get; private set; }
        public string Email { get; private set; }
    }
}
