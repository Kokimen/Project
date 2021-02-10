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
    }
}
