using PrimerCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrimerCrud.Controllers
{
    public class MiPerfilController : Controller
    {
        // GET: MiPerfil
        public ActionResult MiPerfil(int Id)
        {
            ServicioBaseDeDatos servicio = new ServicioBaseDeDatos();
            Usuario usuario = servicio.CargarUsuarioPorId(Id);
            return View(usuario);
        }
    }
}