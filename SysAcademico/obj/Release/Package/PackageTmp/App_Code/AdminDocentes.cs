using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace SysAcademico.App_Code
{
    [DataObject(true)]
    public class AdminDocentes
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet ObtenerDocentes(string ID_DOCENTE)
        {
            DataSet ds = new DataSet("DefaultView");
            ds.Tables.Add("DefaultView");
            DataSet resultado = null;
            if (ID_DOCENTE != "0")
            {
                ds = new DataSet("DefaultView");
                ds.Tables.Add("DefaultView");
                Database cn = DatabaseFactory.CreateDatabase("CAS_Data");
                DbCommand cmd = cn.GetStoredProcCommand("dbo.AdminDocente");
                cn.AddInParameter(cmd, "@OPERACION", DbType.String, "OB");
                cn.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                cn.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                cn.LoadDataSet(cmd, ds, "DefaultView");
                string outMensaje = cn.GetParameterValue(cmd, "@outMensaje").ToString();
                resultado = ds;
            }
            return resultado;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void ActualizarDocente(string ID_DOCENTE,string APELLIDO_PATERNO_DOCENTE, string APELLIDO_MATERNO_DOCENTE, string PRIMER_NOMBRE_DOCENTE, string SEGUNDO_NOMBRE_DOCENTE, string CORREO_DOCENTE)
        {
            if (ID_DOCENTE != "0")
            {
                Database cn = DatabaseFactory.CreateDatabase("CAS_Data");
                DbCommand cmd = cn.GetStoredProcCommand("dbo.AdminDocente");
                cn.AddInParameter(cmd, "@OPERACION", DbType.String, "ACD");
                cn.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, ID_DOCENTE);
                cn.AddInParameter(cmd, "@APELLIDO_PATERNO", DbType.String, APELLIDO_PATERNO_DOCENTE);
                cn.AddInParameter(cmd, "@APELLIDO_MATERNO", DbType.String, APELLIDO_MATERNO_DOCENTE);
                cn.AddInParameter(cmd, "@PRIMER_NOMBRE", DbType.String, PRIMER_NOMBRE_DOCENTE);
                cn.AddInParameter(cmd, "@SEGUNDO_NOMBRE", DbType.String, SEGUNDO_NOMBRE_DOCENTE);
                cn.AddInParameter(cmd, "@CORREO", DbType.String, CORREO_DOCENTE);               
                cn.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                cn.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                cn.ExecuteNonQuery(cmd);
                string outMensaje = cn.GetParameterValue(cmd, "@outMensaje").ToString();
                if (outMensaje.IndexOf("ERROR") != -1)
                {
                    throw new Exception(outMensaje);
                }
            }
        }



    }
}