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
    public class AdminMaterias
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet ObtenerMateria(string ID_CARRERA)
        {
            DataSet ds = new DataSet("DefaultView");
            ds.Tables.Add("DefaultView");
            DataSet resultado = null;
            if (ID_CARRERA != "0")
            {
                ds = new DataSet("DefaultView");
                ds.Tables.Add("DefaultView");
                Database cn = DatabaseFactory.CreateDatabase("CAS_Data");
                DbCommand cmd = cn.GetStoredProcCommand("dbo.AdminMateria");
                cn.AddInParameter(cmd, "@OPERACION", DbType.String, "OBF");
                cn.AddInParameter(cmd, "@ID_CARRERA", DbType.String, ID_CARRERA);
                cn.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                cn.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                cn.LoadDataSet(cmd, ds, "DefaultView");
                string outMensaje = cn.GetParameterValue(cmd, "@outMensaje").ToString();
                resultado = ds;
            }
            return resultado;
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void EliminarMateria(string ID_CARRERA)
        {

        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void ActualizarMateria(string ID_MATERIA, string DESCRIPCION_MATERIA, string COD_MATERIA, string DESCRIPCION_CARRERA)
        {
            if (ID_MATERIA != "0")
            {
                Database cn = DatabaseFactory.CreateDatabase("CAS_Data");
                DbCommand cmd = cn.GetStoredProcCommand("dbo.AdminMateria");
                cn.AddInParameter(cmd, "@OPERACION", DbType.String, "AC");
                cn.AddInParameter(cmd, "@ID_MATERIA", DbType.String, ID_MATERIA);
                cn.AddInParameter(cmd, "@DESCRIPCION_MATERIA", DbType.String, DESCRIPCION_MATERIA);
                cn.AddInParameter(cmd, "@COD_MATERIA", DbType.String, COD_MATERIA);
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