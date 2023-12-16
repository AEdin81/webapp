using Microsoft.FeatureManagement;
using webapp.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Endpoint=https://azureappconfig0503.azconfig.io;Id=HvL6;Secret=O/ilpcphflUl5zcgwSsGm87rsq0S7Ji3GZSCbVfsEPw=";

builder.Host.ConfigureAppConfiguration(build =>
{
    build.AddAzureAppConfiguration(options => options.Connect(connectionString).UseFeatureFlags());
});

builder.Services.AddTransient<IProductService, ProductService>();


// Add services to the container.

builder.Services.AddRazorPages();
builder.Services.AddFeatureManagement();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
