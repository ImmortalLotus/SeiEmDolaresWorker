namespace Sei.Domain.Entities
{
    public class Unidade
    {
        public int Id { get; set; }
        public string Sigla { get; set; }
        public int SecretariaId { get; set; }
        public string Ativo { get; set; }
        public Secretaria Secretaria { get; set; }
        public ICollection<Protocolo> ListaDeProtocolos { get; set; }
    }
}