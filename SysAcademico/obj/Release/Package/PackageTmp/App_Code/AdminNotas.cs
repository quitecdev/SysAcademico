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
    public class AdminNotas
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet ObtenerDetalle(string ID_NOTA)
        {
            DataSet ds = new DataSet("DefaultView");
            ds.Tables.Add("DefaultView");
            DataSet resultado = null;
            if (ID_NOTA != "0")
            {
                ds = new DataSet("DefaultView");
                ds.Tables.Add("DefaultView");
                Database cn = DatabaseFactory.CreateDatabase("CAS_Data");
                DbCommand cmd = cn.GetStoredProcCommand("dbo.AdminNota");
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
        public void ActualizarIntervalo(string ID_NOTA, string DESCRIPCION_NOTA)
        {
            if (ID_NOTA != "0")
            {
                Database cn = DatabaseFactory.CreateDatabase("CAS_Data");
                DbCommand cmd = cn.GetStoredProcCommand("dbo.AdminNota");
                cn.AddInParameter(cmd, "@OPERACION", DbType.String, "AC");
                cn.AddInParameter(cmd, "@ID_NOTA", DbType.String, ID_NOTA);
                cn.AddInParameter(cmd, "@DESCRIPCION_NOTA", DbType.String, DESCRIPCION_NOTA);
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