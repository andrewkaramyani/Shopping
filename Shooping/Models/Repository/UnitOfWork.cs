using Microsoft.EntityFrameworkCore;
using shooping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shooping.Models.Repository
{
    public class UnitOfWork : IRepositorys
    {
        private readonly AppDbContext context;

        public UnitOfWork(AppDbContext Context)
        {
            context = Context;
        }

        #region Products

      
        public Product AddProduct(Product model)
        {
            context.Products.Add(model);
            context.SaveChanges();
            return model;
        }

        public Product FindProduct(string id)
        {
            return context.Products.Find(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products.Include(c => c.Category).Include(u => u.owner);
        }

        public Product RemoveProduct(string id)
        {
            var product = context.Products.Find(id);
            context.Products.Remove(product);
            context.SaveChanges();
            return product;
        }
        #endregion


    }
}
