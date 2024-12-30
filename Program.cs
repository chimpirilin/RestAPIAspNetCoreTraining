using RestApi.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var users = new List<Users>();

app.MapGet("/", () => "Usuarios endpoint"); 

app.MapGet("/user", (int id) => {
    var user = users.Where(u => u.Id == id).FirstOrDefault();
    if(user == null) return Results.BadRequest("no se encontro el ususario");
    return Results.Ok($"Nombre: {user.Name}, Email: {user.Email}, Phone: {user.Phone}");
})
.WithName("GetUser")
.WithOpenApi();

app.MapPost("/user", (string name, string email, string phone) => {
    var user = new Users(name, email, phone);
    users.Add(user);
    return Results.Ok($"Usuario creado ID: {user.Id} Nombre: {user.Name}, Email: {user.Email}, Phone: {user.Phone}");
})
.WithName("PostUsers")
.WithOpenApi();

app.MapPut("/user", (int id, string name, string email, string phone) => {
    var user = users.Where(u => u.Id == id).FirstOrDefault();
    if(user == null) return Results.BadRequest("no se encontro el ususario");
    user.Name = name;
    user.Email = email;
    user.Phone = phone;
    return Results.Ok($"Usuario actualizado ID: {user.Id} Nombre: {user.Name}, Email: {user.Email}, Phone: {user.Phone}");
})
.WithName("PutUsers")
.WithOpenApi();

app.MapDelete("/user", (int id) => {
    var user = users.Where(u => u.Id == id).FirstOrDefault();
    if(user == null) return Results.BadRequest("no se encontro el ususario");
    users.Remove(user);
    return Results.Ok($"Usuario {user.Name} eliminado");
})
.WithName("DeleteUsers")
.WithOpenApi();

app.Run();
