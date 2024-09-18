using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyApi.Models.DTO
{
    public class CustomerDto
    {
        public Guid CustomerId { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        [EmailAddress]
        public string? email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

    }
}