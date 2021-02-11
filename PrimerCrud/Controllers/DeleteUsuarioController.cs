using PrimerCrud.Filtros;
using PrimerCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrimerCrud.Controllers
{
    public class DeleteUsuarioController : Controller
    {
        // GET: DeleteUsuario
        [FiltroDeAdmin]
        public ActionResult DeleteUsuario(Usuario usuario)
        {
            Usuario user = new Usuario();
            user.Id = usuario.Id;
            user.User = usuario.User;
            user.Contraseña = usuario.Contraseña;
            user.IdPersona = usuario.IdPersona;
            user.IdTipoUsuario = usuario.IdTipoUsuario;

            try
            {
                ServicioBaseDeDatos servicio = new ServicioBaseDeDatos();
                servicio.EliminarUsuario(user);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return Redirect(Url.Content("~/Inicio/"));
        }
    }
}