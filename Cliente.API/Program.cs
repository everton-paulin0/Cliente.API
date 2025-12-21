using Cliente.Application.Services;
using Cliente.Infrastructure;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// DbContext


var connectionString = builder.Configuration.GetConnectionString("ClienteDB");

builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer(connectionString));

// Services
builder.Services.AddScoped<IClientesServices, ClientsServices>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
