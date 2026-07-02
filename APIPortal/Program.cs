using AutoMapper;
using Capa_Datos.DataBaseContext;
using Capa_Datos.Repositorio;
using Capa_Datos.Repositorio.Contrato;
using Capa_Negocio.Servicios;
using Capa_Negocio.Servicios.Contrato;
using Capa_Utilidades;
using Inyeccion_Dependencias;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<CloudinaryService>();
builder.Services.InyectarDependencias(
    builder.Configuration
);


builder.Services.AddAutoMapper(typeof(Utilidades.AutoMapperProfile));
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("Angular",
        policy =>
        {
            policy
                .WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("Angular");
app.UseAuthorization();

app.MapControllers();

app.Run();
