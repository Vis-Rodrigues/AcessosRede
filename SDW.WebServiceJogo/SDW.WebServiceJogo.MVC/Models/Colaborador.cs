using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SDW.WebServiceJogoAPI.Models
{
    public class Colaborador
    {
        public int ColaboradorId { get; set; }

        [Required]
        [MaxLength(50)]
        public String Nome { get; set; }

        public Colaborador(int colaboradorId, String nome)
        {
            Nome = nome;
            ColaboradorId = colaboradorId;
        }

        public Colaborador()
        {
        }

    }
}