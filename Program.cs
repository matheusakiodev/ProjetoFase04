using WebAppCap7.Helpers;
using WebAppCap7.Services;

var builder = WebApplication.CreateBuilder(args);

// Agrega OracleDbHelper al contenedor
builder.Services.AddSingleton(new OracleDbHelper(
builder.Configuration.GetConnectionString("OracleConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<UserService>();


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
