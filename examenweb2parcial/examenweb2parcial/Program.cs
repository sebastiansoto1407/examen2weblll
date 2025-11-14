using examenweb2parcial.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Usando EF InMemory solo para pruebas/examen. Cambia a UseSqlServer para producción
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("GestorTareas"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
