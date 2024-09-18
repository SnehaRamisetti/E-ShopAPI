using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApi.Models.Domain;
using MyApi.Data;

namespace MyApi.Repositories
{
    public class ProductRepo:IProductRepository
    {
        private readonly OrdersDbContext dbContext;

        public ProductRepo(OrdersDbContext dbContext)
        {
            this.dbContext=dbContext;
        }

        public async Task<List<Product>> GetAllAsync()
        {
           return await dbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await dbContext.Products.FirstOrDefaultAsync(x => x.ProductId==id);
        }

        public async Task<Product> CreateAsync(Product product)
        {
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> UpdateAsync(Guid id,Product product)
        {
           var exisitingProduct = await dbContext.Products.FirstOrDefaultAsync(x => x.ProductId==id);
           
           if(exisitingProduct == null)
           {
            return null;
           }

           exisitingProduct.ProductName = product.ProductName;
           exisitingProduct.Price = product.Price;

           await dbContext.SaveChangesAsync();
           return exisitingProduct;
        }

        public async Task<Product?> DeleteAsync(Guid id)
        {
            var existingproduct= await dbContext.Products.FirstOrDefaultAsync(x => x.ProductId==id);
            
            if(existingproduct == null)
            {
               return null;
            }
            dbContext.Products.Remove(existingproduct);
            await dbContext.SaveChangesAsync();
            return existingproduct;
        }

    }
}