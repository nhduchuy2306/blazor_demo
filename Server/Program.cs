using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ServerLibrary.Dtos;
using ServerLibrary.Models;
using ServerLibrary.Repositories;
using ServerLibrary.Services;
using ServerLibrary.Services.impl;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AuthService", Version = "v1" });

    c.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme, securityScheme: new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter 'Bearer' [space] and then your token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            },
            new string[]{}
        }
    });
});

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    var issuer = configuration["ApiSettings:JwtOptions:Issuer"];
    var audience = configuration["ApiSettings:JwtOptions:Audience"];
    var secretKey = configuration["ApiSettings:JwtOptions:SecretKey"];

    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey ?? ""))
    };
});

services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireClaim("role", "admin"));
    options.AddPolicy("Customer", policy => policy.RequireClaim("role", "customer"));
    options.AddPolicy("ShopEmployee", policy => policy.RequireClaim("role", "shopemployee"));
});

services.AddDbContext<ManagementdbContext>(opt =>
{
    var connectionString = configuration.GetConnectionString("ManagementDB");
    opt.UseSqlServer(connectionString, b => b.MigrationsAssembly("Server"));
});

services.AddCors(opt =>
{
    opt.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

services.Configure<JwtOptionsDTO>(configuration.GetSection("ApiSettings:JwtOptions"));

services.AddScoped<CustomerRepository>();
services.AddScoped<InvoiceDetailRepository>();
services.AddScoped<SalesInvoiceRepository>();
services.AddScoped<ProductRepository>();
services.AddScoped<WarehouseProductRepository>();
services.AddScoped<WarehouseRepository>();
services.AddScoped<MyTransaction>();
services.AddScoped<RoleRepository>();

services.AddScoped<ICustomerService, CustomerService>();
services.AddScoped<IInvoiceDetailService, InvoiceDetailService>();
services.AddScoped<ISalesInvoiceService, SalesInvoiceService>();
services.AddScoped<IProductService, ProductService>();
services.AddScoped<IWarehouseProductService, WarehouseProductService>();
services.AddScoped<IWarehouseService, WarehouseService>();
services.AddScoped<IRoleService, RoleService>();
services.AddScoped<ITokenService, TokenService>();

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
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Server v1"));
}

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
