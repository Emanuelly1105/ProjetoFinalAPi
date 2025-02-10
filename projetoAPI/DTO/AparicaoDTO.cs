namespace projetoAPI.DTO
{
    public class AparicaoDTO
    {
        public int Id { get; set; }
        public string Propriedade { get; set; }
        public string Pasto { get; set; }
        public string Animal { get; set; }
        public string Situacao { get; set; }
        public string Observacao { get; set; }
        public string TransferirParaLote { get; set; }
        public DateTime DataTransferenciaLote { get; set; }
    }
}
