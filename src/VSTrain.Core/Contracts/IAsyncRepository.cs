using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VSTrain.Core.Contracts
{
    public interface IAsyncRepository<T> where T :class
    {
        Task<T> GetById(int Id);
        Task<IReadOnlyList<T>> GetAll();
    }

}