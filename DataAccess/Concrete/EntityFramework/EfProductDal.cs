using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        //NuGet
        public void Add(Product entity)
        {
            //IDisposable pattern implementation of c#
            using (NorthwindContext context = new NorthwindContext()) //bunu yazarsan sistem daha performanslı çalışır
            {
                var addedEntity = context.Entry(entity); //database ile ilişkilendir
                addedEntity.State = EntityState.Added; //ekleme olarak set et
                context.SaveChanges(); //ve şimdi ekleyip kaydet
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext()) //bunu yazarsan sistem daha performanslı çalışır
            {
                var deletedEntity = context.Entry(entity); //database ile ilişkilendir
                deletedEntity.State = EntityState.Deleted; //silme olarak set et
                context.SaveChanges(); //ve şimdi silip kaydet
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null 
                    ? context.Set<Product>().ToList() 
                    : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext()) //bunu yazarsan sistem daha performanslı çalışır
            {
                var updatedEntity = context.Entry(entity); //database ile ilişkilendir
                updatedEntity.State = EntityState.Modified; //güncelleme olarak set et
                context.SaveChanges(); //ve şimdi güncelleyip kaydet
            }
        }
    }
}
