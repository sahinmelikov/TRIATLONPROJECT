using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using TriatlonProject;
using TriatlonProject.Models.Auth;
using TriatlonProject.Models;
using TriatlonProject.Services;
using TriatlonProject.Hubs;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<LanguageServices>();
builder.Services.AddScoped<TranslationService>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddHttpClient();
builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequiredLength = 8;
    opt.Password.RequireNonAlphanumeric = true;
    opt.Password.RequireDigit = true;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireUppercase = true;

    opt.User.RequireUniqueEmail = true;

    opt.Lockout.MaxFailedAccessAttempts = 3;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
    opt.Lockout.AllowedForNewUsers = true;
});
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));


builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddMvc()
	.AddViewLocalization()
	.AddDataAnnotationsLocalization(options=>
	options.DataAnnotationLocalizerProvider = (type, factory) => 
	{
		var assemblyName=new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
		return factory.Create(nameof(SharedResource),assemblyName.Name);
	});
builder.Services.AddSignalR(); // SignalR hizmetini ekleyin
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
	var supportedCultures = new List<CultureInfo>
{
	new CultureInfo("en-US"),
	new CultureInfo("tr-TR"),
	new CultureInfo("ru-RU"),
	new CultureInfo("az-AZ")
};
	options.DefaultRequestCulture = new RequestCulture(culture: "tr-TR", uiCulture: "tr-TR");
	options.SupportedCultures = supportedCultures;
	options.SupportedUICultures = supportedCultures;
	options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());

});

// Entity Framework Core kullanarak veritabaný baðlantýsýný yapýlandýrýn
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:Default"]);
    options.EnableSensitiveDataLogging();
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
app.UseRouting();
app.UseAuthorization();
app.UseAuthentication(); // Bu satýrýn ekli olduðundan emin olun

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
         name: "areas",
         pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapDefaultControllerRoute();
    endpoints.MapHub<ChatHub>("/chathub"); // SignalR hub route tanýmý
});
app.Run();
