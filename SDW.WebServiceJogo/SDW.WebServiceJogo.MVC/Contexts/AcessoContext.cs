
using SDW.WebServiceJogo.MVC.Models;
using SDW.WebServiceJogoAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SDW.WebServiceJogoAPI.Contexts
{
    public class AcessoContext : DbContext
    {
        public DbSet<Colaborador> Colaboradores { get; set; }

        public DbSet<Acesso> Acessos { get; set; }

        public DbSet<AcessoColaborador> Acessando { get; set; }

    }
}