using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimerCrud.Models
{
    public class ServiceCreateUsuario : Conexion
    {
        Usuario usuarioACrear;
        public ServiceCreateUsuario(Usuario usuario)
        {
            this.usuarioACrear = usuario;
        }
        public Usuario CreateUsuario()
        {
            try
            {
                Run();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                usuarioACrear = null;
                return usuarioACrear;
            }
            return usuarioACrear;
        }
        protected override void Process()
        {
            command.ExecuteNonQuery();
        }

        protected override void Select()
        {
            command.Connection = conexion;
            command.CommandText = "INSERT INTO USUARIOS(idPersona, idTipoUsuario, nombre, contraseña) VALUES ("+this.usuarioACrear.IdPersona+","+this.usuarioACrear.IdTipoUsuario+",'"+ this.usuarioACrear.User + "', '" + this.usuarioACrear.Contraseña + "')";
        }
    }
}
