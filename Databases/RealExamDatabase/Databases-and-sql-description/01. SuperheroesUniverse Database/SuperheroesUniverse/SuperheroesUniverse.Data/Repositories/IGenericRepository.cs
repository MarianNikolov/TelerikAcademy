using System.Linq;

namespace SocialNetwork.Data.Repositories
{
    public interface IGenericRepository<T> 
        where T : class
    {
        //void Dispose();

        IQueryable<T> All();

        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(object id);

        T Attach(T entity);

        void Detach(T entity);

        int SaveChanges();
    }
}
