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
    public class AdminCarrera
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet ObtenerDetalle(string ID_CARRERA)
        {
            DataSet ds = new DataSet("DefaultView");
            ds.Tables.Add("DefaultView");
            DataSet resultado = null;
            if (ID_CARRERA != "0")
            {
                ds = new DataSet("DefaultView");
                ds.Tables.Add("DefaultView");
                Database cn = DatabaseFactory.CreateDatabase("CAS_Data");
                DbCommand cmd = cn.GetStoredProcCommand("dbo.AdminCarrera");
                cn.AddInParameter(cmd, "@OPERACION", DbType.String, "OB");
                cn.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                cn.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                cn.LoadDataSet(cmd, ds, "DefaultView");
                string outMensaje = cn.GetParameterValue(cmd, "@outMensaje").ToString();
                resultado = ds;
            }
            return resultado;
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void EliminarCarrera(string ID_CARRERA)
        {

        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void ActualizarCarreara(string ID_CARRERA, string DESCRIPCION_CARRERA, string NOMBRE_TECNICO_CARRERA, string COD_CARRERA)
        {
            if (ID_CARRERA != "0")
            {
                Database cn = DatabaseFactory.CreateDatabase("CAS_Data");
                DbCommand cmd = cn.GetStoredProcCommand("dbo.AdminCarrera");
                cn.AddInParameter(cmd, "@OPERACION", DbType.String, "AC");
                cn.AddInParameter(cmd, "@ID_CARRERA", DbType.String, ID_CARRERA);
                cn.AddInParameter(cmd, "@DESCRIPCION_CARRERA", DbType.String, DESCRIPCION_CARRERA);
                cn.AddInParameter(cmd, "@NOMBRE_TECNICO_CARRERA", DbType.String, NOMBRE_TECNICO_CARRERA);
                cn.AddInParameter(cmd, "@COD_CARRERA", DbType.String, COD_CARRERA);
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