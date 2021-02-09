using PrimerCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrimerCrud.Controllers
{
    public class ModifyUserController : Controller
    {
        // GET: ModifyUser
        public ActionResult ModifyUser(int Id)
        {
            ServicioBaseDeDatos servicio = new ServicioBaseDeDatos();
            Persona persona = servicio.CargarPersonaPorId(Id);
            return View(persona);
        }

        [HttpPost]
        public ActionResult ModifyUser(Persona persona)
        {
            Persona oUser = new Persona();
            oUser.Id = persona.Id;
            oUser.Nombre = persona.Nombre;
            oUser.Apellido = persona.Apellido;
            try
            {
                ServicioBaseDeDatos servicio = new ServicioBaseDeDatos();
                servicio.ModificarPersona(oUser);
            }
            catch (Exception ex) 
            {
                ex.ToString();
            }
           

            return Redirect(Url.Content("~/Inicio/"));
        }
    }
}