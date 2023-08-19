﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoMvcProject.Web.Models.ProductViewModels
{
    public class CreateProductViewModel
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public SelectList Categories { get; set; }
    }
}
