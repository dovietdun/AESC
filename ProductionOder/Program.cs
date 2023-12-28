using Microsoft.EntityFrameworkCore;
using ProductionOrder.Data;
using ProductionOrder.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ProductionOrderDbContext>(options =>
    options.UseSqlServer(@"Server=.\MSSQLSERVER01;Database=QuanLySanXuat;User Id=sa; Password=sa;Trusted_Connection=True;"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();
