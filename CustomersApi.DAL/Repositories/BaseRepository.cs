using System;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CustomersApi.DAL.Repositories
{
    public abstract class BaseRepository<T> where T: class
    {
        protected readonly CustomersContext _customersContext;

        public BaseRepository(CustomersContext customersContext)
        {
            _customersContext = customersContext;
        }

        public T GetSingle(params object[] index)
        {
            return _customersContext.Find<T>(index);
        }

        public IQueryable<T> GetAll()
        {
            return _customersContext.Set<T>();
        }

        public T Add(T entity)
        {
            try
            {
                _customersContext.Set<T>().Add(entity);
                _customersContext.SaveChanges();

                return entity;
            }
            catch (DbUpdateException e)
            {
                SqlException innerException = e.InnerException as SqlException;
                if (innerException != null && innerException.Number == Consts.Consts.DbDuplicateKeyExceptionCode)
                {
                    throw new ArgumentException("Entity already exists.");
                }
                else
                {
                    throw;
                }
            }
        }

        public void Update(T entity)
        {
            try
            {
                _customersContext.Set<T>().Update(entity);
                _customersContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                SqlException innerException = e.InnerException as SqlException;
                if (innerException != null && innerException.Number == 123)
                {
                    throw new ArgumentException("Entity already exists.");
                }
                else
                {
                    throw;
                }
            }
        }

        public void Delete(T entity)
        {
            _customersContext.Set<T>().Remove(entity);
            _customersContext.SaveChanges();
        }
    }
}
