using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PrimerCrud.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public int? IdTipoUsuario { get; set; }
        [Display(Name = "User")]
        public string User { get; set; }
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }
        public IEnumerable<SelectListItem> tiposDeUsuario { get; set; }
        public string UserType { get; set; }

    }

    public class Usuarios
    {
        public Usuarios()
        {
            this.ListaDeUsuarios = new List<Usuario>();
        }
        public List<Usuario> ListaDeUsuarios { get; set; }
    }
}