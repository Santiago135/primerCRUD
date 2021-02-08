using PrimerCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrimerCrud.Filtros;

namespace PrimerCrud.Controllers
{
    public class UsuariosController : Controller
    {
        //GET: Usuarios
        //Verifica que la persona exista
        public ActionResult Usuarios()
        {
            Persona persona = new Persona();
            return View(persona);
        }
        //Crea el usuario
        public ActionResult CrearUsuario()
        {
            Usuario usuario = new Usuario();
            UsuarioComboBox combo = new UsuarioComboBox();
            ServicioBaseDeDatos servicio = new ServicioBaseDeDatos();
            List<TipoDeUsuario> lista = servicio.GetTiposDeUsuariosComboBox();

            combo.tiposDeUsuario = lista.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.Tipo.ToString()
            });
            usuario.tiposDeUsuario = combo.tiposDeUsuario;

            return View(usuario);
        }

        //Muestra los usuarios
        [FiltroDeSession]
        public ActionResult MostrarUsuarios()
        {
            //ServicioBaseDeDatosUsuarios servicio = new ServicioBaseDeDatosUsuarios();
            //TipoDeUsuario tipo = new TipoDeUsuario();
            //List<Usuario> lista = servicio.ListaUsuarios();

            //return View(lista);

            ServicioBaseDeDatos service = new ServicioBaseDeDatos();
            List<TipoDeUsuario> listatipo = service.GetTipoDeUsuarios();
            List<Usuario> listaU = service.GetUsuarios();
            foreach (var item in listaU)
            {
                if (item.IdTipoUsuario != null)
                {
                    item.UserType = listatipo.Where(x => x.id == item.IdTipoUsuario).FirstOrDefault().Nombre;
                    
                }
            }
            return View(listaU);
        }

        [HttpPost]
        public ActionResult CrearUsuario(int Id, Usuario user1)
        {
            ServicioBaseDeDatosUsuarios servicio = new ServicioBaseDeDatosUsuarios();

            Usuario usuario = new Usuario();
            usuario.Id = user1.Id;
            usuario.IdPersona = Id;
            usuario.IdTipoUsuario = user1.IdTipoUsuario;
            usuario.UserType = user1.UserType;
            usuario.User = user1.User;
            usuario.Contraseña = user1.Contraseña;
            servicio.CrearUsuario(usuario);

            return Redirect(Url.Content("~/Inicio/"));
        }
        [HttpPost]
        public ActionResult Usuarios(Persona persona)
        {
            ServicioBaseDeDatos servicio = new ServicioBaseDeDatos();
            List<Persona> lista = servicio.ListaPersonas();
            Persona personaEnCuestion = lista.Where(x => x.Nombre == persona.Nombre && x.Apellido == persona.Apellido).FirstOrDefault();
            if (personaEnCuestion == null)
            {
                return RedirectToAction("Inicio", "Inicio");
            }
            else
            {
                return RedirectToAction("CrearUsuario", "Usuarios", new { Id = personaEnCuestion.Id });
            }
        }
    }
}