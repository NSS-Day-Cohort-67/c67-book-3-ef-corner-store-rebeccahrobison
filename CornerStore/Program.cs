using CornerStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core and provides dummy value for testing
builder.Services.AddNpgsql<CornerStoreDbContext>(builder.Configuration["CornerStoreDbConnectionString"] ?? "testing");

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//ENDPOINTS

//CASHIERS
//Add a cashier
app.MapPost("/cashiers", (CornerStoreDbContext db, Cashier cashier) =>
{
    db.Cashiers.Add(cashier);
    db.SaveChanges();
    return Results.Created($"/cashiers/{cashier.Id}", cashier);
});

// Get a cashier
app.MapGet("/cashiers/{id}", (CornerStoreDbContext db, int id) =>
{
    Cashier foundCashier = db.Cashiers
    .Include(c => c.Orders)
    .ThenInclude(o => o.OrderProducts)
    .ThenInclude(op => op.Product)
    .FirstOrDefault(c => c.Id == id);

    if (foundCashier == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(new Cashier
    {
        Id = foundCashier.Id,
        FirstName = foundCashier.FirstName,
        LastName = foundCashier.LastName,
        Orders = foundCashier.Orders.Select(o => new Order
        {
            Id = o.Id,
            CashierId = o.CashierId,
            PaidOnDate = o.PaidOnDate,
            OrderProducts = o.OrderProducts.Select(op => new OrderProduct
            {
                Id = op.Id,
                ProductId = op.ProductId,
                OrderId = op.OrderId,
                Quantity = op.Quantity,
                Product = new Product
                {
                    Id = op.Product.Id,
                    ProductName = op.Product.ProductName,
                    Price = op.Product.Price,
                    Brand = op.Product.Brand,
                    CategoryId = op.Product.CategoryId
                }
            }).ToList()
        }).ToList()
    });
});


// PRODUCTS
// Get all products with their categories
// If the search query string param is present, return only products whose names or category names include the search value (ignore case).
app.MapGet("/products", (CornerStoreDbContext db, string? name) =>
{
    IQueryable<Product> query = db.Products.Include(p => p.Category);

    if (name != null)
    {
        query = query.AsEnumerable().Where(p =>
            string.Equals(p.ProductName, name, StringComparison.OrdinalIgnoreCase) ||
            string.Equals(p.Category.CategoryName, name, StringComparison.OrdinalIgnoreCase)
        ).AsQueryable();
    }

    List<Product> filteredProducts = query.ToList();

    return filteredProducts
        .Select(p => new Product
        {
            Id = p.Id,
            ProductName = p.ProductName,
            Price = p.Price,
            Brand = p.Brand,
            CategoryId = p.CategoryId,
            Category = new Category
            {
                Id = p.Category.Id,
                CategoryName = p.Category.CategoryName
            }
        });
});

// Add a product
app.MapPost("/products", (CornerStoreDbContext db, Product product) =>
{
    db.Products.Add(product);
    db.SaveChanges();
    return Results.Created($"/products/{product.Id}", product);
});

// Update a product
app.MapPut("/products/{id}", (CornerStoreDbContext db, int id, Product product) =>
{
    Product productToUpdate = db.Products.SingleOrDefault(p => p.Id == id);
    if (productToUpdate == null)
    {
        return Results.NotFound();
    }
    productToUpdate.ProductName = product.ProductName;
    productToUpdate.Price = product.Price;
    productToUpdate.Brand = product.Brand;
    productToUpdate.CategoryId = product.CategoryId;

    db.SaveChanges();
    return Results.NoContent();
});


// ORDERS
// Get order details, including cashier, order products, and products
app.MapGet("/orders/{id}", (CornerStoreDbContext db, int id) =>
{
    Order foundOrder = db.Orders
        .Include(o => o.Cashier)
        .Include(o => o.OrderProducts)
        .ThenInclude(op => op.Product)
        .FirstOrDefault(o => o.Id == id);

        if (foundOrder == null)
        {
            return Results.NotFound();
        }

        return Results.Ok(new Order
        {
            Id = foundOrder.Id,
            CashierId = foundOrder.CashierId,
            PaidOnDate = foundOrder.PaidOnDate,
            Cashier = new Cashier
            {
                Id = foundOrder.Cashier.Id,
                FirstName = foundOrder.Cashier.FirstName,
                LastName = foundOrder.Cashier.LastName
            },
            OrderProducts = foundOrder.OrderProducts.Select(op => new OrderProduct
            {
                Id = op.Id,
                ProductId = op.ProductId,
                OrderId = op.OrderId,
                Quantity = op.Quantity,
                Product = new Product
                {
                    Id = op.Product.Id,
                    ProductName = op.Product.ProductName,
                    Price = op.Product.Price,
                    Brand = op.Product.Brand,
                    CategoryId = op.Product.CategoryId
                }
            }).ToList()
        });
});

// Get all orders
app.MapGet("/orders", (CornerStoreDbContext db, DateTime? orderDate) =>
{
    List<Order> filteredOrders = db.Orders.Include(o => o.Cashier).ToList();

    if (orderDate != null)
    {
        Console.WriteLine($"Filtering by order date: {orderDate}");
        filteredOrders = filteredOrders.Where(order => order.PaidOnDate == orderDate).ToList();
    }

    return filteredOrders
        .OrderBy(o => o.Id)
        .Select(o => new Order
        {
            Id = o.Id,
            CashierId = o.CashierId,
            PaidOnDate = o.PaidOnDate,
            Cashier = new Cashier
            {
                Id = o.Cashier.Id,
                FirstName = o.Cashier.FirstName,
                LastName = o.Cashier.LastName
            }
        });
});

// Delete an order
app.MapDelete("/orders/{id}", (CornerStoreDbContext db, int id) => 
{
    Order foundOrder = db.Orders.SingleOrDefault(o => o.Id == id);
    if (foundOrder == null)
    {
        return Results.NotFound();
    }
    db.Orders.Remove(foundOrder);
    db.SaveChanges();
    return Results.NoContent();
});

// Create an order with products
app.MapPost("/orders", (CornerStoreDbContext db, Order order) =>
{
    var orderToAdd = new Order
    {
        CashierId = order.CashierId,
        PaidOnDate = order.PaidOnDate
    };
    db.Orders.Add(orderToAdd);
    db.SaveChanges();

    foreach (var orderProduct in order.OrderProducts)
    {
        var orderProductToAdd = new OrderProduct
        {
            ProductId = orderProduct.ProductId,
            OrderId = orderToAdd.Id,
            Quantity = orderProduct.Quantity
        };
        db.OrderProducts.Add(orderProductToAdd);
    }

    db.SaveChanges();

    return Results.Created($"/orders/{order.Id}", order);
});

// Get the most popular products
app.MapGet("/products/popular", (CornerStoreDbContext db, int? amount) =>
{
    amount ??= 5;

    var popularProducts = db.OrderProducts
        .GroupBy(op => op.ProductId)
        .Select(group => new
        {
            ProductId = group.Key,
            TotalQuantity = group.Sum(op => op.Quantity)
        })
        .OrderByDescending(result => result.TotalQuantity)
        .Take(amount.Value)
        .ToList();
    
    var popularProductsDetails = popularProducts
        .Select(result => new
        {
            // ProductId = result.ProductId,
            TotalQuantity = result.TotalQuantity,
            Product = db.Products
                .Where(p => p.Id == result.ProductId)
                .Select(p => new
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    Brand = p.Brand
                })
                .FirstOrDefault()
        }).ToList();
    
    return popularProductsDetails;
});

