using PrimerCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrimerCrud.Filtros;

namespace PrimerCrud.Controllers
{
    public class MiPerfilController : Controller
    {
        // GET: MiPerfil
        [FiltroDeSession]
        public ActionResult MiPerfil()
        {
            Usuario usuario1 = (Usuario)Session["User"];
            return View(usuario1);
        }
    }
}