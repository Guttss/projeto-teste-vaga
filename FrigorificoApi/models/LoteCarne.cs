namespace FrigorificoApi.Models
{
    public class LoteCarne
    {
        public int Id { get; set; } // O Entity Framework entende 'Id' como Chave Primária automaticamente
        public string CodigoRastreio { get; set; } = string.Empty;
        public string TipoCorte { get; set; } = string.Empty;
        public decimal PesoKg { get; set; }
        public DateTime DataEntrada { get; set; }
    }
}