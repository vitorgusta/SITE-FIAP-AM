using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site_MVC_FinTech.Models
{
    public class Produto
    {
        [Key]
        public int IDProduto { get; set; }

        [DisplayName("Titulo")]
        [StringLength(50, ErrorMessage = "O campo Nome permite no máximo 50 caracteres!")]
        [Required(ErrorMessage = "O campo Titulo é obrigatório")]
        public string Titulo { get; set; }

        [DisplayName("Texto")]
        [StringLength(2000, ErrorMessage = "O campo Nome permite no máximo 2000 caracteres!")]
        [Required(ErrorMessage = "O campo Matéria é obrigatório ")]
        public string Texto { get; set; }
    }
}