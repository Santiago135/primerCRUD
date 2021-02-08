using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrimerCrud.Models
{
    public class Persona
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
    }

    public class Personas
    {
        public Personas()
        {
            this.ListaDePersonas = new List<Persona>();
        }
        public List<Persona> ListaDePersonas { get; set; }
    }

}