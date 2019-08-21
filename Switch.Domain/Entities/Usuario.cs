﻿using Switch.Domain.Enums;
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
        public virtual Identificacao Identificacao { get; set; } //Um para um
        public virtual StatusRelacionamento StatusRelacionamento { get; set; }
        public virtual ProcurandoPor ProcurandoPor { get; set; }        
        public virtual ICollection<Postagem> Postagens { get; set; } //Um para muitos       
        public virtual ICollection<UsuarioGrupo> UsuarioGrupos { get; set; }   //muito para muitos
        public virtual ICollection<LocalTrabalho> LocaisTrabalho { get; set; }
        public virtual ICollection<InstituicaoEnsino> InstituicoesEnsino { get; set; }
        public virtual ICollection<Amigo> Amigos { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }

        public Usuario()
        {
            Postagens = new List<Postagem>();
            UsuarioGrupos = new List<UsuarioGrupo>();
            LocaisTrabalho = new List<LocalTrabalho>();
            InstituicoesEnsino = new List<InstituicaoEnsino>();
            Amigos = new List<Amigo>();
        }

    }
}
