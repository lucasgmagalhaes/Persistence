using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence
{
    public interface ICrudService<T> : IDisposable
    {
        void Save(T entity);
        void Save(IList<T> entity);
        Task SaveAsync(T entity);
        Task SaveAsync(IList<T> entity);
        void SaveWithTransaction(T entity);
        void SaveWithTransaction(IList<T> entities);
        Task SaveAsyncWithTransaction(T entity);
        Task SaveAsyncWithTransaction(IList<T> entities);
        void SaveOrUpdateWithTransaction(IList<T> entity);
        void Update(T entity);
        void Update(IList<T> entity);
        void UpdateWithTransaction(T entity);
        void UpdateWithTransaction(IList<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateAsync(IList<T> entities);
        void Delete(T entity);
        void Delete(IList<T> entities);
        Task DeleteAsync(T entity);
        Task DeleteAsync(IList<T> entities);
        void DeleteWithTransaction(T entity);
        void DeleteWithTransaction(IList<T> entities);
        Task DeleteAsyncWithTransaction(T entity);
        Task DeleteAsyncWithTransaction(IList<T> entities);
        IList<T> FindById(IList<object> ids);
        Task<T> FindByIdAsync(object id);
        Task<IList<T>> FindByIdAsync(IList<object> ids);
    }
}
