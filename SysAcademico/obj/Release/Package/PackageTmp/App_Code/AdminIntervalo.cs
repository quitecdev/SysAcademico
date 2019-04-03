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
    public class AdminIntervalo
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet ObtenerIntervalo(string ID_SEDE, string ID_TIPO_INTERVALO, string ID_HORARIO_TIPO)
        {
            DataSet ds = new DataSet("DefaultView");
            ds.Tables.Add("DefaultView");
            DataSet resultado = null;
            if (ID_SEDE != "0")
            {
                ds = new DataSet("DefaultView");
                ds.Tables.Add("DefaultView");
                Database cn = DatabaseFactory.CreateDatabase("CAS_Data");
                DbCommand cmd = cn.GetStoredProcCommand("dbo.AdminIntervalo");
                cn.AddInParameter(cmd, "@OPERACION", DbType.String, "OBF");
                cn.AddInParameter(cmd, "@ID_SEDE", DbType.String, ID_SEDE);
                cn.AddInParameter(cmd, "@ID_TIPO_INTERVALO", DbType.String, ID_TIPO_INTERVALO);
                cn.AddInParameter(cmd, "@ID_HORARIO_TIPO", DbType.String, ID_HORARIO_TIPO);
                cn.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                cn.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                cn.LoadDataSet(cmd, ds, "DefaultView");
                string outMensaje = cn.GetParameterValue(cmd, "@outMensaje").ToString();
                resultado = ds;
            }
            return resultado;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void ActualizarIntervalo(string ID_INTERVALO, string DESCRIPCION_INTERVALO, string DESCRIPCION_UNIVERSIDAD, string DESCRIPCION_HORARIO_TIPO, string DESCRIPCION_TIPO_INVERTALO)
        {
            if (ID_INTERVALO != "0")
            {
                Database cn = DatabaseFactory.CreateDatabase("CAS_Data");
                DbCommand cmd = cn.GetStoredProcCommand("dbo.AdminIntervalo");
                cn.AddInParameter(cmd, "@OPERACION", DbType.String, "ACA");
                cn.AddInParameter(cmd, "@ID_INTERVALO", DbType.String, ID_INTERVALO);
                cn.AddInParameter(cmd, "@DESCRIPCION_INTERVALO", DbType.String, DESCRIPCION_INTERVALO);
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