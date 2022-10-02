namespace Sei.Domain.Entities
{
    public class Protocolo
    {
        public long ProtocoloId { get; set; }
        public int UnidadeId { get; set; }
        public string ProtocoloFormatado { get; set; }
        public DateTime DataGeracao { get; set; }
        public Documento Documento { get; set; }
        public Unidade Unidade { get; set; }
    }
}