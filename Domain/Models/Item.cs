using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    //Domain: will be a project referenced by all the other layers and will hold the data containers i.e models
    public class Class1
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public String Description { get; set; }
        public String PhotoPath { get; set; }
    }
}
