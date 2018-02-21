using SDW.WebServiceJogo.MVC.UnitsofWorks;
using SDW.WebServiceJogoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDW.WebServiceJogo.MVC.Controllers
{
    public class ColaboradorController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        // GET: Colaborador
        public ActionResult Cadastrar()
        {
            var lista = _unit.ColaboradorRepository.List();
            return View(lista);
        }

        [HttpPost]
        public ActionResult Cadastrar(Colaborador colaborador)
        {
            var lstColaborador = _unit.ColaboradorRepository.List();
            
            if(lstColaborador.Any(x => x.Nome.Equals(colaborador.Nome)))
            {
                TempData["msg"] = "Colaborador já cadastrado!";
                return View(lstColaborador);
            }
            else
            {
                _unit.ColaboradorRepository.Insert(colaborador);
                _unit.Save();

                TempData["msg"] = "Colaborador Cadastrado com sucesso!";
                var lista = _unit.ColaboradorRepository.List();
                return View(lista);
            }
           
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var acessoColaborador = _unit.AcessoColaboradorRepository.FindIdByColaborador(id);
            if(acessoColaborador != 0)
            {
                _unit.AcessoColaboradorRepository.Liberar(acessoColaborador);
                _unit.Save();
            }
           
            _unit.ColaboradorRepository.Delete(id);
            _unit.Save();

            TempData["msg"] = "Colaborador Excluido com sucesso!";
            return RedirectToAction("Cadastrar");
        }
        
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _unit.Dispose();
        }
    }
}