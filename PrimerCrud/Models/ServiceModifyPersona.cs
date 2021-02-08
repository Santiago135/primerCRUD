using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimerCrud.Models
{
    public class ServiceModifyPersona : Conexion
    {
        Persona personaAEditar;
        public ServiceModifyPersona(Persona persona)
        {
            this.personaAEditar = persona;
        }
        

        public Persona ModifyPersona()
        {

            try
            {
                Run();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                personaAEditar = null;
                return personaAEditar;
            }
            return personaAEditar;
        }
        protected override void Process()
        {
            command.ExecuteNonQuery();
        }

        protected override void Select()
        {
            command.Connection = conexion;
            command.CommandText = "UPDATE PERSONAS SET NOMBRE = '"+this.personaAEditar.Nombre+"', APELLIDO = '"+this.personaAEditar.Apellido+"' WHERE ID = "+this.personaAEditar.Id+"";
        }
    }
}
