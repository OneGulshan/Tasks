using Customerproject.Rpository;
using Microsoft.EntityFrameworkCore;
using Studentproject.Repository;
using Tasks.Data;
using Tasks.IRepository;
using Tasks.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddRazorPagesOptions(options =>//Razor Page Routing Changed by Default Root Directory here
{
    options.RootDirectory = "/Pages";
});

builder.Services.AddRazorPages().WithRazorPagesRoot("/Pages");//With booth Links

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Con"));
});

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<ICustomer, Customer_Repository>();
builder.Services.AddTransient<ICountry, Country_Repository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
app.MapRazorPages();
app.MapControllerRoute(//Manually run, calling by Controller name
    name: "default",
    pattern: "{controller=CsvController}/{action=Index}/{id?}");

app.Run();
