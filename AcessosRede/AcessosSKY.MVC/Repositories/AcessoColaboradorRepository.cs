using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SDW.WebServiceJogo.MVC.Models;
using SDW.WebServiceJogoAPI.Contexts;
using SDW.WebServiceJogoAPI.Models;

namespace SDW.WebServiceJogo.MVC.Repositories
{
    public class AcessoColaboradorRepository : IAcessoColaboradorRepository
    {
        private AcessoContext _context;

        public AcessoColaboradorRepository(AcessoContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            _context.Acessando.Remove(FindViewById(id));
        }

        public AcessoColaborador FindViewById(int id)
        {
            return (AcessoColaborador)_context.Acessando.Include("Acesso").Include("Colaborador").SingleOrDefault(x => x.AcessoColaboradorId == id);
        }

        public int FindIdByColaborador(int id)
        {
            return _context.Acessando.Include("Colaborador").SingleOrDefault(x => x.Colaborador.ColaboradorId == id).AcessoColaboradorId;
        }

        public int FindIdByAcesso(int id)
        {
            return _context.Acessando.Include("Acesso").SingleOrDefault(x => x.Acesso.AcessoId == id).AcessoColaboradorId;
        }

        public void Insert(AcessoColaborador acessando)
        {
            _context.Acessando.Add(acessando);
        }

        public ICollection<AcessoColaborador> List()
        {
            return _context.Acessando.Include("Acesso").Include("Colaborador").OrderBy(x => x.Acesso.IP).ToList();
        }

        public void Update(AcessoColaborador acessoColaborador)
        {
            Colaborador colaborador = new Colaborador(acessoColaborador.Colaborador.ColaboradorId, acessoColaborador.Colaborador.Nome);
            Acesso acesso = new Acesso();
            acesso.AcessoId = acessoColaborador.Acesso.AcessoId;
            acesso.IP = acessoColaborador.Acesso.IP;
            acesso.Usuario = acessoColaborador.Acesso.Usuario;
            acesso.Senha = acessoColaborador.Acesso.Senha;

            Delete(acessoColaborador.AcessoColaboradorId);

            AcessoColaborador ac = new AcessoColaborador();
            ac.Acesso = acesso;
            ac.Colaborador = colaborador;

            Insert(acessoColaborador);
        }
    }
}