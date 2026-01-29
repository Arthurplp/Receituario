using Microsoft.EntityFrameworkCore;
using Domínio.Services;
using Domínio.Interfaces;
using Infraestrutura.Repositorios;
using Infraestrutura.Contexts;

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

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
