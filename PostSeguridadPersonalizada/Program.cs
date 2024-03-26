using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using PostSeguridadPersonalizada.Data;
using PostSeguridadPersonalizada.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options => options.EnableEndpointRouting = false).AddSessionStateTempDataProvider();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie();

string connectionString = builder.Configuration.GetConnectionString("SqlAllSports");
builder.Services.AddTransient<RepositoryDeportes>();
builder.Services.AddDbContext<DeportesContext>(options => options.UseSqlServer(connectionString));

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

//SI TENEMOS SEGURIDAD PERSONALIZADA DEBEMOS UTILIZAR 
app.UseMvc(routes =>
{
    routes.MapRoute(
         name: "default",
    template: "{controller=Deportes}/{action=deportes}/{id?}");
});

app.Run();
