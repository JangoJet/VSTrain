using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VSTrain.Core.Entities;

namespace VSTrain.Core.Contracts
{
    public interface IAsyncRepository<T> where T :class
    {
        Task<T> GetByIdAsync(int Id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task UpdateAsync(T entity);
        Task<T> AddAsync(T entity);
        Task DeleteAsync(T entity);
    }

}