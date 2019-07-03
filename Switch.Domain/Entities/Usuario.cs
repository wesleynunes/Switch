using Switch.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Switch.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; private set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public DateTime DataNascimento { get; set; }

        public SexoEnum Sexo { get; set; }

        public string UrlFoto { get; set; }
        
        //Um para um
        public virtual Identificacao Identificacao { get; set; }

        //Um para muitos 
        public virtual ICollection<Postagem> Postagens { get; set; }

    }
}
