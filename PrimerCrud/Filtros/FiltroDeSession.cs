using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;
using PrimerCrud.Models;

namespace PrimerCrud.Filtros
{
    public class FiltroDeSession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Usuario sesionModel = (Usuario)context.HttpContext.Session.Contents["User"];
            //if not in DB
            if (sesionModel == null)
            {

                RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
                redirectTargetDictionary.Add("action", "Inicio");
                redirectTargetDictionary.Add("controller", "Inicio");
                redirectTargetDictionary.Add("area", "");

                context.Result = new RedirectToRouteResult(redirectTargetDictionary);
            }

            base.OnActionExecuting(context);
        }
    }
}