using SDW.WebServiceJogo.MVC.Models;
using SDW.WebServiceJogo.MVC.UnitsofWorks;
using SDW.WebServiceJogoAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDW.WebServiceJogo.MVC.Controllers
{
    public class AcessoColaboradorController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        // GET: AcessoColaborador
        public ActionResult Listar()
        {
            return View(_unit.AcessoColaboradorRepository.List());
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            ViewBag.colaboradores = new SelectList(_unit.ColaboradorRepository.Listar(), "ColaboradorId", "Nome");
            return View(_unit.AcessoColaboradorRepository.FindViewById(id));
        }

        [HttpPost]
        public ActionResult Editar(AcessoColaborador acessoColaborador)
        {
            Colaborador colaborador = new Colaborador();
            Acesso acesso = new Acesso();
            colaborador = _unit.ColaboradorRepository.FindById(acessoColaborador.Colaborador.ColaboradorId);
            acesso = _unit.AcessoRepository.FindById(acessoColaborador.Acesso.AcessoId);
   
            _unit.AcessoColaboradorRepository.Delete(acessoColaborador.AcessoColaboradorId);
            _unit.Save();

            AcessoColaborador ac = new AcessoColaborador();
            ac.Acesso = acesso;
            ac.Colaborador = colaborador;

            _unit.AcessoColaboradorRepository.Insert(ac);
            _unit.Save();

            TempData["msg"] = "Acesso Atualizado com Sucesso!";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Liberar(int id)
        {
            AcessoColaborador acessoColaborador = new AcessoColaborador();
            acessoColaborador = _unit.AcessoColaboradorRepository.FindViewById(id);

            Acesso acesso = new Acesso();
            acesso = _unit.AcessoRepository.FindById(acessoColaborador.Acesso.AcessoId);

            _unit.AcessoColaboradorRepository.Delete(acessoColaborador.AcessoColaboradorId);
            _unit.Save();

            AcessoColaborador ac = new AcessoColaborador();
            ac.Acesso = acesso;
            ac.Colaborador = _unit.ColaboradorRepository.FindById(1);

            _unit.AcessoColaboradorRepository.Insert(ac);
            _unit.Save();

            TempData["msg"] = "Acesso Liberado com Sucesso!";
            return RedirectToAction("Listar");
        }
    }
}