using FrigorificoApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Adiciona os Controllers aos serviços
builder.Services.AddControllers();

// 2. Configura o Entity Framework para usar o Banco em Memória
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseInMemoryDatabase("FrigorificoDb")); // Configura o banco de dados em memória

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
