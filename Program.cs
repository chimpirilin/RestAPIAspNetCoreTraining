using Microsoft.EntityFrameworkCore;
using RestApi.DBContext;
using RestApi.Interfaces;
using RestApi.Services;
using RestApi.Repository;
using RestApi.Entities;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseLazyLoadingProxies()
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    .LogTo(Console.WriteLine, LogLevel.Information));


builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IProductsService, ProductService>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUsersService, UserService>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IOrdersService, OrderService>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IOrdersDetailsService, OrderDetailService>();

builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.MaxDepth = 10;
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    try
    {
        dbContext.Database.OpenConnection();
        Console.WriteLine("Database connection established.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error connecting to the database: {ex.Message}");
    }
}

// Products

app.MapGet("/products", async (IProductsService productService) =>
{
    var products = await productService.GetProductsAsync();
    return Results.Ok(products);
});

app.MapGet("/products/{id}", async (IProductsService productService, int id) =>
{
    var product = await productService.GetProductByIdAsync(id);
    return product != null ? Results.Ok(product) : Results.NotFound();
});

app.MapPost("/products", async (IProductsService productService, Products product) =>
{
    await productService.AddProductAsync(product);
    return Results.Created($"/products/{product.id}", product);
});

app.MapPut("/products/{id}", async (IProductsService productService, int id, Products product) =>
{
    try {
        await productService.UpdateProductAsync(product);
    }catch(Exception e) {
        return Results.BadRequest(e.Message);
    }
    return Results.Ok("Updated");
});

app.MapDelete("/products/{id}", async (IProductsService productService, int id) =>
{
    try {
        await productService.DeleteProductAsync(id);
    }catch(Exception e) {
        return Results.BadRequest(e.Message);
    }
    return Results.Ok("Deleted");
    
});

// Users

app.MapGet("/users", async (IUsersService userService) =>
{
    var users = await userService.GetUserAsync();
    return Results.Ok(users);
});

app.MapGet("/users/{id}", async (IUsersService userService, int id) =>
{
    var user = await userService.GetUserByIdAsync(id);
    return user != null ? Results.Ok(user) : Results.NotFound();
});

app.MapPost("/users", async (IUsersService userService, Users user) =>
{
    await userService.AddUserAsync(user);
    return Results.Created($"/users/{user.id}", user);
});

app.MapPut("/users/{id}", async (IUsersService userService, int id, Users user) =>
{
    try {
        await userService.UpdateUserAsync(user);
    }catch(Exception e) {
        return Results.BadRequest(e.Message);
    }
    return Results.Ok("Updated");
});

app.MapDelete("/users/{id}", async (IUsersService userService, int id) =>
{
    try {
        await userService.DeleteUserAsync(id);
    }catch(Exception e) {
        return Results.BadRequest(e.Message);
    }
    return Results.Ok("Deleted");
    
});

// Orders

app.MapGet("/orders", async (IOrdersService orderService) =>
{
    var orders = await orderService.GetOrderAsync();
    return Results.Ok(orders);
});

app.MapGet("/orders/{id}", async (IOrdersService orderService, int id) =>
{
    var order = await orderService.GetOrderByIdAsync(id);
    return order != null ? Results.Ok(order) : Results.NotFound();
});

app.MapPost("/orders", async (IOrdersService orderService, Orders order) =>
{
    await orderService.AddOrderAsync(order);
    return Results.Created($"/orders/{order.id}", order);
});

app.MapPut("/orders/{id}", async (IOrdersService orderService, int id, Orders order) =>
{
    try {
        await orderService.UpdateOrderAsync(order);
    }catch(Exception e) {
        return Results.BadRequest(e.Message);
    }
    return Results.Ok("Updated");
});

app.MapDelete("/orders/{id}", async (IOrdersService orderService, int id) =>
{
    try {
        await orderService.DeleteOrderAsync(id);
    }catch(Exception e) {
        return Results.BadRequest(e.Message);
    }
    return Results.Ok("Deleted");
    
});

// OrderDetails

app.MapGet("/orderDetails", async (IOrdersDetailsService orderDetailService) =>
{
    var orderDetails = await orderDetailService.GetOrderDetailAsync();
    return Results.Ok(orderDetails);
});

app.MapGet("/orderDetails/{id}", async (IOrdersDetailsService orderDetailService, int id) =>
{
    var orderDetail = await orderDetailService.GetOrderDetailByIdAsync(id);
    return orderDetail != null ? Results.Ok(orderDetail) : Results.NotFound();
});

app.MapPost("/orderDetails", async (IOrdersDetailsService orderDetailService, OrdersDetails orderDetail) =>
{
    await orderDetailService.AddOrderDetailAsync(orderDetail);
    return Results.Created($"/orderDetails/{orderDetail.id}", orderDetail);
});

app.MapPut("/orderDetails/{id}", async (IOrdersDetailsService orderDetailService, int id, OrdersDetails orderDetail) =>
{
    try {
        await orderDetailService.UpdateOrderDetailAsync(orderDetail);
    }catch(Exception e) {
        return Results.BadRequest(e.Message);
    }
    return Results.Ok("Updated");
});

app.MapDelete("/orderDetails/{id}", async (IOrdersDetailsService orderDetailService, int id) =>
{
    try {
        await orderDetailService.DeleteOrderDetailAsync(id);
    }catch(Exception e) {
        return Results.BadRequest(e.Message);
    }
    return Results.Ok("Deleted");
    
});

app.Run();
