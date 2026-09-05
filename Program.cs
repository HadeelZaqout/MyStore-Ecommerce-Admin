using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using MyStore.Data;
using MyStore.Models;
using MyStore.Options;
using MyStore.Repositories;
using MyStore.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<IUploadService, UploadImageService>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => options.LoginPath = "/login");
builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.Configure<SmtpOptions>(builder.Configuration.GetSection("SMTP"));
builder.Services.AddTransient<IEmailSender, EmailSender>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Edit",p=>p.RequireAssertion(context=>context.User.IsInRole("Admin") || context.User.IsInRole("Editor") || context.User.HasClaim("CanEdit","true")));
    options.AddPolicy("OnlyAdmin", p => p.RequireRole("Admin"));
    options.AddPolicy("Client",  p => p.RequireAuthenticatedUser() );
});


builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeAreaFolder("Identity","/Identity/Account/Manage");
    options.Conventions.AuthorizeFolder("/Categories","OnlyAdmin");
    options.Conventions.AuthorizePage("/Products/Create", "Edit");
    options.Conventions.AuthorizePage("/Products/Edit", "Edit");
    options.Conventions.AuthorizePage("/Products/Delete", "OnlyAdmin");
    options.Conventions.AuthorizePage("/Products/Index", "Client");
    options.Conventions.AuthorizePage("/Products/Images", "Edit");




});














var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication(); 

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
