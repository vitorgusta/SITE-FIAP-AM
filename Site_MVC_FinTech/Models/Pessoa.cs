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
        [StringLength(50, ErrorMessage = "O campo Nome permite no máximo 50 caracteres!")]
        [Required(ErrorMessage = "O campo Nome Completo é obrigatório")]
        public string NomeCompleto { get; set; }

        [DisplayName("CPF")]
        [Required(ErrorMessage = "O campo CPF é obrigatório")]
        [Range(1, 99999999999, ErrorMessage = "Não pode ter mais que 11 digitos!")]
        public long Cpf { get; set; }

        [DisplayName("E-mail")]
        [StringLength(50, ErrorMessage = "O campo E-mail permite no máximo 50 caracteres!")]
        [Required(ErrorMessage = "O campo E-mail é obrigatório")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email inválido.")]
        public string Email { get; set; }

        [DisplayName("Idade")]
        [Range(1, 120, ErrorMessage = "Não pode ser menos que 1 e maior que 11 digitos!")]
        [Required(ErrorMessage = "O campo Idade é obrigatório")]
        public int Idade { get; set; }

        [DisplayName("Usuário")]
        [StringLength(15, ErrorMessage = "O campo Usuário permite no máximo 15 caracteres!")]
        [Required(ErrorMessage = "O campo Usuário é obrigatório")]
        public string Usuario { get; set; }

        [DisplayName("Senha")]
        [StringLength(15, ErrorMessage = "O campo Senha permite no máximo 15 caracteres!")]
        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        public string Senha { get; set; }

        public bool Sta_Adm { get; set; }
    }
}