using cqrs_angular2_nosql.Domain.Core.Models;
using System;

namespace cqrs_angular2_nosql.Domain.Models
{
    public class Client : EntityBase
    {
        public Client(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public Client(Guid gid, string name, string email)
        {
            id = gid.ToString();
            Name = name;
            Email = email;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
    }
}
