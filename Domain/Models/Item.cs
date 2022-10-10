using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain
{
    //Domain: will be a project referenced by all the other layers and will hold the data containers i.e models
    public class Class1
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        public String Name { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public double Price { get; set; }
        public String Description { get; set; }
        public String PhotoPath { get; set; }
    }
}
