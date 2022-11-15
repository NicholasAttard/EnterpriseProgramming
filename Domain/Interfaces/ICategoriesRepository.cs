using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface ICategoriesRepository
    {
        IQueryable<Category> GetCategories();
    }
}
