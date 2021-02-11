using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrimerCrud.Models;
using PrimerCrud.Filtros;

namespace PrimerCrud.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            ServicioBaseDeDatosUsuarios servicio = new ServicioBaseDeDatosUsuarios();
            List<Usuario> lista = servicio.ListaUsuarios();
            Usuario usuarioEnCuestion = lista.Where(x => x.User == usuario.User && x.Contraseña == usuario.Contraseña).FirstOrDefault();
            if (usuarioEnCuestion == null)
            {
                return Redirect("~/");
            }
            else
            {
                Session["User"] = usuarioEnCuestion;
                if(usuarioEnCuestion.IdTipoUsuario == 1)
                {
                    return RedirectToAction("MiPerfil", "MiPerfil", new { Id = usuarioEnCuestion.Id});
                }
                else
                {
                    return Redirect("~/Usuarios/MostrarUsuarios");
                }
                
            }
        }

        public ActionResult Logout()
        {
            Session["User"] = null;
            return Redirect("~/Inicio");
        }
    }
}
