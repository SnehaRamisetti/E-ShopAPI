using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApi.Models.Domain;

namespace MyApi.Repositories
{
    public interface IOrderRepository
    {
       Task<List<Order>> GetAllAsync();

       Task<Order?> GetByIdAsync(Guid id);

       Task<Order> CreateAsync(Order order);
     
       Task<Order?> UpdateAsync(Guid id,Order order);

       Task<Order?> DeleteAsync(Guid id);
    }
}