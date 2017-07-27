namespace cqrs_angular2_nosql.Domain.Core.Models
{
    /// <summary>
    /// Entidade base para que todos as models das collection tenham estes atributos
    /// </summary>
    public class EntityBase : IEntityBase
    {
        public string id { get; set; }
        public bool Actived { get; set; }
        public string DateCreated { get; set; }
        public string DateEdited { get; set; }
    }
}
