using SDW.WebServiceJogo.MVC.Repositories;
using SDW.WebServiceJogoAPI.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDW.WebServiceJogoAPI.Models.Abstract
{
    public class AcessoRepository : IAcessoRepository
    {
        private AcessoContext _context;

        public AcessoRepository(AcessoContext context)
        {
            _context = context;
        }

        public Acesso FindById(int id)
        {
            return (Acesso)_context.Acessos.Find(id);
        }

        public void Insert(Acesso acesso)
        {
            _context.Acessos.Add(acesso);
        }

        public ICollection<Acesso> list()
        {
            return _context.Acessos.ToList();
        }

        public void Delete(int id)
        {
            _context.Acessos.Remove(FindById(id));
        }

        public void Update(Acesso acesso)
        {
            _context.Entry(acesso).State = System.Data.Entity.EntityState.Modified;
        }
    }
}