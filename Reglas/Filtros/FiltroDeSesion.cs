using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace Reglas.Filtros
{
    public class FiltroDeSesion : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {



            PersonaFisicaModel pf = (PersonaFisicaModel)context.HttpContext.Session.Contents["PersonaFisica"];
            //if not in DB
            if (pf == null)
            {

                RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
                redirectTargetDictionary.Add("action", "SessionCaducada");
                redirectTargetDictionary.Add("controller", "Home");
                redirectTargetDictionary.Add("area", "");

                context.Result = new RedirectToRouteResult(redirectTargetDictionary);
            }

            base.OnActionExecuting(context);
        }
    }
}
