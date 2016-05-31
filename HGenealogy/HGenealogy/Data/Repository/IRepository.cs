using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using HGenealogy.Data.DbContextFactory;

namespace HGenealogy.Data.Repository
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        void Create(TEntity instance);

        void Update(TEntity instance);

        void Delete(TEntity instance);

        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        //TEntity Get(int primaryID);

        IQueryable<TEntity> GetAll();

        void SaveChanges();
    }
}