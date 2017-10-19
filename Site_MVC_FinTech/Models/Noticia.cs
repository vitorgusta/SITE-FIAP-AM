using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Site_MVC_FinTech.Models
{
    public class Noticia
    {
        [Key]
        public int IDNoticia { get; set; }

        [DisplayName("Titulo")]
        [StringLength(50, ErrorMessage = "O campo Nome permite no máximo 50 caracteres!")]
        [Required(ErrorMessage = "O campo Titulo é obrigatório")]
        public string Titulo { get; set; }

        [DisplayName("Matéria")]
        [StringLength(2000, ErrorMessage = "O campo Nome permite no máximo 2000 caracteres!")]
        [Required(ErrorMessage = "O campo Matéria é obrigatório ")]
        public string Materia { get; set; }

        [DisplayName("Imagem")]
        public string Image { get; set; }

        [DisplayName("Data Matéria")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "O campo Data da Matéria é obrigatório")]
        public DateTime DataMateria { get; set; }

        //public bool Sta_Ativo { get; set; }

        //public <Categoria> Categorias {get; set;}

    }
}