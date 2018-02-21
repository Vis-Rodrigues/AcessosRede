
using SDW.WebServiceJogo.MVC.Repositories;
using SDW.WebServiceJogoAPI.Contexts;
using SDW.WebServiceJogoAPI.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDW.WebServiceJogo.MVC.UnitsofWorks
{
    public class UnitOfWork : IDisposable
    {
        private AcessoContext _context2 = new AcessoContext();


        private IColaboradorRepository _colaboradorRepository;

        public IColaboradorRepository ColaboradorRepository
        {
            get
            {
                if (_colaboradorRepository == null)
                {
                    _colaboradorRepository = new ColaboradorRepository(_context2);
                }
                return _colaboradorRepository;
            }
        }

        private IAcessoRepository _acessoRepository;

        public IAcessoRepository AcessoRepository
        {
            get
            {
                if (_acessoRepository == null)
                {
                    _acessoRepository = new AcessoRepository(_context2);
                }
                return _acessoRepository;
            }
        }

        private IAcessoColaboradorRepository _acessoColaboradorRepository;

        public IAcessoColaboradorRepository AcessoColaboradorRepository
        {
            get
            {
                if (_acessoColaboradorRepository == null)
                {
                    _acessoColaboradorRepository = new AcessoColaboradorRepository(_context2);
                }
                return _acessoColaboradorRepository;
            }
        }

        public void Save()
        {
            _context2.SaveChanges();
        }

        private bool _disposed = false;

        public void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                _context2.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}