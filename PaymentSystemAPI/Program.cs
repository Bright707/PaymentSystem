using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PaymentSystemAPI.Data;
using PaymentSystemAPI.Interfaces.IRepositories;
using PaymentSystemAPI.Interfaces.IServices;
using PaymentSystemAPI.Models;
using PaymentSystemAPI.Profiles.AutoMappings;
using PaymentSystemAPI.Repository;
using PaymentSystemAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IBaseRepository<Merchant>,MerchantRepository>();
builder.Services.AddScoped<IMerchantService, MerchantService>();
builder.Services.AddScoped<IBaseRepository<Customer>, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(PaymentAPIMappings));

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Defualt")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
}

app.UseHttpsRedirection();
    app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
