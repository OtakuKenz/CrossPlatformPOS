﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POS_API.Models;

#nullable disable

namespace POS_API.Migrations
{
    [DbContext(typeof(POSContext))]
    [Migration("20231103143933_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("CommonLibrary.Model.Customer.ContactNumber", b =>
                {
                    b.Property<int>("ContactNumberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContactNumberTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.HasKey("ContactNumberId");

                    b.HasIndex("ContactNumberTypeId");

                    b.HasIndex("CustomerId");

                    b.ToTable("ContactNumbers");
                });

            modelBuilder.Entity("CommonLibrary.Model.Customer.ContactNumberType", b =>
                {
                    b.Property<int>("ContactNumberTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("ContactNumberTypeId");

                    b.HasIndex("Type")
                        .IsUnique();

                    b.ToTable("ContactNumberTypes");
                });

            modelBuilder.Entity("CommonLibrary.Model.Customer.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CommonLibrary.Model.Customer.CustomerAddress", b =>
                {
                    b.Property<int>("CustomerAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AdditionalNotes")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FullAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Landmark")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("CustomerAddressId");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerAddresses");
                });

            modelBuilder.Entity("CommonLibrary.Model.Item.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemCategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("ItemId");

                    b.HasIndex("ItemCategoryId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("CommonLibrary.Model.Item.ItemCategory", b =>
                {
                    b.Property<int>("ItemCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("ItemCategoryId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ItemCategories");
                });

            modelBuilder.Entity("CommonLibrary.Model.Item.ItemPriceHistory", b =>
                {
                    b.Property<int>("ItemPriceHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.HasKey("ItemPriceHistoryId");

                    b.HasIndex("ItemId");

                    b.ToTable("ItemPriceHistories");
                });

            modelBuilder.Entity("CommonLibrary.Model.Order.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalDiscount")
                        .HasColumnType("TEXT");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OrderNumber")
                        .IsUnique();

                    b.HasIndex("OrderStatusId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CommonLibrary.Model.Order.OrderContent", b =>
                {
                    b.Property<int>("OrderContentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderContentId");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderContents");
                });

            modelBuilder.Entity("CommonLibrary.Model.Order.OrderPayment", b =>
                {
                    b.Property<int>("OrderPaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderPaymentMethodId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ReferenceNumber")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.HasKey("OrderPaymentId");

                    b.HasIndex("OrderId");

                    b.HasIndex("OrderPaymentMethodId");

                    b.ToTable("OrderPayments");
                });

            modelBuilder.Entity("CommonLibrary.Model.Order.OrderPaymentMethod", b =>
                {
                    b.Property<int>("OrderPaymentMethodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("OrderPaymentMethodId");

                    b.ToTable("OrderPaymentMethods");
                });

            modelBuilder.Entity("CommonLibrary.OrderStatus", b =>
                {
                    b.Property<int>("OrderStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("OrderStatusId");

                    b.ToTable("OrderStatuses");

                    b.HasData(
                        new
                        {
                            OrderStatusId = 1,
                            Description = "",
                            IsActive = false,
                            Name = "New"
                        },
                        new
                        {
                            OrderStatusId = 2,
                            Description = "",
                            IsActive = false,
                            Name = "Complete"
                        });
                });

            modelBuilder.Entity("CommonLibrary.Model.Customer.ContactNumber", b =>
                {
                    b.HasOne("CommonLibrary.Model.Customer.ContactNumberType", "ContactNumberType")
                        .WithMany()
                        .HasForeignKey("ContactNumberTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommonLibrary.Model.Customer.Customer", "Customer")
                        .WithMany("ContactNumbers")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactNumberType");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CommonLibrary.Model.Customer.CustomerAddress", b =>
                {
                    b.HasOne("CommonLibrary.Model.Customer.Customer", "Customer")
                        .WithMany("Addresses")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CommonLibrary.Model.Item.Item", b =>
                {
                    b.HasOne("CommonLibrary.Model.Item.ItemCategory", "ItemCategory")
                        .WithMany()
                        .HasForeignKey("ItemCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemCategory");
                });

            modelBuilder.Entity("CommonLibrary.Model.Item.ItemPriceHistory", b =>
                {
                    b.HasOne("CommonLibrary.Model.Item.Item", "Item")
                        .WithMany("ItemPriceHistories")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("CommonLibrary.Model.Order.Order", b =>
                {
                    b.HasOne("CommonLibrary.Model.Customer.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("CommonLibrary.OrderStatus", "OrderStatus")
                        .WithMany()
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("OrderStatus");
                });

            modelBuilder.Entity("CommonLibrary.Model.Order.OrderContent", b =>
                {
                    b.HasOne("CommonLibrary.Model.Item.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommonLibrary.Model.Order.Order", "Order")
                        .WithMany("OrderContents")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("CommonLibrary.Model.Order.OrderPayment", b =>
                {
                    b.HasOne("CommonLibrary.Model.Order.Order", "Order")
                        .WithMany("OrderPayments")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommonLibrary.Model.Order.OrderPaymentMethod", "OrderPaymentMethod")
                        .WithMany()
                        .HasForeignKey("OrderPaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("OrderPaymentMethod");
                });

            modelBuilder.Entity("CommonLibrary.Model.Customer.Customer", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("ContactNumbers");
                });

            modelBuilder.Entity("CommonLibrary.Model.Item.Item", b =>
                {
                    b.Navigation("ItemPriceHistories");
                });

            modelBuilder.Entity("CommonLibrary.Model.Order.Order", b =>
                {
                    b.Navigation("OrderContents");

                    b.Navigation("OrderPayments");
                });
#pragma warning restore 612, 618
        }
    }
}
