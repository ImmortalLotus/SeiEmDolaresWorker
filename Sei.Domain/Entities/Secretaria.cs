namespace Sei.Domain.Entities
{
    public class Secretaria
    {
        public int OrgaoId { get; set; }
        public string Sigla { get; set; }
        public string Ativo { get; set; }

        public ICollection<Unidade> ListaDeUnidades { get; set; }
    }
}