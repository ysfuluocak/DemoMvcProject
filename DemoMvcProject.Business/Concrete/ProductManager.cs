﻿using DemoMvcProject.Business.Abstract;
using DemoMvcProject.DataAccess.Abstract;
using DemoMvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMvcProject.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public Product GetById(int id)
        {
           return _productDal.Get(p=>p.Id == id);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }

}
