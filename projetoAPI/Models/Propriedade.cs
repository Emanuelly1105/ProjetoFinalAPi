namespace projetoAPI.Models
{
    public class Propriedade
    {
        public int Id { get; set; }
        public string NomePropriedade { get; set; }
        public string NomeProprietario { get; set; }
        public double TamanhoHectares { get; set; }
        public double CEP { get; set; }
        public double Logradouro { get; set; }
        public double Bairro { get; set; }
        public double Complemento { get; set; }
    }
}
