using cqrs_angular2_nosql.Infra.Data.Repository.Interfaces;

namespace cqrs_angular2_nosql.Infra.Data.Repository
{
    public class EntityBase : IEntityBase
    {
        public string Id { get; set; }
        public bool Actived { get; set; }
        public string DateCreated { get; set; }
        public string DateEdited { get; set; }
    }
}
