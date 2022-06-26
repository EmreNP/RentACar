using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EFEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext: DbContext , new()
    {
        public void Add(TEntity entity)
        {
            using(TContext context = new TContext())
            {
                context.Set<TEntity>().AddAsync(entity);
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
                using (TContext context = new TContext())
                {
                context.Set<TEntity>().Remove(entity);
                    context.SaveChanges();
                }
            
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using(var context = new TContext())
            {
                return context.Set<TEntity>().Single(filter);
            }
        }

        public  List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using(var context =new TContext())
            {
                return filter == null ?  context.Set<TEntity>().ToList() :  context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void update(TEntity entity)
        {
           using (var context = new TContext())
            {
                context.Set<TEntity>().Update(entity);
                context.SaveChanges();
            }
        }
    }
}
