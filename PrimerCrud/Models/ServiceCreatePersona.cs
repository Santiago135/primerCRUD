using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PrimerCrud.Models
{
    public class ServiceCreatePersona : Conexion
    {
        Persona personACrear;
        public ServiceCreatePersona(Persona persona)
        {
            this.personACrear = persona;
        }
        public Persona CreatePersona()
        {

            try
            {
                Run();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                personACrear = null;
                return personACrear;
            }
            return personACrear;
        }
        protected override void Process()
        {

           command.ExecuteNonQuery();
            
        }

        protected override void Select()
        {
            command.Connection = conexion;
            command.CommandText = "INSERT INTO PERSONAS(nombre, apellido) VALUES ('"+this.personACrear.Nombre +"', '"+this.personACrear.Apellido+"')";
        }
      


    }
}