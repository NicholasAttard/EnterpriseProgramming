using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.ViewModels
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Category { get; set; }
        public double Price { get; set; }
        public String Description { get; set; }
        public String PhotoPath { get; set; }
    }
}
