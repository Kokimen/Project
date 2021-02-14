using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //new() : new'lenebilir olmalı
    //IEntity: IEntity olabilir veya Ientity implemente eden bir nesne olabilir
    //generic constraint
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null); //T döndüren bir operasyon
        T Get(Expression<Func<T,bool>> filter); //bir kere yazılır bir daha yazmaya gerek kalmaz, hep kullanılır
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
     
    }
}
