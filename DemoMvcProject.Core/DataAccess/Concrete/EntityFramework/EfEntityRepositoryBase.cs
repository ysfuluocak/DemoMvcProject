﻿using DemoMvcProject.Core.DataAccess.Abstract;
using DemoMvcProject.Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace DemoMvcProject.Core.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext> : IEntityRepositoryBase<TEntity>
        where TEntity : BaseEntity, new()
        where TContext : DbContext, new()
    {

        public int Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                return entity.Id;
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);

            }
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();

            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
        
    }
}
