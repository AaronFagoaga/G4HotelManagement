using G4_HotelManagerDEMO.Data;
using G4_HotelManagerDEMO.Repositories.RoomTypes;
using G4_HotelManagerDEMO.Repositories.Hotels;
using G4_HotelManagerDEMO.Repositories.Cliente;
using G4_HotelManagerDEMO.Repositories.Employee;
using G4_HotelManagerDEMO.Repositories.Reservations;
using G4_HotelManagerDEMO.Repositories.Rooms;
using G4_HotelManagerDEMO.Services.Email;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Sql service:
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();

//Tables services:
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

//Mail services:
builder.Services.AddTransient<IEmailService, EmailService>();


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
