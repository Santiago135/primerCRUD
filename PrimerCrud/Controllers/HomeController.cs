using PrimerCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using PrimerCrud.Filtros;

namespace PrimerCrud.Controllers
{
    public class HomeController : Controller
    {
        [FiltroDeSession]
        public ActionResult Index()
        {
            ServicioBaseDeDatos service = new ServicioBaseDeDatos();
            List<Persona> lista =  service.ListaPersonas();

            return View(lista);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}