using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Teknoapp.business.Abstract;
using Teknoapp.business.Concrete;
using Teknoapp.data.Abstract;
using Teknoapp.data.Concrete.EfCore;
using Teknoapp.webui.Identity;

var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlite("Data Source = TeknoDb"));
    builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
    builder.Services.Configure<IdentityOptions>(options =>
 {
    //password
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;  
    
    //Lockout
    options.Lockout.MaxFailedAccessAttempts = 5;

    //
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedPhoneNumber= false;   
    options.SignIn.RequireConfirmedEmail= false;

});
    builder.Services.ConfigureApplicationCookie(options =>
    {
    options.LoginPath = "/account/login";
    options.LogoutPath = "/account/logout";
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.Cookie = new CookieBuilder
    {
       HttpOnly = true,
       Name=".TeknoApp.Security.Cookie"
    };
});
builder.Services.AddScoped<IProductRepository, EfCoreProductRepository>();
builder.Services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
builder.Services.AddScoped<ICartRepository, EfCoreCartRepository>();
builder.Services.AddScoped<IOrderRepository, EfCoreOrderRepository>();

builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICartService, CartManager>();
builder.Services.AddScoped<IOrderService, OrderManager>();
builder.Services.AddScoped<UserManager<User>>();
builder.Services.AddScoped<RoleManager<IdentityRole>>();
builder.Services.AddControllersWithViews(); 

var app = builder.Build();


// Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        SeedDatabase.Seed();
        app.UseDeveloperExceptionPage();
    }
    else
    {

        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(app =>
{
    app.MapControllerRoute(
    name: "orders",
    pattern: "orders",
    defaults: new { controller = "Cart", action = "GetOrders" }
    );
    app.MapControllerRoute(
    name: "checkout",
    pattern: "checkout",
    defaults: new { controller = "Cart", action = "Checkout" }
    );
    app.MapControllerRoute(
    name: "cart",
    pattern: "cart",
    defaults: new { controller = "Cart", action = "Index" }
    );

    app.MapControllerRoute(
    name: "adminusers",
    pattern: "admin/user/list",
    defaults: new { controller = "Admin", action = "UserList" }
    );
    app.MapControllerRoute(
    name: "adminuseredit",
    pattern: "admin/user/{id?}",
    defaults: new { controller = "Admin", action = "UserEdit" }
     );

    app.MapControllerRoute(
    name: "adminroles",
    pattern: "admin/role/list",
    defaults: new { controller = "Admin", action = "RoleList" }
    );
   app.MapControllerRoute(
   name: "adminrolecreate",
   pattern: "admin/role/create",
   defaults: new { controller = "Admin", action = "RoleCreate" }
   );
   app.MapControllerRoute(
   name: "adminroleedit",
   pattern: "admin/role/{id?}",
   defaults: new { controller = "Admin", action = "RoleEdit" }
   );

    app.MapControllerRoute(
    name: "admincategories",
    pattern: "admin/categories",
    defaults: new { controller = "Admin", action = "CategoryList" }
    );
    app.MapControllerRoute(
    name: "admincategorycreate",
    pattern: "admin/categories/create",
    defaults: new { controller = "Admin", action = "CategoryCreate" }
    );
    app.MapControllerRoute(
    name: "admincategoryedit",
    pattern: "admin/categories/{id?}",
    defaults: new { controller = "Admin", action = "CategoryEdit" }
    );
    app.MapControllerRoute(
    name: "adminproduct",
    pattern: "admin/products",
    defaults: new { controller = "Admin", action = "ProductList" }
    );
    app.MapControllerRoute(
    name: "adminproductcreate",
    pattern: "admin/products/create",
    defaults: new { controller = "Admin", action = "ProductCreate" }
    );
    app.MapControllerRoute(
    name: "adminproductedit",
    pattern: "admin/products/{id?}",
    defaults: new { controller = "Admin", action = "ProductEdit" }
    );
    app.MapControllerRoute(
    name: "search",
    pattern: "search",
    defaults: new { controller = "Tekno", action = "search" }
    );

    app.MapControllerRoute(
    name: "productdetails",
    pattern: "{url}",
    defaults: new { controller = "Tekno", action = "details" }
    );

    app.MapControllerRoute(
    name: "products",
    pattern: "products/{category?}",
    defaults: new {controller="Tekno",action= "list"}
    );

    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


});
app.Run();
