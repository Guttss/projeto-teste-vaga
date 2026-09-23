using Microsoft.EntityFrameworkCore;
using FrigorificoApi.Models;

namespace FrigorificoApi.Data
{
    public class AppDbContext : DbContext
    {
        // O construtor recebe as opções (qual banco usar, string de conexão)
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        // O DbSet representa a sua tabela no banco de dados
        public DbSet<LoteCarne> Lotes { get; set; }
    }
}