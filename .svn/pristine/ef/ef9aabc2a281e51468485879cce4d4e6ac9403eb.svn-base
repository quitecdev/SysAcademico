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
    public class AdminCronogramaDetalle
    {

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet ObtenerDetalle(string ID_CRONOGRAMA)
        {
            DataSet ds = new DataSet("DefaultView");
            ds.Tables.Add("DefaultView");
            DataSet resultado = null;
            if (ID_CRONOGRAMA != "0")
            {
                ds = new DataSet("DefaultView");
                ds.Tables.Add("DefaultView");
                Database cn = DatabaseFactory.CreateDatabase("CAS_Data");
                DbCommand cmd = cn.GetStoredProcCommand("dbo.AdminCronogramaDetalle");
                cn.AddInParameter(cmd, "@OPERACION", DbType.String, "OB");
                cn.AddInParameter(cmd, "@ID_CRONOGRAMA", DbType.String, ID_CRONOGRAMA);
                cn.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                cn.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                cn.LoadDataSet(cmd, ds, "DefaultView");
                string outMensaje = cn.GetParameterValue(cmd, "@outMensaje").ToString();
                resultado = ds;
            }
            return resultado;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void ActualizarCronogramaDetalle(string ID_CRONOGRAMA_DETALLE,string TEMA, string TEMATICA, string REQUERIMIENTO, string FERIADO, string SEMANA_CRONOGRAMA,string FECHA_CRONOGRAMA, string DIA)
        {
            if (ID_CRONOGRAMA_DETALLE != "0")
            {
                Database cn = DatabaseFactory.CreateDatabase("CAS_Data");
                DbCommand cmd = cn.GetStoredProcCommand("dbo.AdminCronogramaDetalle");
                cn.AddInParameter(cmd, "@OPERACION", DbType.String, "AC");
                cn.AddInParameter(cmd, "@ID_CRONOGRAMA_DETALLE", DbType.String, ID_CRONOGRAMA_DETALLE);
                cn.AddInParameter(cmd, "@TEMA", DbType.String, TEMA);
                cn.AddInParameter(cmd, "@TEMATICA", DbType.String, TEMATICA);
                cn.AddInParameter(cmd, "@REQUERIMIENTO", DbType.String, REQUERIMIENTO);
                cn.AddInParameter(cmd, "@FERIADO", DbType.Int32, FERIADO== "True" ? 1 : 0);
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