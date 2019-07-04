using Switch.Domain.Enums;

namespace Switch.Domain.Entities
{
    public class Identificacao
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        //um para um 
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public TipoDocumentoEnum TipoDocumento { get; set; }

    }
}
