using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SDW.WebServiceJogoAPI.Models
{
    public class Acesso
    {
        public int AcessoId { get; set; }

        [Required(ErrorMessage = "O IP é Obrigatório")]
       // [InputMask("999.99.999.999")]
        public String  IP { get; set; }

        [Required]
        public String Usuario { get; set; }

        [Required]
        public String Senha { get; set; }
    }
}