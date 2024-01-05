using Microsoft.EntityFrameworkCore;
using CornerStore.Models;
public class CornerStoreDbContext : DbContext
{
    public DbSet<Cashier> Cashiers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
    public DbSet<Product> Products { get; set; }

    public CornerStoreDbContext(DbContextOptions<CornerStoreDbContext> context) : base(context)
    {

    }

    //allows us to configure the schema when migrating as well as seed data
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cashier>().HasData(new Cashier[]
        {
            new Cashier {Id = 1, FirstName = "Donna", LastName = "Franklin"},
            new Cashier {Id = 2, FirstName = "John", LastName = "Smith"},
            new Cashier {Id = 3, FirstName = "Emily", LastName = "Johnson"},
            new Cashier {Id = 4, FirstName = "Michael", LastName = "Williams"},
            new Cashier {Id = 5, FirstName = "Sophia", LastName = "Davis"},
            new Cashier {Id = 6, FirstName = "Daniel", LastName = "Miller"},
            new Cashier {Id = 7, FirstName = "Olivia", LastName = "Jones"},
            new Cashier {Id = 8, FirstName = "Ethan", LastName = "Moore"}
        });

        modelBuilder.Entity<Category>().HasData(new Category[]
        {
            new Category {Id = 1, CategoryName = "Printed Material"},
            new Category {Id = 2, CategoryName = "Beverages"},
            new Category {Id = 3, CategoryName = "Snacks"},
            new Category {Id = 4, CategoryName = "Personal Care"},
            new Category {Id = 5, CategoryName = "Household Items"},
        });

        modelBuilder.Entity<Product>().HasData(new Product[]
        {
            new Product {Id = 1, ProductName = "Magazine A", Price = 4.99M, Brand = "Publisher X", CategoryId = 1},
            new Product {Id = 2, ProductName = "Newspaper B", Price = 1.99M, Brand = "Daily News", CategoryId = 1},
            new Product {Id = 3, ProductName = "Diet Coke", Price = 0.99M, Brand = "Coca-Cola", CategoryId = 2},
            new Product {Id = 4, ProductName = "Potato Chips", Price = 2.49M, Brand = "SnackCo", CategoryId = 3},
            new Product {Id = 5, ProductName = "Toothpaste", Price = 3.99M, Brand = "CleanSmile", CategoryId = 4},
            new Product {Id = 6, ProductName = "Paper Towels", Price = 5.99M, Brand = "SoftTouch", CategoryId = 5},
            new Product {Id = 7, ProductName = "Multivitamins", Price = 8.99M, Brand = "HealthGuard", CategoryId = 4},
            new Product {Id = 8, ProductName = "AA Batteries", Price = 6.49M, Brand = "PowerCell", CategoryId = 5},
            new Product {Id = 9, ProductName = "Notepad", Price = 1.79M, Brand = "WriteRight", CategoryId = 5},
            new Product {Id = 10, ProductName = "Chocolate Bar", Price = 1.49M, Brand = "SweetTreat", CategoryId = 3},
            new Product {Id = 11, ProductName = "Shampoo", Price = 4.49M, Brand = "SilkyLocks", CategoryId = 4},
            new Product {Id = 12, ProductName = "Trash Bags", Price = 7.99M, Brand = "CleanUp", CategoryId = 5},
            new Product {Id = 13, ProductName = "Hand Sanitizer", Price = 2.99M, Brand = "GermGuard", CategoryId = 4},
            new Product {Id = 14, ProductName = "Flashlight", Price = 9.99M, Brand = "BrightBeam", CategoryId = 5},
            new Product {Id = 15, ProductName = "Laptop Charger", Price = 19.99M, Brand = "PowerUp", CategoryId = 5},
            new Product {Id = 16, ProductName = "Granola Bars", Price = 3.29M, Brand = "HealthyBite", CategoryId = 3},
            new Product {Id = 17, ProductName = "Dish Soap", Price = 2.99M, Brand = "SparkleClean", CategoryId = 5},
            new Product {Id = 18, ProductName = "Pain Reliever", Price = 4.79M, Brand = "ReliefRx", CategoryId = 4},
            new Product {Id = 19, ProductName = "Earbuds", Price = 14.99M, Brand = "SoundWave", CategoryId = 5},
            new Product {Id = 20, ProductName = "Printer Paper", Price = 6.99M, Brand = "PrintMaster", CategoryId = 5},
            new Product {Id = 21, ProductName = "Mouthwash", Price = 3.49M, Brand = "FreshBreath", CategoryId = 4},
            new Product {Id = 22, ProductName = "Notebook", Price = 2.49M, Brand = "NoteMaster", CategoryId = 5},
            new Product {Id = 23, ProductName = "Energy Drink", Price = 2.99M, Brand = "BoostFuel", CategoryId = 2},
            new Product {Id = 24, ProductName = "Hand Lotion", Price = 4.29M, Brand = "SoftGlow", CategoryId = 4},
            new Product {Id = 25, ProductName = "USB Flash Drive", Price = 8.49M, Brand = "DataSaver", CategoryId = 5}
        });

