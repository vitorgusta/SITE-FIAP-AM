using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site_MVC_FinTech.Models
{
    public class Contato
    {
        [Key]
        public int IDContato { get; set; }

        [DisplayName("Nome")]
        [StringLength(30, ErrorMessage = "O campo Nome permite no máximo 30 caracteres!")]
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string NomeContato { get; set; }

        [DisplayName("E-mail")]
        [StringLength(50, ErrorMessage = "O campo Nome permite no máximo 50 caracteres!")]
        [Required(ErrorMessage = "O campo Email é obrigatório")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email inválido.")]
        public string EmailContato { get; set; }

        [DisplayName("Mensagem")]
        [StringLength(255, ErrorMessage = "Você ultrapassou a quantidade máxima de caracteres, 255!")]
        [Required(ErrorMessage = "O campo Mensagem é obrigatório")]
        public string Mensagem { get; set; }

        [DisplayName("Data Mensagem")]
        [Required(ErrorMessage = "O campo Data é obrigatório")]
        public DateTime DataMensagem { get; set; }
    }
}