namespace Sei.Domain.Entities
{
    public class Documento
    {
        public long DocumentoId { get; set; }
        public Protocolo Protocolo { get; set; }
        public ConteudoDoDocumento ConteudoDoDocumento { get; set; }
    }
}