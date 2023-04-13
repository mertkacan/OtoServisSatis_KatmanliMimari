using OtoServisSatis.Data;
using OtoServisSatis.Service.Interfaces;
using OtoServisSatis.Service.SomutSýnýflar;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddTransient(typeof(IService<>), typeof(Service<>));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Admin/Login";         // Uygulamamýza kullanýcýlar nereden üye olucak demektir.
    x.AccessDeniedPath = "/AccessDenied"; // Eriþim engellendi hatasý demektir.
    x.LogoutPath= "/Admin/Logout";        // Çýkýþ adresini belirttim.
    x.Cookie.Name = "Admin";             // Oluþturduðum Cookie'nin adýný belirttim.
    x.Cookie.MaxAge=TimeSpan.FromDays(7); // Giriþ yapan kullanýcý 7 gün boyunca giriþ yapabilsin demektir.
    x.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();


app.MapControllerRoute(
           name: "admin",
           pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
         );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
