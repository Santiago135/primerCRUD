using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using PrimerCrud.Models;
using System.Web.Mvc;

namespace PrimerCrud.Filtros
{
    public class FiltroDeAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Usuario sessionModel = (Usuario)context.HttpContext.Session.Contents["User"];
            if(sessionModel.IdTipoUsuario != 3)
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