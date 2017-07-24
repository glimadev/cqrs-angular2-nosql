namespace cqrs_angular2_nosql.Domain.Core.Models
{
    public class EntityBase : IEntityBase
    {
        public string id { get; set; }
        public bool Actived { get; set; }
        public string DateCreated { get; set; }
        public string DateEdited { get; set; }
    }
}
