using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site_MVC_FinTech.Models
{
    public class Noticia
    {
        [Key]
        public int IDNoticia { get; set; }

        [DisplayName("Titulosdfsdfsdfsdfsdf")]
        [StringLength(50, ErrorMessage = "O campo Nome permite no máximo 50 caracteres!")]
        [Required(ErrorMessage = "Digite o Titulo")]
        public string Titulo { get; set; }

        [DisplayName("Matéria")]
        [StringLength(2000, ErrorMessage = "O campo Nome permite no máximo 2000 caracteres!")]
        [Required(ErrorMessage = "Digite a Matéria")]
        public string Materia { get; set; }

        [DisplayName("Imagem")]
        public string Imagem { get; set; }

        [DisplayName("Data Matéria")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Digite a Data da Matéria")]
        public DateTime DataMateria { get; set; }

        public bool Sta_Ativo { get; set; }

        //public <Categoria> Categorias {get; set;}

     }
}