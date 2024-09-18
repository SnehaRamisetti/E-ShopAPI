using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApi.Models.Domain;
using Microsoft.EntityFrameworkCore;
using MyApi.Data;

namespace MyApi.Repositories
{
    public class OrderRepo:IOrderRepository
    {
        private readonly OrdersDbContext dbContext;

        public OrderRepo(OrdersDbContext dbContext)
        {
            this.dbContext=dbContext;
        }

        public async Task<List<Order>> GetAllAsync()
        {
           return await dbContext.Orders.Include("Product").Include("Customer").ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(Guid id)
        {
            return await dbContext.Orders.Include("Product").Include("Customer").FirstOrDefaultAsync(x => x.OrderId==id);
        }

        public async Task<Order> CreateAsync(Order order)
        {
            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();
            return order;
        }

         public async Task<Order?> UpdateAsync(Guid id,Order order)
        {
           var exisitingOrder = await dbContext.Orders.FirstOrDefaultAsync(x => x.OrderId==id);
           
           if(exisitingOrder == null)
           {
            return null;
           }

           exisitingOrder.ShippingAddress = order.ShippingAddress;
           exisitingOrder.TotalPrice = order.TotalPrice;
           exisitingOrder.OrderDate = order.OrderDate;
           exisitingOrder.OrderStatus = order.OrderStatus;
           exisitingOrder.ProductId = order.ProductId;
           exisitingOrder.CustomerId = order.CustomerId;

           await dbContext.SaveChangesAsync();
           return exisitingOrder;
        }

        public async Task<Order?> DeleteAsync(Guid id)
        {
            var existingOrder= await dbContext.Orders.FirstOrDefaultAsync(x => x.OrderId==id);
            
            if(existingOrder == null)
            {
               return null;
            }
            dbContext.Orders.Remove(existingOrder);
            await dbContext.SaveChangesAsync();
            return existingOrder;
        }
        
    }
}