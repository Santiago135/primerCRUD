using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PrimerCrud.Models
{
    public class ServicioBaseDeDatos : Conexion
    {
        List<Persona> lista;
        List<Usuario> listaUser;

        public ServicioBaseDeDatos() 
        {
            this.lista = new List<Persona>();
        }

        public void CrearPersona(Persona persona) 
        {
            ServiceCreatePersona service = new ServiceCreatePersona(persona);
            service.CreatePersona();
        }

        public void ModificarPersona(Persona persona)
        {
            ServiceModifyPersona service = new ServiceModifyPersona(persona);
            service.ModifyPersona();
        }

        public void EliminarPersona(Persona persona)
        {
            ServiceDeletePersona service = new ServiceDeletePersona(persona);
            service.DeletePersona();
        }

        public Persona CargarPersonaPorId(int ID)
        {
            ServiceSelectPersonaById servicio = new ServiceSelectPersonaById();
            Persona personaARetornar = servicio.GetById(ID);
            return personaARetornar;
        }

        public List<TipoDeUsuario> GetTiposDeUsuariosComboBox() 
        {
            ServicioBaseDeDatosTipoDeUsuario servicio = new ServicioBaseDeDatosTipoDeUsuario();
            return servicio.tipoUsuarios();
        }
        public List<TipoDeUsuario> GetTipoDeUsuarios()
        {
            ServicioBaseDeDatosTipoDeUsuario servicio = new ServicioBaseDeDatosTipoDeUsuario();
            return servicio.tipoUsuarios();
        }

        public List<Usuario> GetUsuarios()
        {
            ServicioBaseDeDatosUsuarios servicio = new ServicioBaseDeDatosUsuarios();
            return servicio.ListaUsuarios();
        }

        public List<Persona> ListaPersonas()
        {
            try 
            {
                Run();
            }
            catch (Exception ex) 
            {
                string error = ex.ToString();
                lista = null;
                return lista;
            }
            return lista;
        }

        protected override void Process()
        {
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Persona persona = new Persona();
                persona.Id = (int)reader["id"];
                persona.Nombre = (string)reader["nombre"];
                persona.Apellido = (string)reader["apellido"];
                lista.Add(persona);

            }
        }

        protected override void Select()
        {
            command.Connection = conexion;
            command.CommandText = "SELECT * FROM PERSONAS";
        }  
    }
}