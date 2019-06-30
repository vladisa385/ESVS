using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESVS.Application.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> Get(Guid id);
        Task <IEnumerable<T>> GetAll();
        Task Add(T item);
        Task Update(T item);
        Task Delete(Guid id);
    }
}