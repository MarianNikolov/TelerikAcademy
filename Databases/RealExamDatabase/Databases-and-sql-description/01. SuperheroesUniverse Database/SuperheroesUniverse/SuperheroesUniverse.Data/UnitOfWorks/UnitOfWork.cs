using System;
using System.Collections.Generic;
using System.Data.Entity;
using SocialNetwork.Data.Repositories;

namespace SocialNetwork.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;
        private readonly IDictionary<Type, object> respositories;

        public UnitOfWork(DbContext socialContext)
        {
            this.context = socialContext;
            this.respositories = new Dictionary<Type, object>();
        }
        
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            if (!this.respositories.ContainsKey(typeof(T)))
            {
                Type type = typeof(GenericRepository<T>);

                this.respositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.respositories[typeof(T)];
        }
    }
}
