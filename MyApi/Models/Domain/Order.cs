using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Models.Domain
{
    public class Order
    {
        public Guid OrderId { get; set; }

        public string ShippingAddress { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime? OrderDate { get; set; }

        public string OrderStatus { get; set; }

        public Guid ProductId { get; set; }

        public Guid CustomerId { get; set; }

        //Navigation properties
        public Product Product { get; set; }

        public Customer Customer { get; set; }
    }
}