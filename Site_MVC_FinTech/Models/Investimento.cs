﻿using System;
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
        public long CartaoCredito { get; set; }
        public Pessoa pessoa { get; set; }
    }
    public class Pacote
    {
        [Key]
        public int IDPacote { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public double Valor { get; set; }
        [Required]
        public int QtdTotal { get; set; }
        public int QtdDisponivel { get; set; }
    }
}