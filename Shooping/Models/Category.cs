using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace shooping.Models
{
    public class Category
    {

        public string Id { get; set; }
        public Category_enum Name { get; set; }

        public string photopath { get; set; }

        //[ForeignKey("Products")]
        //public string product_Id { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            Products = new HashSet<Product>();
        }
    }
}