using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Projet5ApplicationDotNet.Data;
using Projet5ApplicationDotNet.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<Projet5ApplicationDotNetUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Param�tres utilisateur.
    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@";

    // Param�tres des mots de passe.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 12;

    // Param�tres de verrouillage.
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
});
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Voitures}/{action=Index}/{id?}");
app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var userManager = services.GetRequiredService<UserManager<Projet5ApplicationDotNetUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    string roleName = "ADMIN";
    string adminEmail = "admin@express-voitures.fr";
    string adminPassword = "Admin126754?!"; 

    // 1. Création du rôle Admin s’il n’existe pas
    if (!await roleManager.RoleExistsAsync(roleName))
    {
        await roleManager.CreateAsync(new IdentityRole(roleName));
    }

    // 2. Création de l'utilisateur admin s’il n’existe pas
    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        var newAdmin = new Projet5ApplicationDotNetUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            TwoFactorEnabled = false,
            LockoutEnabled = false,
            AccessFailedCount = 0
        };

        var createResult = await userManager.CreateAsync(newAdmin, adminPassword);

        if (createResult.Succeeded)
        {
            // 3. Ajouter l'utilisateur au rôle Admin
            var user = await userManager.FindByEmailAsync(adminEmail);
            await userManager.AddToRoleAsync(user, roleName);
        }
        else
        {
            foreach (var error in createResult.Errors)
            {
                Console.WriteLine($"Erreur création compte admin : {error.Description}");
            }
        }
    }
}

app.Run();