app.Run();

//don't move or change this!
public partial class Program { }







    // {
    //     // var parsedOrderDate = new DateTime(orderDate);
    //     Console.WriteLine($"Parsed Order Date: {orderDate}");
        
    //     query = query.Where(o => 
    //         o.PaidOnDate.HasValue && 
    //         o.PaidOnDate.Value.Date == parsedOrderDate.Date);
        
    //     Console.WriteLine($"Query SQL: {query.ToQueryString()}");
    // }




    // IQueryable<Order> query = db.Orders.Include(o => o.Cashier);

    // if (orderDate != null)
    // {
    //     DateTime parsedOrderDate = orderDate.Value.Date;
    //     Console.WriteLine($"Parsed Order Date: {parsedOrderDate}");
    //     query = query.Where(o =>
    //         o.PaidOnDate.HasValue &&
    //         o.PaidOnDate.Value.Date == parsedOrderDate
    //     );
    //     Console.WriteLine($"Query SQL: {query.ToQueryString()}");
    // }

    // List<Order> filteredOrders = query.ToList();

    // return filteredOrders
    //     .OrderBy(o => o.Id)
    //     .Select(o => new Order
    //     {
    //         Id = o.Id,
    //         CashierId = o.CashierId,
    //         PaidOnDate = o.PaidOnDate,
    //         Cashier = new Cashier
    //         {
    //             Id = o.Cashier.Id,
    //             FirstName = o.Cashier.FirstName,
    //             LastName = o.Cashier.LastName
    //         }
    //     });