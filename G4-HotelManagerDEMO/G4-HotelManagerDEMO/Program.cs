using G4_HotelManagerDEMO.Data;
using G4_HotelManagerDEMO.Repositories.RoomTypes;
using G4_HotelManagerDEMO.Repositories.Hotels;
using G4_HotelManagerDEMO.Repositories.Cliente;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
