using System.Threading.Tasks;

namespace cqrs_angular2_nosql.Domain.Core.Events
{
    public interface IHandler<in T> where T : Message
    {
        Task Handle(T message);
    }
}
