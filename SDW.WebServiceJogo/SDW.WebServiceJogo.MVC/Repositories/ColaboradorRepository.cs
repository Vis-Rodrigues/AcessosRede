using SDW.WebServiceJogo.MVC.Models;
using SDW.WebServiceJogoAPI.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDW.WebServiceJogoAPI.Models.Abstract
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private AcessoContext _context;

        public ColaboradorRepository(AcessoContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            _context.Colaboradores.Remove(_context.Colaboradores.Find(id));
        }

        public Colaborador FindById(int id)
        {
            return (Colaborador) _context.Colaboradores.Find(id);
        }

        public void Insert(Colaborador colaborador)
        {
            _context.Colaboradores.Add(colaborador);
           
        }

        public ICollection<Colaborador> List()
        {
            return _context.Colaboradores.Where(x => x.Nome!=("Livre")).OrderBy(x => x.Nome).ToList();
        }

        public ICollection<Colaborador> Listar()
        {
            ICollection<Colaborador> lstColaborador = new List<Colaborador>();
            lstColaborador = _context.Colaboradores.OrderBy(x => x.Nome).ToList();

            foreach (AcessoColaborador ac in _context.Acessando.Include("Colaborador").ToList())
            {
                foreach(Colaborador c in _context.Colaboradores.ToList())
                {
                    if(c.ColaboradorId == ac.Colaborador.ColaboradorId)
                    {
                        lstColaborador.Remove(c);
                    }
                }
            }
            return lstColaborador;
        }
    }
}