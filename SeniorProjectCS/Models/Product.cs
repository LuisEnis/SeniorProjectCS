using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeniorProjectCS.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(50)]
        public string Name { get; set; }
        //Automatically a foreign key because entity framework knows Id as primary key and it also has a class called product where Id is its primary key
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        //Load products with their categories
        public Category Category { get; set; }
        [Display(Name = "Price (€)")]
        public decimal Price { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
    }
}