using System.Linq;

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
            _customersContext.Set<T>().Add(entity);
            _customersContext.SaveChanges();

            return entity;
        }

        public void Update(T entity)
        {
            _customersContext.Set<T>().Update(entity);
            _customersContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _customersContext.Set<T>().Remove(entity);
            _customersContext.SaveChanges();
        }
    }
}
