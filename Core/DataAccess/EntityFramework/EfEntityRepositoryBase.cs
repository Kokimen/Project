using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    //Burada her şey için bir altyapı oluşturuyoruz
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity: class, IEntity, new()
        where TContext: DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //IDisposable pattern implementation of c#
            using (TContext context = new TContext()) //bunu yazarsan sistem daha performanslı çalışır
            {
                var addedEntity = context.Entry(entity); //database ile ilişkilendir
                addedEntity.State = EntityState.Added; //ekleme olarak set et
                context.SaveChanges(); //ve şimdi ekleyip kaydet
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext()) //bunu yazarsan sistem daha performanslı çalışır
            {
                var deletedEntity = context.Entry(entity); //database ile ilişkilendir
                deletedEntity.State = EntityState.Deleted; //silme olarak set et
                context.SaveChanges(); //ve şimdi silip kaydet
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext()) //bunu yazarsan sistem daha performanslı çalışır
            {
                var updatedEntity = context.Entry(entity); //database ile ilişkilendir
                updatedEntity.State = EntityState.Modified; //güncelleme olarak set et
                context.SaveChanges(); //ve şimdi güncelleyip kaydet
            }
        }
    }
}
