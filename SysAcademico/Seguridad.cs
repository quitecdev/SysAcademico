using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SysAcademico
{
    public class Seguridad
    {
        private usuario _usuario;

        public struct usuario
        {
            public DataTable Datos;
            public DataSet Roles;

        }
        public void seguridad()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
            _usuario.Roles = new DataSet();
            _usuario.Datos = new DataTable();

        }



        public void ValidarSession()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            //'***********************No cache**************************************
            context.Response.ExpiresAbsolute = System.DateTime.Now.AddDays(-1);
            context.Response.AddHeader("pragma", "no-cache");
            context.Response.AddHeader("cache-control", "private");
            context.Response.CacheControl = "no-cache";
            //'**********************************************************************
            if (context.Session["USUARIO"] == null || context.Session["USUARIO"]==string.Empty)
            {
                System.Web.HttpContext.Current.Response.Redirect("Ingreso.aspx");
            }
        }

        public usuario Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }

        }
    }
}