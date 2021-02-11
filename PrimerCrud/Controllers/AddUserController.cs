using PrimerCrud.Filtros;
using PrimerCrud.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrimerCrud.Controllers
{
    public class AddUserController : Controller
    {
        // GET: AddUser
        [FiltroDeSecretaria]
        public ActionResult AddUser()
        {
            Persona persona = new Persona();
          
            return View(persona);
        }

        [HttpPost]
        public ActionResult AddUser(Persona persona)
        {
                Persona oUser = new Persona();
                oUser.Nombre = persona.Nombre;
                oUser.Apellido = persona.Apellido;
            ServicioBaseDeDatos servicio = new ServicioBaseDeDatos();
            servicio.CrearPersona(oUser);

                

            return Redirect(Url.Content("~/Home/"));
        }
    }
}