using SDW.WebServiceJogoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDW.WebServiceJogo.MVC.Models
{
    public class AcessoColaborador
    {
        public int AcessoColaboradorId { get; set; }

        public Acesso Acesso { get; set; }

        public Colaborador Colaborador { get; set; }
    }
}