using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApi.Models.Domain;

namespace MyApi.Repositories
{
    public interface IProductRepository
    {
       Task<List<Product>> GetAllAsync();

       Task<Product?> GetByIdAsync(Guid id);

       Task<Product> CreateAsync(Product product);
     
       Task<Product?> UpdateAsync(Guid id,Product product);

       Task<Product?> DeleteAsync(Guid id);
    }
}