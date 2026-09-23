using Microsoft.EntityFrameworkCore;
using InLab.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar a conexão do DbContext com o SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionar serviços MVC aos contentores
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar o pipeline de pedidos HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();