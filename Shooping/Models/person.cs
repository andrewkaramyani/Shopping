using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace shooping.Models
{
    public class person : IdentityUser
    {
       [Required]
        public string FullName { get; set; }

        [DisplayName("Sealer Or Customer")]
        public PersonType PersonType { get; set; }

        //[ForeignKey("Products")]
        //public int product_Id { get; set; }

        public string City { get; set; }


        public virtual ICollection<Product> Products { get; set; }

        public person()
        {
            Products = new HashSet<Product>();
        }
    }
}