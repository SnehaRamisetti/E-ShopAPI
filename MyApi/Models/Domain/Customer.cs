using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Models.Domain
{
    public class Customer
    {
        public Guid CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string? email { get; set; }

        public string PhoneNumber { get; set; }

    }
}