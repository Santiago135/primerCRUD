using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimerCrud.Models
{
    public class ServiceDeletePersona : Conexion
    {
        Persona personaAEliminar;
        public ServiceDeletePersona(Persona persona)
        {
            this.personaAEliminar = persona;
        }


        public Persona DeletePersona()
        {

            try
            {
                Run();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                personaAEliminar = null;
                return personaAEliminar;
            }
            return personaAEliminar;
        }
        protected override void Process()
        {
            command.ExecuteNonQuery();
        }

        protected override void Select()
        {
            command.Connection = conexion;
            command.CommandText = "DELETE FROM PERSONAS WHERE ID = " + this.personaAEliminar.Id + "";
        }
    }
}