using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PrimerCrud.Models
{
    public class ServicioBaseDeDatosTipoDeUsuario : Conexion
    {
        List<TipoDeUsuario> lista;
        List<TipoDeUsuario> TipoDeUsuario;

        public ServicioBaseDeDatosTipoDeUsuario()
        {
            this.lista = new List<TipoDeUsuario>();
        }

        public List<TipoDeUsuario> tipoUsuarios()
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
                TipoDeUsuario tipoDeUsuario = new TipoDeUsuario();
                tipoDeUsuario.id = (int)reader["id"];
                tipoDeUsuario.Tipo = (int)reader["tipo"];
                tipoDeUsuario.Nombre = (string)reader["nombre"];
                this.lista.Add(tipoDeUsuario);
            }
        }

        protected override void Select()
        {
            command.Connection = conexion;
            command.CommandText = "SELECT * FROM tipoDeUsuario";
        }
    }
}