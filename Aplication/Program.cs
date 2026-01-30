using Domínio.Interfaces;
using Domínio.Services;
using Infraestrutura.Contexts;
using Infraestrutura.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// DbContext
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// DI
builder.Services.AddScoped<IRepositorioReceita, RepositorioReceita>();
builder.Services.AddScoped<ReceitaService>();

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();