using Biblioteca.BackEnd.Application.Services.Biblioteca;
using Biblioteca.BackEnd.Infrastructure.Data.EntityFramework;
using Biblioteca.BackEnd.Infrastructure.Data.Repositories;
using Biblioteca.BackEnd.Infrastructure.Framework.RepositoryPattern;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Inyeccion dependencias
builder.Services.AddDbContext<BibliotecaDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Registrar servicios Application
builder.Services.AddScoped<ILibrosService, LibrosService>();
builder.Services.AddScoped<IAutorService, AutorService>();

//Registrar repositorio genérico y se indica que use el contexto de BibliotecaDbContext
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IRepositoryBiblioteca<>), typeof(RepositoryBiblioteca<>));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
