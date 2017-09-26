using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site_MVC_FinTech.Models
{
    public class Cliente
    {
        [Key]
        public int IDCliente { get; set; }

        [DisplayName("Nome")]
        [StringLength(30, ErrorMessage = "O campo Nome permite no máximo 30 caracteres!")]
        [Required(ErrorMessage = "Digite o Nome")]
        public string nomeCliente { get; set; }

        [DisplayName("Endereço")]
        public string enderecoCliente { get; set; }

        [DisplayName("E-mail")]
        [StringLength(50)]
        [Required(ErrorMessage = "Digite o Email")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email inválido.")]
        public string emailCliente { get; set; }

        [DisplayName("Data Nascimento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Digite a Data de Nascimento")]
        public DateTime dtNascCLiente { get; set; }
    }
}