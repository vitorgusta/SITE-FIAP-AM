using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site_MVC_FinTech.Models
{
    public class Investidor
    {
        [Key]
        public int IDInvestidor { get; set; }
        [Required]
        [Range(1, 9999999999999999, ErrorMessage = "Digite o numero correto!")]
        public long CartaoCredito { get; set; }
        [Required]
        [Range(1, 51, ErrorMessage = "Digite a quantidade correta!")]
        public int Quantidade { get; set; }
        public decimal Total { get; set; }
        public Pessoa pessoa { get; set; }
        public Pacote pacote { get; set; }
    }
    public class Pacote
    {
        [Key]
        public int IDPacote { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal Valor { get; set; }
        [Required]
        public int QtdTotal { get; set; }
        public int QtdDisponivel { get; set; }
    }
}