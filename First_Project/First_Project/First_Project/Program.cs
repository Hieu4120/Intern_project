using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using First_Project.Data;
var builder = WebApplication.CreateBuilder(args);
/*builder.Services.AddDbContext<First_ProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("First_ProjectContext") ?? throw new InvalidOperationException("Connection string 'First_ProjectContext' not found.")));
*/
builder.Services.AddDbContext<First_ProjectContext>(options =>
    options.UseOracle(@"User Id=hieu;Password=hieu;Data Source=localhost:1521/Project"));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=ES_YDENPYO1}/{action=Index}/{id?}");

app.Run();
