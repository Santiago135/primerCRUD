using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimerCrud.Models
{
    public class ServiceModifyUsuario : Conexion
    {
        Usuario usuarioAEditar;
        public ServiceModifyUsuario(Usuario usuario)
        {
            this.usuarioAEditar = usuario;
        }


        public Usuario ModifyUsuario()
        {
            try
            {
                Run();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                usuarioAEditar = null;
                return usuarioAEditar;
            }
            return usuarioAEditar;
        }
        protected override void Process()
        {
            command.ExecuteNonQuery();
        }

        protected override void Select()
        {
            command.Connection = conexion;
            command.CommandText = "UPDATE USUARIOS SET NOMBRE = '" + this.usuarioAEditar.User+ "', CONTRASEÑA = '" + this.usuarioAEditar.Contraseña + "', IDTIPOUSUARIO = " + this.usuarioAEditar.IdTipoUsuario + " WHERE ID = " + this.usuarioAEditar.Id + "";
        }
    }
}