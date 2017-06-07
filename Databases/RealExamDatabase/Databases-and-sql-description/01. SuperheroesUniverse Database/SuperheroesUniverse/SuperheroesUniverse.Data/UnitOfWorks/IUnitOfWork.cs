using SocialNetwork.Data.Repositories;

namespace SocialNetwork.Data.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GetRepository<T>() where T : class;

        int SaveChanges();
    }
}