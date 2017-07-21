using System;

namespace cqrs_angular2_nosql.Infra.Data.Repository.Interfaces
{
    //Add Metodos na interface
    public interface IRepository<T> : IDisposable where T : class
    {
    }
}
