using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SysAcademico
{
    public class Usuario
    {
        DataSet datos = new DataSet();
        DataSet roles = new DataSet();
        DataSet menu_inicio = new DataSet();

        public DataSet Datos
        {
            get { return datos; }
            set { datos = value; }

        }

        public DataRow Info
        {
            get { return datos.Tables[0].Rows[0]; }
        }
        public DataSet Roles
        {
            get { return roles; }
            set { roles = value; }

        }
        public DataSet Menu_Inicio
        {
            get { return menu_inicio; }
            set { menu_inicio = value; }

        }

    }
}