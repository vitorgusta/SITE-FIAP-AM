using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site_MVC_FinTech.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Descrição")]
        [StringLength(50, ErrorMessage = "O campo Categoria permite no máximo 50 caracteres!")]
        [Required(ErrorMessage = "O campo Categoria é obrigatório")]
        public String Descricao { get; set; }


        [DisplayName("Status")]
        [Required(ErrorMessage = "O campo Status é obrigatório")]
        public String StaAtivo { get; set; } 
    }
}