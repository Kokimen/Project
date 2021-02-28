﻿using System;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductManager : IProductService //manager gördüysen iş katmanının somut hali
    {
        readonly IProductDal _productDal; //bir iş katmanı başka bir iş katmanını yenileyemediği için bunu yazıyoruz ve ctor generate ediyoruz

        public ProductManager(IProductDal productDal) //injection
        {
            _productDal = productDal;
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour==15)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product) //void bir şey döndürmez ancak kullanıcıya geribildirim yapmak istiyoruz
        {
            //BusinessCode => İş kuralları, iş kodları.
            //Validation => Doğrulama kodları, iş kurallarına uygun mu değil mi kontrol eder.

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }
    }

}
