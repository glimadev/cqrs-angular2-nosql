using System;

namespace cqrs_angular2_nosql.VM.In
{
    public class ClientUpdateInVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
