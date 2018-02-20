using SDW.WebServiceJogo.MVC.UnitsofWorks;
using System.Web.Mvc;
using SDW.WebServiceJogoAPI.Models;
using SDW.WebServiceJogo.MVC.Models;
using System.Diagnostics;

namespace SDW.WebServiceJogo.MVC.Controllers
{
    public class AcessoController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        // GET: Acesso
        public ActionResult Cadastrar()
        {         
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Acesso acesso)
        {
            _unit.AcessoRepository.Insert(acesso);
            _unit.Save();

            AcessoColaborador acessoColaborador = new AcessoColaborador();

            acessoColaborador.Acesso = acesso;
            acessoColaborador.Colaborador = _unit.ColaboradorRepository.FindById(1);
            Debug.WriteLine("Colaborador %s", acessoColaborador.Colaborador.Nome);
            _unit.AcessoColaboradorRepository.Insert(acessoColaborador);
            _unit.Save();

            TempData["msg"] = "Acesso Cadastrado com Sucesso!";
            return RedirectToAction("Listar", "AcessoColaborador");
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {            
            return View(_unit.AcessoRepository.FindById(id));
        }

        [HttpPost]
        public ActionResult Editar(Acesso acesso)
        {
            _unit.AcessoRepository.Update(acesso);
            _unit.Save();

            TempData["msg"] = "Acesso Atualizadp com Sucesso!";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            
            _unit.AcessoColaboradorRepository.Delete(_unit.AcessoColaboradorRepository.FindIdByAcesso(id));
            _unit.Save();
            _unit.AcessoRepository.Delete(id);
            _unit.Save();

            TempData["msg"] = "Acesso excluido com sucesso!";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Listar()
        {
            return View(_unit.AcessoRepository.list());
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _unit.Dispose();
        }
    }
}
