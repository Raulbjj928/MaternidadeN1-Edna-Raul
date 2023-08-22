namespace MaternidadeN1_Edna_Raul.Models
{
    public class RecemNascidoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public int Peso { get; set; }
        public int Altura { get; set; }
        public string TipoDeParto { get; set; } = string.Empty;
        public int Apgar { get; set; }
        public string CondicaoMedica { get; set; } = string.Empty;
        public int MaeId { get; set; }
        public MaeModel Mae { get; set; }
    }
}
