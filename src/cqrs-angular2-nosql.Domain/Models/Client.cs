using cqrs_angular2_nosql.Domain.Core.Models;

namespace cqrs_angular2_nosql.Domain.Models
{
    public class Client : EntityBase
    {
        public Client(string xid, string name, string email, string code, string document, string phone)
        {
            id = xid;
            Name = name;
            Email = email;
            Code = code;
            Document = document;
            Phone = phone;
        }

        protected Client() { }

        public string Code { get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Document { get; private set; }

        public string Phone { get; private set; }
    }
}
