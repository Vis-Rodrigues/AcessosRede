using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDW.WebServiceJogo.MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(String Senha)
        {
            if (Senha == "kdeabexiga@07")
            {
                return RedirectToAction("Listar", "AcessoColaborador");
            }
            else
            {
                TempData["msg"] = "Senha Incorreta!";
            }
            return View();


        }
    }
}