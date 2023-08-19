﻿using DemoMvcProject.Entities.Concrete;
using DemoMvcProject.Entities.Dtos.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMvcProject.Business.Abstract
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        IEnumerable<ProductDetailsDto> GetAllProductDetails();
        ProductDetailsDto GetProductDetails(int id);
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        void UpdateProductStock(int productId, int quantityChange);
    }
}
