using PrimerCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrimerCrud.Controllers
{
    public class ModifyUsuarioController : Controller
    {
        //public ActionResult ModifyUsuario(int Id)
        //{
        //    ServicioBaseDeDatos servicio = new ServicioBaseDeDatos();
        //    Usuario usuario = servicio.CargarUsuarioPorId(Id);

        //    return View(usuario);
        //}
        public ActionResult ModifyUsuario(int Id)
        {
            UsuarioComboBox combo = new UsuarioComboBox();
            ServicioBaseDeDatos servicio = new ServicioBaseDeDatos();
            Usuario usuario = servicio.CargarUsuarioPorId(Id);
            List<TipoDeUsuario> lista = servicio.GetTiposDeUsuariosComboBox();

            combo.tiposDeUsuario = lista.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.Tipo.ToString()
            });
            usuario.tiposDeUsuario = combo.tiposDeUsuario;

            return View(usuario);
        }


        [HttpPost]
        public ActionResult ModifyUsuario(Usuario usuario)
        {
            Usuario oUsuario = new Usuario();
            oUsuario.Id = usuario.Id;
            oUsuario.User = usuario.User;
            oUsuario.Contraseña = usuario.Contraseña;
            oUsuario.IdPersona = usuario.IdPersona;
            oUsuario.IdTipoUsuario = usuario.IdTipoUsuario;

            try
            {
                ServicioBaseDeDatos servicio = new ServicioBaseDeDatos();
                servicio.ModificarUsuario(oUsuario);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return Redirect(Url.Content("~/Inicio/"));
        }
    }
}