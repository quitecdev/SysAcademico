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
    public class AdminHorario
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet ObtenerIntervalo(string ID_INTERVALO_DETALLE)
        {
            DataSet ds = new DataSet("DefaultView");
            ds.Tables.Add("DefaultView");
            DataSet resultado = null;
            if (ID_INTERVALO_DETALLE != "0")
            {
                ds = new DataSet("DefaultView");
                ds.Tables.Add("DefaultView");
                Database cn = DatabaseFactory.CreateDatabase("CAS_Data");
                DbCommand cmd = cn.GetStoredProcCommand("dbo.AdminHorario");
                cn.AddInParameter(cmd, "@OPERACION", DbType.String, "OBF");
                cn.AddInParameter(cmd, "@ID_INTERVALO_DETALLE", DbType.String, ID_INTERVALO_DETALLE);
                cn.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                cn.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                cn.LoadDataSet(cmd, ds, "DefaultView");
                string outMensaje = cn.GetParameterValue(cmd, "@outMensaje").ToString();
                resultado = ds;
            }
            return resultado;
        }
    }
}