using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Models.Domain
{
    public class Product
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }
        
    }
}