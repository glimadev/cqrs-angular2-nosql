using System;

namespace cqrs_angular2_nosql.Domain.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
    }
}
