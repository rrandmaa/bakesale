using BakeSale.Repositories;
using BakeSale.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

const string AllowAllOrigins = "_allowAllorigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<BakeSaleContext>(options =>
        options.UseInMemoryDatabase("BakeSale")
    );
}
else
{
    builder.Services.AddDbContext<BakeSaleContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
    );
}

// Add repositories for dependency injection

builder.Services.AddScoped<ISalesRepository, SalesRepository>();
builder.Services.AddScoped<IPurchasesRepository, PurchasesRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
        $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
}); ;

// Add a CORS policy

builder.Services.AddCors(policies => policies.AddPolicy(AllowAllOrigins, builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// seed the database with data

using (var scope = app.Services.CreateAsyncScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BakeSaleContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(AllowAllOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
