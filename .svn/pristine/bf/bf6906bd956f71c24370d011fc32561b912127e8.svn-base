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
    public class AdminIntervaloDetalle
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet ObtenerIntervalo(string ID_INTERVALO)
        {
            DataSet ds = new DataSet("DefaultView");
            ds.Tables.Add("DefaultView");
            DataSet resultado = null;
            if (ID_INTERVALO != "0")
            {
                ds = new DataSet("DefaultView");
                ds.Tables.Add("DefaultView");
                Database cn = DatabaseFactory.CreateDatabase("CAS_Data");
                DbCommand cmd = cn.GetStoredProcCommand("dbo.AdminIntervaloDetalle");
                cn.AddInParameter(cmd, "@OPERACION", DbType.String, "OBF");
                cn.AddInParameter(cmd, "@ID_INTERVALO", DbType.String, ID_INTERVALO);
                cn.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                cn.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                cn.LoadDataSet(cmd, ds, "DefaultView");
                string outMensaje = cn.GetParameterValue(cmd, "@outMensaje").ToString();
                resultado = ds;
            }
            return resultado;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void ActualizarIntervalo(string ID_INTERVALO_DETALLE, string INICIO_INTERVALO, string FIN_INTERVALO, string DESCRIPCION_UNIVERSIDAD, string DESCRIPCION_HORARIO_TIPO, string DESCRIPCION_TIPO_INVERTALO)
        {
            if (ID_INTERVALO_DETALLE != "0")
            {
                Database cn = DatabaseFactory.CreateDatabase("CAS_Data");
                DbCommand cmd = cn.GetStoredProcCommand("dbo.AdminIntervaloDetalle");
                cn.AddInParameter(cmd, "@OPERACION", DbType.String, "ACA");
                cn.AddInParameter(cmd, "@ID_INTERVALO_DETALLE", DbType.String, ID_INTERVALO_DETALLE);
                cn.AddInParameter(cmd, "@INICIO_INTERVALO", DbType.String, INICIO_INTERVALO);
                cn.AddInParameter(cmd, "@FIN_INTERVALO", DbType.String, FIN_INTERVALO);
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