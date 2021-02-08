using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PrimerCrud.Models
{
    public class ServicioBaseDeDatosUsuarios : Conexion
    {
        List<Usuario> listaUser;
        public void CrearUsuario(Usuario usuario)
        {
            ServiceCreateUsuario service = new ServiceCreateUsuario(usuario);
            service.CreateUsuario();
        }

        public ServicioBaseDeDatosUsuarios()
        {
            this.listaUser = new List<Usuario>();
        }

        public List<Usuario> ListaUsuarios()
        {
            try
            {
                Run();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                listaUser = null;
                return listaUser;
            }
            return listaUser;
        }

        protected override void Process()
        {

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Usuario usuario = new Usuario();
                TipoDeUsuario tipo = new TipoDeUsuario();
                usuario.Id = (int)reader["id"];
                usuario.IdPersona = (int)reader["idpersona"];
                usuario.IdTipoUsuario = reader["idtipousuario"] == DBNull.Value ? usuario.IdTipoUsuario : (int)reader["idtipousuario"];
                usuario.User = (string)reader["nombre"];
                usuario.Contraseña = (string)reader["contraseña"];
                listaUser.Add(usuario);
            }
        }

        protected override void Select()
        {
            command.Connection = conexion;
            command.CommandText = "SELECT * FROM USUARIOS";
        }
    }
}