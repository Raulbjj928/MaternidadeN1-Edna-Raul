namespace MaternidadeN1_Edna_Raul.Models
{
    public class MaeModel
    {
        public int? Id{ get; set; }     
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? RegistroGeral { get; set; }
        public string? CPF { get; set; }
        public string? Endereco { get; set; }
        public string? Telefone { get; set; }
        public string? EstadoCivil { get; set; }
        public string? Profissao { get; set; }
        public string? Etnia { get; set; }
        public string? HistoricoMedico { get; set; }

        public MaeModel()
        {
        }
    }
}
