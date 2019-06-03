using System;
using System.Collections.Generic;
using CustomersApi.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomersApi.DAL
{
    public class CustomersContext: DbContext
    {
        public CustomersContext(DbContextOptions options) : base(options)
        {
        }

        protected CustomersContext()
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(table => new
            {
                table.CustomerId,
                table.Name
            });

            modelBuilder.Entity<Address>().HasKey(table => new
            {
                table.CustomerId,
                table.AddressType
            });

            modelBuilder
                .Entity<Customer>()
                .HasMany(e => e.Addresses)
                .WithOne(e => e.Customer)
                .HasForeignKey(e => new
                {
                    e.CustomerId,
                    e.CustomerName
                });


            modelBuilder.Entity<AddressTypeMapping>()
                .HasKey(e => e.AddressType);

            modelBuilder
                .Entity<Address>()
                .HasOne<AddressTypeMapping>(e=>e.AddressTypeMapping)
                .WithMany()
                .HasForeignKey(e => new
                {
                    e.AddressType
                });

            modelBuilder.Entity<AddressTypeMapping>()
                .HasData(new List<AddressTypeMapping>
                {
                    new AddressTypeMapping
                    {
                        AddressType = 'D',
                        AddressName = "delivery address"
                    },
                    new AddressTypeMapping
                    {
                        AddressType = 'I',
                        AddressName = "invoice address"
                    },
                    new AddressTypeMapping
                    {
                        AddressType = 'S',
                        AddressName = "service address"
                    },
                });
        }

        private char AddressTypeToChar(string addressType)
        {
            switch (addressType)
            {
                case "invoice address":
                    return 'I';
                case "delivery address":
                    return 'D';
                case "service address":
                    return 'S';
                default:
                    throw new ArgumentException($"Address type: {addressType} is not valid.");
            }
        }

        private string AddressTypeToString(char addressType)
        {
            switch (addressType)
            {
                case 'I' :
                    return "invoice address";
                case 'D':
                    return "delivery address";
                case 'S' :
                    return "service address";
                default:
                    throw new ArgumentException($"Address type: {addressType} is not valid.");
            }
        }
    }
}
