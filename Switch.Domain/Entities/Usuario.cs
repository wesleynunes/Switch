using Switch.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Switch.Domain.Entities
{
    public class Usuario
    {
        //public int Id { get; private set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Sobrenome é obrigatório")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo Data de Nacimento é obrigatório")]
        [DataType(DataType.Date)]
        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
              
        [DisplayName("Sexo")]
        public SexoEnum Sexo { get; set; }

        [DisplayName("Foto")]
        public string UrlFoto { get; set; }       

        [Required(ErrorMessage = "O campo Tipo de Usuário é obrigatório")]
        [DisplayName("Tipo de usuário ")]
        public TipoUsuario TipoUsuarios { get; set; }

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
