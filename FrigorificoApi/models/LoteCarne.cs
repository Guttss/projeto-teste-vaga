namespace FrigorificoApi.Models
{
    public class LoteCarne
    {
        public int Id { get; set; }
        public string codigoRastreio { get; set; } = string.Empty;
        public string tipoCorte { get; set; } = string.Empty;
        public decimal pesoKgg { get; set; }
        public DateTime dataEntrada { get; set; }
    }
}