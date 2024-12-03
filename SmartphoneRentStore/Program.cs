using Microsoft.AspNetCore.Mvc;
using SmartphoneRentStore.Extensions.DependencyInjection;
using SmartphoneRentStore.ModelBinders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationidentity(builder.Configuration);

builder.Services.AddControllersWithViews(options =>
{
    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>(); // Validation of tokens. Protection of csv attacks
});

builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Smartphone Details",
        pattern: "/Smartphone/Details/{id}/{information}",
        defaults: new { Controller = "Smartphone", Action = "Details"}
        );
    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});



await app.RunAsync();
