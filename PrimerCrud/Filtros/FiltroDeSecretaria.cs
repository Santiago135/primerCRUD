using PrimerCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PrimerCrud.Filtros
{
    public class FiltroDeSecretaria : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Usuario sessionModel = (Usuario)context.HttpContext.Session.Contents["User"];
            if(sessionModel.IdTipoUsuario == 1)
            {
                RouteValueDictionary redirect = new RouteValueDictionary();
                redirect.Add("action", "Inicio");
                redirect.Add("controller", "Inicio");
                redirect.Add("area", "");

                context.Result = new RedirectToRouteResult(redirect);
            }

            base.OnActionExecuting(context);
        }
    }
}