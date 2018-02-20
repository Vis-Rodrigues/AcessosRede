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
            _unit.AcessoColaboradorRepository.Delete(_unit.AcessoColaboradorRepository.FindIdByColaborador(id));
            _unit.Save();
            _unit.ColaboradorRepository.Delete(id);
            _unit.Save();

            TempData["msg"] = "Colaborador Excluido com sucesso!";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Listar()
        {
            var lista = _unit.ColaboradorRepository.List();
            return View(lista);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _unit.Dispose();
        }
    }
}