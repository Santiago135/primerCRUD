using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PrimerCrud.Models
{
    public class ServiceSelectPersonaById : Conexion
    {
        Persona personaById;
        int Id;
        public ServiceSelectPersonaById()
        {
            this.personaById = new Persona();
        }
        public Persona GetById(int Id)
        {
            this.Id = Id;
            try
            {
                Run();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
               personaById = null;
                return personaById;
            }
            return personaById;

        }
        
        protected override void Process()
        {

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Persona persona = new Persona();
                persona.Id = (int)reader["id"];
                persona.Nombre = (string)reader["nombre"];
                persona.Apellido = (string)reader["apellido"];
                this.personaById = persona;

            }
        }

        protected override void Select()
        {
            command.Connection = conexion;
            command.CommandText = "SELECT * FROM PERSONAS WHERE id =" + this.Id +"";
        }
    }
}
