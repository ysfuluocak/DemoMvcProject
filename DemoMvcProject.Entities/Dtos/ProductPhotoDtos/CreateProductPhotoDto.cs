using DemoMvcProject.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMvcProject.Entities.Dtos.ProductPhotoDtos
{
    public class CreateProductPhotoDto : IDto
    {
        public int ProductId { get; set; }
        public string? ImagePath { get; set; }
    }
}
