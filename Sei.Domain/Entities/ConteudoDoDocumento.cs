namespace Sei.Domain.Entities
{
    public class ConteudoDoDocumento
    {
        public long DocumentoId { get; set; }
        public string Conteudo { get; set; }
        public Documento Documento { get; set; }
    }
}
