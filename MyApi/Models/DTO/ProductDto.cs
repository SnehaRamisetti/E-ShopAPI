using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Models.DTO
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }
        
    }
}