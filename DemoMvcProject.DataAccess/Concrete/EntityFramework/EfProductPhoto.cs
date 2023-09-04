﻿using DemoMvcProject.Core.DataAccess.Concrete.EntityFramework;
using DemoMvcProject.DataAccess.Abstract;
using DemoMvcProject.Entities.Concrete;

namespace DemoMvcProject.DataAccess.Concrete.EntityFramework
{
    public class EfProductPhoto : EfEntityRepositoryBase<ProductPhoto,AppDbContext>,IProductPhotoDal
    {

    }
}
