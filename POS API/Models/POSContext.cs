using CommonLibrary;
using CommonLibrary.Model.Customer;
using CommonLibrary.Model.Item;
using CommonLibrary.Model.Order;
using Microsoft.EntityFrameworkCore;

namespace POS_API.Models;

public class POSContext : DbContext
{
    public POSContext(DbContextOptions<POSContext> options) : base(options)
    {
    }

    public DbSet<ContactNumber> ContactNumbers { get; set; }
    public DbSet<ContactNumberType> ContactNumberTypes { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerAddress> CustomerAddresses { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<ItemCategory> ItemCategories { get; set; }
    public DbSet<ItemPriceHistory> ItemPriceHistories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderContent> OrderContents { get; set; }
    public DbSet<OrderPayment> OrderPayments { get; set; }
    public DbSet<OrderPaymentMethod> OrderPaymentMethods { get; set; }
    public DbSet<OrderStatus> OrderStatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"DataSource=LocalDatabase.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderStatus>().HasData(
            new OrderStatus() { OrderStatusId = 1, Name = "New", IsSystemRequired = true },
            new OrderStatus() { OrderStatusId = 1, Name = "Pending Payment", IsSystemRequired = true },
            new OrderStatus() { OrderStatusId = 2, Name = "Complete", IsSystemRequired = true }
        );
    }
}
