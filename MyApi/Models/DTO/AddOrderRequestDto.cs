using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
using System.ComponentModel.DataAnnotations;

namespace MyApi.Models.DTO
{
    public class AddOrderRequestDto
    {
        [Required]
        public string ShippingAddress { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        public DateTime? OrderDate { get; set; }

        [Required]
        public string OrderStatus { get; set; }

        [Required]
        public Guid ProductId { get; set; }

       [Required]
        public Guid CustomerId { get; set; }

    }
}