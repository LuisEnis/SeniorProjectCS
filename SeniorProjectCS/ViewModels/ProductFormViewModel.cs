using SeniorProjectCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeniorProjectCS.ViewModels
{
    public class ProductFormViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}