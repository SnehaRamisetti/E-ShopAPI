using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Models.DTO
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }

        public string ShippingAddress { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime? OrderDate { get; set; }

        public string OrderStatus { get; set; }

        public ProductDto Product { get; set; }

        public CustomerDto Customer { get; set; }
    }
}