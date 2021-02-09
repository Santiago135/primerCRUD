using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PrimerCrud.Models
{
    public class ServiceSelectUsuario : Conexion
    {
        Usuario usuarioById;
        int Id;
        public ServiceSelectUsuario()
        {
            this.usuarioById = new Usuario();
        }
        public Usuario GetById(int Id)
        {
            this.Id = Id;
            try
            {
                Run();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                usuarioById = null;
                return usuarioById;
            }
            return usuarioById;

        }

        protected override void Process()
        {

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Usuario usuario = new Usuario();
                usuario.Id = (int)reader["id"];
                usuario.User = (string)reader["nombre"];
                usuario.Contraseña = (string)reader["contraseña"];
                usuario.IdPersona = (int)reader["idpersona"];
                usuario.IdTipoUsuario = reader["idtipousuario"] == DBNull.Value ? usuario.IdTipoUsuario : (int)reader["idtipousuario"];
                this.usuarioById = usuario;

            }
        }

        protected override void Select()
        {
            command.Connection = conexion;
            command.CommandText = "SELECT * FROM USUARIOS WHERE id =" + this.Id + "";
        }
    }
}