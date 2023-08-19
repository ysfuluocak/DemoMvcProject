﻿using DemoMvcProject.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMvcProject.Entities.Concrete
{
    public class Product : BaseEntity
    {
        public Product()
        {
            CreatedDate = DateTime.Now;
            Status = true;
        }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
