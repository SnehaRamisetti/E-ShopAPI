using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyApi.Data
{
    public class OrdersAuthDbContext :IdentityDbContext
    {
        public OrdersAuthDbContext(DbContextOptions<OrdersAuthDbContext> options): base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var readerRoleId ="d72ac587-08bf-4517-91b9-55d8f5633818";
            var writerRoleId ="8aad9d29-9e3e-43f5-834e-2b37acc38ae7";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()

                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()

                }

            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }

        
    }
}