        modelBuilder.Entity<Order>().HasData(new Order[]
        {
            new Order {Id = 1, CashierId = 1, PaidOnDate = new DateTime(2023, 12, 29)},
            new Order {Id = 2, CashierId = 2, PaidOnDate = new DateTime(2023, 12, 30)},
            new Order {Id = 3, CashierId = 3, PaidOnDate = new DateTime(2023, 12, 31)},
            new Order {Id = 4, CashierId = 4, PaidOnDate = new DateTime(2024, 1, 1)},
            new Order {Id = 5, CashierId = 5, PaidOnDate = new DateTime(2024, 1, 2)},
            new Order {Id = 6, CashierId = 6, PaidOnDate = new DateTime(2024, 1, 3)},
            new Order {Id = 7, CashierId = 7, PaidOnDate = new DateTime(2024, 1, 4)},
            new Order {Id = 8, CashierId = 8, PaidOnDate = new DateTime(2024, 1, 5)},
            new Order {Id = 9, CashierId = 1},
            new Order {Id = 10, CashierId = 2}
        });

        modelBuilder.Entity<OrderProduct>().HasData(new OrderProduct[]
        {
            new OrderProduct {Id = 1, OrderId = 1, ProductId = 1, Quantity = 1},
            new OrderProduct {Id = 2, OrderId = 1, ProductId = 8, Quantity = 2},
            new OrderProduct {Id = 3, OrderId = 2, ProductId = 3, Quantity = 6},
            new OrderProduct {Id = 4, OrderId = 2, ProductId = 10, Quantity = 4},
            new OrderProduct {Id = 5, OrderId = 2, ProductId = 4, Quantity = 1},
            new OrderProduct {Id = 6, OrderId = 3, ProductId = 19, Quantity = 1},
            new OrderProduct {Id = 7, OrderId = 4, ProductId = 18, Quantity = 1},
            new OrderProduct {Id = 8, OrderId = 5, ProductId = 23, Quantity = 2},
            new OrderProduct {Id = 9, OrderId = 6, ProductId = 2, Quantity = 1},
            new OrderProduct {Id = 10, OrderId = 7, ProductId = 13, Quantity = 1},
            new OrderProduct {Id = 11, OrderId = 7, ProductId = 24, Quantity = 1},
            new OrderProduct {Id = 12, OrderId = 8, ProductId = 20, Quantity = 10},
            new OrderProduct {Id = 13, OrderId = 9, ProductId = 16, Quantity = 5},
            new OrderProduct {Id = 14, OrderId = 9, ProductId = 14, Quantity = 1},
            new OrderProduct {Id = 15, OrderId = 10, ProductId = 7, Quantity = 1},
            new OrderProduct {Id = 16, OrderId = 10, ProductId = 25, Quantity = 1},
            new OrderProduct {Id = 17, OrderId = 10, ProductId = 12, Quantity = 20},
        });
    }
}