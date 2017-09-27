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
        [StringLength(200, ErrorMessage = "O campo Nome permite no máximo 200 caracteres!")]
        [Required(ErrorMessage = "Digite o Nome")]
        public string NomeCompleto { get; set; }

        [DisplayName("Endereço")]
        public string Endereco { get; set; }

        [DisplayName("E-mail")]
        [StringLength(200)]
        [Required(ErrorMessage = "Digite o Email")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email inválido.")]
        public string Email { get; set; }

        [DisplayName("Data Nascimento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Digite a Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [DisplayName("Usuário")]
        [StringLength(30, ErrorMessage = "O campo Usuário permite no máximo 30 caracteres!")]
        public string Usuario { get; set; }

        [DisplayName("Senha")]
        [StringLength(15, ErrorMessage = "O campo Senha permite no máximo 15 caracteres!")]
        public string Senha { get; set; }

        public bool Sta_Adm { get; set; }
    }
}