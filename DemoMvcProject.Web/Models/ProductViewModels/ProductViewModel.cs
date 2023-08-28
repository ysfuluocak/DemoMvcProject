using DemoMvcProject.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoMvcProject.Web.Models.ProductViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string CategoryName { get; set; }
        public List<ProductPhoto> Photos { get; set; }
    }
}
