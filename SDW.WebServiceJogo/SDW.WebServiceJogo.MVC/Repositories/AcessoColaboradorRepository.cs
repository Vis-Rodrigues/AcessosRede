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
            var acesso = _context.Acessando.Include("Colaborador").SingleOrDefault(x => x.Colaborador.ColaboradorId == id);
            if(acesso == null)
            {
                return 0;
            }
            else
            {
                return acesso.AcessoColaboradorId;
            }
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

        public void Liberar(int id)
        {
            // Utilizamos o ID 01, pois é o colaborador Livre
            var acessoColaborador = FindViewById(id);
            acessoColaborador.Colaborador = _context.Colaboradores.Find(1);

            _context.Entry(acessoColaborador).State = System.Data.Entity.EntityState.Modified;

        }

        public void Update(AcessoColaborador acessoColaborador)
        {
            _context.Entry(acessoColaborador).State = System.Data.Entity.EntityState.Modified;

        }
        
    }
}