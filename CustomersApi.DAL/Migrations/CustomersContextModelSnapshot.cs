﻿// <auto-generated />
using CustomersApi.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CustomersApi.DAL.Migrations
{
    [DbContext(typeof(CustomersContext))]
    partial class CustomersContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CustomersApi.DAL.Entities.Address", b =>
                {
                    b.Property<string>("CustomerId");

                    b.Property<string>("AddressType")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<string>("AddressTypeMappingAddressType")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<string>("City")
                        .HasMaxLength(100);

                    b.Property<string>("Country")
                        .HasMaxLength(2);

                    b.Property<string>("CustomerName");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<string>("Street")
                        .HasMaxLength(100);

                    b.Property<string>("ZIP")
                        .HasMaxLength(20);

                    b.HasKey("CustomerId", "AddressType");

                    b.HasIndex("AddressType");

                    b.HasIndex("AddressTypeMappingAddressType");

                    b.HasIndex("CustomerId", "CustomerName");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("CustomersApi.DAL.Entities.AddressTypeMapping", b =>
                {
                    b.Property<string>("AddressType")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<string>("AddressName");

                    b.HasKey("AddressType");

                    b.ToTable("AddressTypeMapping");

                    b.HasData(
                        new
                        {
                            AddressType = "D",
                            AddressName = "delivery address"
                        },
                        new
                        {
                            AddressType = "I",
                            AddressName = "invoice address"
                        },
                        new
                        {
                            AddressType = "S",
                            AddressName = "service address"
                        });
                });

            modelBuilder.Entity("CustomersApi.DAL.Entities.Customer", b =>
                {
                    b.Property<string>("CustomerId")
                        .HasMaxLength(5);

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<string>("City")
                        .HasMaxLength(100);

                    b.Property<string>("Country")
                        .HasMaxLength(2);

                    b.Property<string>("Street")
                        .HasMaxLength(100);

                    b.Property<string>("ZIP")
                        .HasMaxLength(20);

                    b.HasKey("CustomerId", "Name");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CustomersApi.DAL.Entities.Address", b =>
                {
                    b.HasOne("CustomersApi.DAL.Entities.AddressTypeMapping")
                        .WithMany()
                        .HasForeignKey("AddressType")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CustomersApi.DAL.Entities.AddressTypeMapping", "AddressTypeMapping")
                        .WithMany()
                        .HasForeignKey("AddressTypeMappingAddressType");

                    b.HasOne("CustomersApi.DAL.Entities.Customer", "Customer")
                        .WithMany("Addresses")
                        .HasForeignKey("CustomerId", "CustomerName");
                });
#pragma warning restore 612, 618
        }
    }
}
