using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site_MVC_FinTech.Models
{
    public class Pessoa
    {
        [Key]
        public int IDPessoa { get; set; }

        [DisplayName("Nome Completo")]
        [StringLength(30, ErrorMessage = "O campo Nome permite no máximo 30 caracteres!")]
        [Required]
        public string NomeCompleto { get; set; }

        [DisplayName("CPF")]
        [Required]
        [Range(1, 99999999999, ErrorMessage = "Não pode ter mais que 11 digitos!")]
        public long Cpf { get; set; }

        [DisplayName("E-mail")]
        [StringLength(30)]
        [Required]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email inválido.")]
        public string Email { get; set; }

        [DisplayName("Idade")]
        [Range(1, 120)]
        [Required]
        public int Idade { get; set; }

        [DisplayName("Usuário")]
        [StringLength(30, ErrorMessage = "O campo Usuário permite no máximo 30 caracteres!")]
        [Required]
        public string Usuario { get; set; }

        [DisplayName("Senha")]
        [StringLength(15, ErrorMessage = "O campo Senha permite no máximo 15 caracteres!")]
        [Required]
        public string Senha { get; set; }

        public bool Sta_Adm { get; set; }
    }
}