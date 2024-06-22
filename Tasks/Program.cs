using Customerproject.Rpository;
using Microsoft.EntityFrameworkCore;
using Studentproject.Repository;
using Tasks.Data;
using Tasks.IRepository;
using Tasks.Repository;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.Extensions.Options;

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
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddMvc().AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix).
    AddDataAnnotationsLocalization();
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var cultures = new List<CultureInfo>
    {
        new("en"),
        new("fr"),
        new("hi")
    };
    options.DefaultRequestCulture = new RequestCulture("en");
    options.SupportedCultures = cultures;
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

app.UseAuthorization();
app.MapRazorPages();
//var cultures = new[] { "en", "fr", "hi" };
//var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(cultures[0])
//    .AddSupportedCultures(cultures)
//    .AddSupportedUICultures(cultures);
//app.UseRequestLocalization(localizationOptions);
app.UseRequestLocalization(app.Services.CreateScope().ServiceProvider.
    GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
app.MapControllerRoute(//Manually run, calling by Controller name
    name: "default",
    pattern: "{controller=CsvController}/{action=Index}/{id?}");

app.Run();
