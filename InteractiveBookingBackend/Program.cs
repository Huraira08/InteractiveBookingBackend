using InteractiveBookingBackend.Data.Context;
using InteractiveBookingBackend.Data.Repositories;
using InteractiveBookingBackend.Web.Utility;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<InteractiveBookingContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"))
    );

builder.Services.AddCors();

builder.Services.AddSignalR().AddJsonProtocol(options =>
{
    options.PayloadSerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.AddScoped<IBookingRepository, BookingRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors( options =>
    options.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:4200")
    .AllowCredentials()
);

app.MapHub<BookingUpdateHub>("/updateBooking");

app.MapControllers();

app.Run();
