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
    public class AdminDocenteNota
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet ObtenerPonderacion(string ID_NOTA, string ID_NOTA_DETALLE, string ID_SEDE)
        {
            DataSet ds = new DataSet("DefaultView");
            ds.Tables.Add("DefaultView");
            DataSet resultado = null;
            if (ID_NOTA_DETALLE != "0")
            {
                ds = new DataSet("DefaultView");
                ds.Tables.Add("DefaultView");
                Database cn = DatabaseFactory.CreateDatabase("CAS_Data");
                DbCommand cmd = cn.GetStoredProcCommand("dbo.AdminNotaDetalle");
                cn.AddInParameter(cmd, "@OPERACION", DbType.String, "OBG");
                cn.AddInParameter(cmd, "@ID_NOTA", DbType.String, ID_NOTA);
                cn.AddInParameter(cmd, "@ID_NOTA_DETALLE", DbType.String, ID_NOTA_DETALLE);
                cn.AddInParameter(cmd, "@ID_SEDE", DbType.String, ID_SEDE);
                cn.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                cn.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                cn.LoadDataSet(cmd, ds, "DefaultView");
                string outMensaje = cn.GetParameterValue(cmd, "@outMensaje").ToString();
                resultado = ds;
            }
            return resultado;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void ActualizarPonderacion(string ID_DOCENTE_NOTA, string DESCRIPCION_PONDERACION, string ID_DOCENTE, string NOMBRE, string FECHA_INICIO, string FECHA_FIN)
        {
            if (ID_DOCENTE_NOTA != "0")
            {
                Database cn = DatabaseFactory.CreateDatabase("CAS_Data");
                DbCommand cmd = cn.GetStoredProcCommand("dbo.AdminDocenteNotas");
                cn.AddInParameter(cmd, "@OPERACION", DbType.String, "ACAD");
                cn.AddInParameter(cmd, "@ID_DOCENTE_NOTA", DbType.String, ID_DOCENTE_NOTA);
                cn.AddInParameter(cmd, "@FECHA_INICIO", DbType.Date, Convert.ToDateTime(FECHA_INICIO));
                cn.AddInParameter(cmd, "@FECHA_FIN", DbType.Date, Convert.ToDateTime(FECHA_FIN));
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