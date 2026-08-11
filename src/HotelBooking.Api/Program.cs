using HotelBooking.Application.Interfaces;
using HotelBooking.Infrastructure.Persistence;
using HotelBooking.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using HotelBooking.Application.UseCases.Hotels.CreateHotel;
using HotelBooking.Application.UseCases.Hotels.GetHotels;
using HotelBooking.Application.UseCases.RoomTypes.CreateRoomType;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HotelBookingDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<CreateHotelHandler>();
builder.Services.AddScoped<GetHotelsHandler>();
builder.Services.AddSwaggerGen(); 
builder.Services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
builder.Services.AddScoped<CreateRoomTypeHandler>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddControllers();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();   // Serves the JSON endpoint
    app.UseSwaggerUI(); // Serves the HTML UI web page
}
app.MapControllers();

app.Run();