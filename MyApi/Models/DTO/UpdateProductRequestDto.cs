using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyApi.Models.DTO
{
    public class UpdateProductRequestDto
    {
        [Required]
        public string ProductName { get; set; }
       
        [Required]
        public decimal Price { get; set; }
        
    }
}