using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrimerCrud.Models
{
    public class UsuarioComboBox
    {
        public IEnumerable<SelectListItem> tiposDeUsuario { get; set; }
    }
}