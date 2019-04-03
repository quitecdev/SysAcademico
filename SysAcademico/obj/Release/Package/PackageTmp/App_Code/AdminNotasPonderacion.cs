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
    public class AdminNotasPonderacion
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet ObtenerPonderacion(string ID_NOTA_DETALLE)
        {
            DataSet ds = new DataSet("DefaultView");
            ds.Tables.Add("DefaultView");
            DataSet resultado = null;
            if (ID_NOTA_DETALLE != "0")
            {
                ds = new DataSet("DefaultView");
                ds.Tables.Add("DefaultView");
                Database cn = DatabaseFactory.CreateDatabase("CAS_Data");
                DbCommand cmd = cn.GetStoredProcCommand("dbo.AdminNotaPondereacion");
                cn.AddInParameter(cmd, "@OPERACION", DbType.String, "OBF");
                cn.AddInParameter(cmd, "@ID_NOTA_DETALLE", DbType.String, ID_NOTA_DETALLE);
                cn.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                cn.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                cn.LoadDataSet(cmd, ds, "DefaultView");
                string outMensaje = cn.GetParameterValue(cmd, "@outMensaje").ToString();
                resultado = ds;
            }
            return resultado;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void ActualizarPonderacion(string ID_PONDERACION, string DESCRIPCION_PONDERACION, string VALOR_PONDERACION)
        {
            if (ID_PONDERACION != "0")
            {
                Database cn = DatabaseFactory.CreateDatabase("CAS_Data");
                DbCommand cmd = cn.GetStoredProcCommand("dbo.AdminNotaPondereacion");
                cn.AddInParameter(cmd, "@OPERACION", DbType.String, "ACA");
                cn.AddInParameter(cmd, "@ID_PONDERACION", DbType.String, ID_PONDERACION);
                cn.AddInParameter(cmd, "@DESCRIPCION_PONDERACION", DbType.String, DESCRIPCION_PONDERACION);
                cn.AddInParameter(cmd, "@VALOR_PONDERACION", DbType.Decimal, Convert.ToDecimal(VALOR_PONDERACION));
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