using shooping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shooping.Models.Repository
{
    public interface IRepositorys
    {
        #region Products
        public IEnumerable<Product> GetProducts();
        public Product AddProduct(Product model);
        public Product RemoveProduct(string id);
        public Product FindProduct(string id);
        #endregion
    }
}
