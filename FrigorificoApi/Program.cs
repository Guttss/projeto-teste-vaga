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

builder.Services.AddCors(options =>
    {
    options.AddPolicy("PermitirReact",
        policy =>
            {
                policy.WithOrigins("http://localhost:5173") // a porta do Vite
                .AllowAnyHeader()
                .AllowAnyHeader();
            });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("PermitirReact");
app.MapControllers();
app.Run();
