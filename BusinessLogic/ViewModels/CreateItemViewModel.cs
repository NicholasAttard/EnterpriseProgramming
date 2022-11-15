using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.ViewModels
{
    public class CreateItemViewModel
    {
        //Is a selection of the required properties to be used by the presentation layer
        public List<CategoryViewModel> Categories { get; set; }
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string PhotoPath { get; set; }
    }
}
