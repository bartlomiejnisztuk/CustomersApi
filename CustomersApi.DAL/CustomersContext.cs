using System.Collections.Generic;
using CustomersApi.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomersApi.DAL
{
    public class CustomersContext : DbContext
    {
        public CustomersContext(DbContextOptions options) : base(options)
        {
        }

        protected CustomersContext()
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressTypeMapping> AddressTypeMappings { get; set; }

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
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(e => new
                {
                    e.CustomerId,
                    e.CustomerName
                });


            modelBuilder.Entity<AddressTypeMapping>()
                .HasKey(e => e.AddressType);

            modelBuilder
                .Entity<Address>()
                .HasOne<AddressTypeMapping>(e => e.AddressTypeMapping)
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

            modelBuilder.Entity<Customer>()
                .HasData(GetSampleCustomer());

            modelBuilder.Entity<Address>()
                .HasData(GetSampleAddress());
        }

        private List<Customer> GetSampleCustomer()
        {
            return new List<Customer>
            {
                new Customer
                {
                    CustomerId = "c1",
                    Name = "John",
                    City = "New York",
                    Country = "US",
                    Street = "1st Avenue",
                    ZIP = "123",
                }
            };
        }
        private List<Address> GetSampleAddress()
        {
            return new List<Address>
            {
                new Address
                {
                    AddressType = 'D',
                    City = "Dallas",
                    Country = "US",
                    Name = "home",
                    Street = "2nd Avenue",
                    ZIP = "234",
                    CustomerId = "c1",
                    CustomerName = "John",
                },
                new Address
                {
                    AddressType = 'I',
                    City = "Dallas",
                    Country = "US",
                    Name = "work",
                    Street = "2nd Avenue",
                    ZIP = "234",
                    CustomerId = "c1",
                    CustomerName = "John",
                },
            };
        }
    }
}
