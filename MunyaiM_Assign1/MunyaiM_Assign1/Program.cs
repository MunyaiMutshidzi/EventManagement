using MunyaiM_Assign1.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// **** Configure services ****
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IEventRespository, EventRespository>();

//Database Option 1: SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Database Option 2: SQLite 
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// **** Configure middleware ****
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Event}/{action=Index}/{id?}") ;

SeedData.EnsurePopulated(app);

app.Run();