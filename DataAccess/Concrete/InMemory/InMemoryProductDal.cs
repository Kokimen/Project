using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; //alt çizgi global liste anlamına gelir
        public InMemoryProductDal()
        {
           //Oracle, Sql Server, MongoDb'den bir veri geliyormuş gibi simülasyon
            _products = new List<Product> 
            {
                new Product{ProductID=1, CategoryId=1, ProductName="Bardak", UnitPrice=15,UnitsInStock=15},
                new Product{ProductID=1, CategoryId=1, ProductName="Kamera", UnitPrice=500,UnitsInStock=3},
                new Product{ProductID=1, CategoryId=2, ProductName="Telefon", UnitPrice=1500,UnitsInStock=2},
                new Product{ProductID=1, CategoryId=2, ProductName="Klavye", UnitPrice=150,UnitsInStock=65},
                new Product{ProductID=1, CategoryId=2, ProductName="Fare", UnitPrice=85,UnitsInStock=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }
        //LINQ - Language Integrated Query , gömülmüş dil
        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductID==product.ProductID); //=> bu işarete lambda denir, foreach görevi görür
            //SingleOrDefault kodu tek tek foreach varmışçasına listeyi dolaşır
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p=> p.CategoryId == categoryId).ToList(); //where, içindeki şarta uyan tüm elemanları yeni bir liste haline getirir ve döndürür
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p=>p.ProductID==product.ProductID);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
