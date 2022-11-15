using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.ViewModels;
using DataAccess.Repositories;
using Domain.Interfaces;

namespace BusinessLogic.Services
{
    public class CategoriesServices
    {
        private ICategoriesRepository cr;

        public CategoriesServices(ICategoriesRepository _categoriesRepository)
        {
            cr = _categoriesRepository;
        }

        public IQueryable<CategoryViewModel> GetCategories()
        {//AutoMapper -- Still to be implemented to replace the following code;
            var list = from c in cr.GetCategories()
                       select new CategoryViewModel()
                       {
                           Id = c.Id,
                           Title = c.Title
                       };
            return list;
        }
    }
}
