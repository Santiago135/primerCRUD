using PrimerCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrimerCrud.Controllers
{
    public class DeleteUserController : Controller
    {
        // GET: DeleteUser
        

        
        public ActionResult DeleteUser(Persona persona)
        {
            Persona oUser = new Persona();
            oUser.Id = persona.Id;
            oUser.Nombre = persona.Nombre;
            oUser.Apellido = persona.Apellido;
            try
            {
                ServicioBaseDeDatos servicio = new ServicioBaseDeDatos();
                servicio.EliminarPersona(oUser);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }


            return Redirect(Url.Content("~/Home/"));
        }
    }
}