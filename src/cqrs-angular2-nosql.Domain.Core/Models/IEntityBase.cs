namespace cqrs_angular2_nosql.Domain.Core.Models
{
    public interface IEntityBase
    {
        string id { get; set; }
        bool Actived { get; set; }
        string DateCreated { get; set; }
        string DateEdited { get; set; }
    }
}
