using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService //manager gördüysen iş katmanının somut hali
    {
        IProductDal _productDal; //bir iş katmanı başka bir iş katmanını yenileyemediği için bunu yazıyoruz ve ctor generate ediyoruz

        public ProductManager(IProductDal productDal) //injection
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //İş Kodları
            //Yetkisi var mı?
            return _productDal.GetAll();
            
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }
    }
}
