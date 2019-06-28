using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.NetCore
{
    public class CrudService<T> : ICrudService<T> where T : class
    {
        private readonly ISession _session;

        public CrudService(ISession session)
        {
            _session = session;
        }

        public virtual void Save(T entity)
        {
            _session.Save(entity);
        }

        public virtual void Save(IList<T> entity)
        {
            _session.Save(entity);
        }

        public virtual async Task SaveAsync(T entity)
        {
            await _session.SaveAsync(entity);
        }

        public virtual async Task SaveAsync(IList<T> entity)
        {
            await _session.SaveAsync(entity);
        }

        public virtual void SaveWithTransaction(T entity)
        {
            using (ITransaction transation = _session.BeginTransaction())
            {
                try
                {
                    _session.Save(entity);
                    _session.Flush();
                    transation.Commit();
                }
                catch
                {
                    transation.Rollback();
                    throw;
                }
            }
        }

        public virtual void SaveWithTransaction(IList<T> entities)
        {
            using (ITransaction transation = _session.BeginTransaction())
            {
                try
                {
                    _session.Save(entities);
                    _session.Flush();
                    transation.Commit();
                }
                catch
                {
                    transation.Rollback();
                    throw;
                }
            }
        }

        public virtual async Task SaveAsyncWithTransaction(T entity)
        {
            using (ITransaction transation = _session.BeginTransaction())
            {
                try
                {
                    await _session.SaveAsync(entity);
                    await _session.FlushAsync();
                    transation.Commit();
                }
                catch
                {
                    await transation.RollbackAsync();
                    throw;
                }
            }
        }

        public virtual async Task SaveAsyncWithTransaction(IList<T> entities)
        {
            using (ITransaction transation = _session.BeginTransaction())
            {
                try
                {
                    await _session.SaveAsync(entities);
                    await _session.FlushAsync();
                    await transation.CommitAsync();
                }
                catch
                {
                    await transation.RollbackAsync();
                    throw;
                }
            }
        }

        public virtual void SaveOrUpdateWithTransaction(IList<T> entity)
        {
            using (ITransaction transation = _session.BeginTransaction())
            {
                try
                {
                    _session.SaveOrUpdate(entity);
                    _session.Flush();
                    transation.Commit();
                }
                catch
                {
                    transation.Rollback();
                    throw;
                }
            }
        }

        public virtual void Update(T entity)
        {
            _session.Update(entity);
        }

        public virtual void Update(IList<T> entity)
        {
            _session.Update(entity);
        }

        public virtual void UpdateWithTransaction(T entity)
        {
            using (ITransaction transation = _session.BeginTransaction())
            {
                try
                {
                    _session.Update(entity);
                    _session.Flush();
                    transation.Commit();
                }
                catch
                {
                    transation.Rollback();
                    throw;
                }
            }
        }

        public virtual void UpdateWithTransaction(IList<T> entities)
        {
            using (ITransaction transation = _session.BeginTransaction())
            {
                try
                {
                    _session.Update(entities);
                    _session.Flush();
                    transation.Commit();
                }
                catch
                {
                    transation.Rollback();
                    throw;
                }
            }
        }

        public virtual async Task UpdateAsync(T entity)
        {
            using (ITransaction transation = _session.BeginTransaction())
            {
                try
                {
                    await _session.UpdateAsync(entity);
                    await _session.FlushAsync();
                    await transation.CommitAsync();
                }
                catch
                {
                    await transation.RollbackAsync();
                    throw;
                }
            }
        }

        public virtual async Task UpdateAsync(IList<T> entities)
        {
            using (ITransaction transation = _session.BeginTransaction())
            {
                try
                {
                    await _session.UpdateAsync(entities);
                    await _session.FlushAsync();
                    await transation.CommitAsync();
                }
                catch
                {
                    await transation.RollbackAsync();
                    throw;
                }
            }
        }

        public virtual void Delete(T entity)
        {
            _session.Delete(entity);
        }

        public virtual void Delete(IList<T> entities)
        {
            _session.Delete(entities);
        }


        public virtual async Task DeleteAsync(T entity)
        {
            await _session.DeleteAsync(entity);
        }

        public virtual async Task DeleteAsync(IList<T> entities)
        {
            await _session.DeleteAsync(entities);
        }

        public virtual void DeleteWithTransaction(T entity)
        {
            using (ITransaction transation = _session.BeginTransaction())
            {
                try
                {
                    _session.Delete(entity);
                    _session.Flush();
                    transation.Commit();
                }
                catch
                {
                    transation.Rollback();
                    throw;
                }
            }
        }

        public virtual void DeleteWithTransaction(IList<T> entities)
        {
            using (ITransaction transation = _session.BeginTransaction())
            {
                try
                {
                    _session.Delete(entities);
                    _session.Flush();
                    transation.Commit();
                }
                catch
                {
                    transation.Rollback();
                    throw;
                }
            }
        }

        public virtual async Task DeleteAsyncWithTransaction(T entity)
        {
            using (ITransaction transation = _session.BeginTransaction())
            {
                try
                {
                    await _session.DeleteAsync(entity);
                    await _session.FlushAsync();
                    await transation.CommitAsync();
                }
                catch
                {
                    await transation.RollbackAsync();
                    throw;
                }
            }
        }

        public virtual async Task DeleteAsyncWithTransaction(IList<T> entities)
        {
            using (ITransaction transation = _session.BeginTransaction())
            {
                try
                {
                    await _session.DeleteAsync(entities);
                    await _session.FlushAsync();
                    await transation.CommitAsync();
                }
                catch
                {
                    await transation.RollbackAsync();
                    throw;
                }
            }
        }

        public virtual IQueryable<T> Find()
        {
            return _session.Query<T>();
        }

        public virtual IList<T> Find(Func<T, bool> func)
        {
            return _session.Query<T>().Where(func).ToList();
        }

        public virtual IList<T> FindBy(IDictionary<string, object> parameters, bool cacheable = false)
        {
            IQuery query = _session.CreateQuery($"from {nameof(T)}");

            foreach (KeyValuePair<string, object> parameter in parameters)
            {
                query.SetParameter(parameter.Key, parameter.Value);
            }

            query.SetCacheable(cacheable);
            return query.List<T>();
        }

        public virtual T FindUniqueBy(IDictionary<string, object> parameters, bool cacheable = false)
        {
            IQuery query = _session.CreateQuery($"from {nameof(T)}");

            foreach (KeyValuePair<string, object> parameter in parameters)
            {
                query.SetParameter(parameter.Key, parameter.Value);
            }

            query.SetCacheable(cacheable);
            return query.UniqueResult<T>();
        }

        public virtual async Task<T> FindUniqueResultByAsync(IDictionary<string, object> parameters, bool cacheable = false)
        {
            IQuery query = _session.CreateQuery($"from {nameof(T)}");

            foreach (KeyValuePair<string, object> parameter in parameters)
            {
                query.SetParameter(parameter.Key, parameter.Value);
            }

            query.SetCacheable(cacheable);
            return await query.UniqueResultAsync<T>();
        }

        public virtual async Task<IList<T>> FindByAsync(IDictionary<string, object> parameters, bool cacheable = false)
        {
            IQuery query = _session.CreateQuery($"from {nameof(T)}");

            foreach (KeyValuePair<string, object> parameter in parameters)
            {
                query.SetParameter(parameter.Key, parameter.Value);
            }

            query.SetCacheable(cacheable);
            return await query.ListAsync<T>();
        }

        public virtual IList<T> FindBy(string parameter, object value, bool cacheable = false)
        {
            IQuery query = _session.CreateQuery($"from {nameof(T)}");
            query.SetParameter(parameter, value);
            query.SetCacheable(cacheable);
            return query.List<T>();
        }

        public virtual T FindUniqueBy(string parameter, object value, bool cacheable = false)
        {
            IQuery query = _session.CreateQuery($"from {nameof(T)}");
            query.SetParameter(parameter, value);
            query.SetCacheable(cacheable);
            return query.UniqueResult<T>();
        }

        public virtual async Task<IList<T>> FindByAsync(string parameter, object value, bool cacheable = false)
        {
            IQuery query = _session.CreateQuery($"from {nameof(T)}");
            query.SetParameter(parameter, value);
            query.SetCacheable(cacheable);
            return await query.ListAsync<T>();
        }

        public virtual IList<T> Find(string queryString, bool cacheable = false)
        {
            IQuery query = _session.CreateQuery(queryString);
            query.SetCacheable(cacheable);
            return query.List<T>();
        }

        public virtual T FindUnique(string queryString, bool cacheable = false)
        {
            IQuery query = _session.CreateQuery(queryString);
            query.SetCacheable(cacheable);
            return query.UniqueResult<T>();
        }

        public virtual async Task<IList<T>> FindAsync(string queryString, bool cacheable = false)
        {
            IQuery query = _session.CreateQuery(queryString);
            query.SetCacheable(cacheable);
            return await query.ListAsync<T>();
        }

        public virtual async Task<T> FindUniqueAsync(string queryString, bool cacheable = false)
        {
            IQuery query = _session.CreateQuery(queryString);
            query.SetCacheable(cacheable);
            return await query.UniqueResultAsync<T>();
        }

        public virtual IList<T> Find(bool cacheable = false)
        {
            IQuery query = _session.CreateQuery($"from {nameof(T)}");
            query.SetCacheable(cacheable);
            return query.List<T>();
        }

        public virtual T FindUnique(bool cacheable = false)
        {
            IQuery query = _session.CreateQuery($"from {nameof(T)}");
            query.SetCacheable(cacheable);
            return query.UniqueResult<T>();
        }

        public virtual async Task<IList<T>> FindAsync(bool cacheable = false)
        {
            IQuery query = _session.CreateQuery($"from {nameof(T)}");
            query.SetCacheable(cacheable);
            return await query.ListAsync<T>();
        }

        public virtual async Task<T> FindUniqueAsync(bool cacheable = false)
        {
            IQuery query = _session.CreateQuery($"from {nameof(T)}");
            query.SetCacheable(cacheable);
            return await query.UniqueResultAsync<T>();
        }

        public virtual IList<T> FindById(IList<object> ids)
        {
            return _session.Get<IList<T>>(ids);
        }

        public virtual async Task<T> FindByIdAsync(object id)
        {
            return await _session.GetAsync<T>(id);
        }

        public virtual async Task<IList<T>> FindByIdAsync(IList<object> ids)
        {
            return await _session.GetAsync<IList<T>>(ids);
        }

        #region IDisposable Support

        private bool disposedValue = false; // Para detectar chamadas redundantes

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _session.Dispose();
                }
                disposedValue = true;
            }
        }

        ~CrudService()
        {
            // Não altere este código. Coloque o código de limpeza em Dispose(bool disposing) acima.
            Dispose(false);
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
