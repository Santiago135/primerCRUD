using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PrimerCrud.Models
{
    public abstract class Conexion
    {



        private string constring = "";
        protected SqlConnection conexion;
        protected SqlCommand command = new SqlCommand();
        public Conexion()
        {
            
            constring = "server=DESKTOP-9RA64BM ; database=NuevoProyecto ; integrated security=true";
            conexion = new SqlConnection(constring);
        }

        public void Run()
        {

            using (conexion)
            {
                this.Conectar();
                this.Select();
                this.Process();
                this.Desconectar();
            }

        }
        protected void Conectar()
        {
            conexion.Open();
        }
        protected void Desconectar()
        {
            conexion.Close();
        }
        protected abstract void Select();
        protected abstract void Process();
    }
}