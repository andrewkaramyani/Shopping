using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace shooping.Models
{
    public class Product
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string PhotoPath { get; set; }
        public int Price { get; set; }
        [ForeignKey("Category")]
        public string Cat_Id {get; set;}

        [ForeignKey("owner")]
        public string Sealer_Id { get; set; }
        public virtual person owner { get; set; }

        public virtual Category Category { get; set; }


    }
}