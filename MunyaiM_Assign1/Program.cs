using MunyaiM_Assign1.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// **** Configure services ****
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IEventRespository, EventRepository>();

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

//Indicates the Index page is inside the Event Controller
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Event}/{action=Index}/{id?}") ;

SeedData.EnsurePopulated(app);

app.Run();