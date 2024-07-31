using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region ConexionBD
builder.Services.AddDbContext<NorthWindContext>(options =>
                options.UseSqlServer
                                (builder.Configuration.GetConnectionString("DefaultConnection"))
                                );

builder.Services.AddDbContext<AuthDBContext>(options =>
                options.UseSqlServer
                                (builder.Configuration.GetConnectionString("DefaultConnection"))
                                );
#endregion


builder.Services.AddAuthentication();



#region Serilog

builder.Logging.ClearProviders();
    builder.Logging.AddConsole();
    builder.Host.UseSerilog((ctx, lc) =>lc
            .WriteTo.File("logs/logsbackend.txt",rollingInterval: RollingInterval.Day)
            .MinimumLevel.Error()
        
        );


#endregion


#region DI

builder.Services.AddDbContext<NorthWindContext>();

builder.Services.AddScoped<ICategoryDAL, CategoryDALImpl>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<ISupplierDAL, SupplierDALImpl>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDAL, ProductDALImpl>();

#endregion



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ApiKeyManager>();

app.UseAuthorization();

app.MapControllers();

app.Run();
