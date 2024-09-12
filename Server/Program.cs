using Microsoft.EntityFrameworkCore;
using ServerLibrary.Models;
using ServerLibrary.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<ManagementdbContext>(
    opt =>
    {
        var connectionString = builder.Configuration.GetConnectionString("ManagementDB");
        opt.UseSqlServer(connectionString);
    }
);
builder.Services.AddCors(opt => 
{
    opt.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Add dependency injection
builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddScoped<InvoiceDetailRepository>();
builder.Services.AddScoped<SalesInvoiceRepository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<WarehouseProductRepository>();
builder.Services.AddScoped<WarehouseRepository>();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IInvoiceDetailService, InvoiceDetailService>();
builder.Services.AddScoped<ISalesInvoiceService, SalesInvoiceService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IWarehouseProductService, WarehouseProductService>();
builder.Services.AddScoped<IWarehouseService, WarehouseService>();

var app = builder.Build();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
