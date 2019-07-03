﻿using System;

namespace Switch.Domain.Entities
{
    public class Postagem
    {
        public int Id { get; set; }

        public DateTime DataPublicacao { get; set; }

        public string Texto { get; set; }

        //um para muitos 
        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
        
    }
}
