using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimerCrud.Models
{
    public class ServiceDeleteUsuario : Conexion
    {
        Usuario usuarioABorrar;

        public ServiceDeleteUsuario(Usuario usuario)
        {
            this.usuarioABorrar = usuario;
        }

        public Usuario DeleteUsuario()
        {
            try
            {
                Run();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                usuarioABorrar = null;
                return usuarioABorrar;
            }
            return usuarioABorrar;
        }

        protected override void Process()
        {
            command.ExecuteNonQuery();
        }

        protected override void Select()
        {
            command.Connection = conexion;
            command.CommandText = "DELETE FROM USUARIOS WHERE ID = " + this.usuarioABorrar.Id + "";
        }
    }
}