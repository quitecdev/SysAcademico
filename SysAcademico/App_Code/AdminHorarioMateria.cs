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
    public class AdminHorarioMateria
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet ObtenerMateriaHorario(string ID_PARALELO_MATERIA)
        {
            DataSet ds = new DataSet("DefaultView");
            ds.Tables.Add("DefaultView");
            DataSet resultado = null;
            if (ID_PARALELO_MATERIA != "0")
            {
                ds = new DataSet("DefaultView");
                ds.Tables.Add("DefaultView");
                Database cn = DatabaseFactory.CreateDatabase("CAS_Data");
                DbCommand cmd = cn.GetStoredProcCommand("dbo.AdminHorarioDetalle");
                cn.AddInParameter(cmd, "@OPERACION", DbType.String, "OFMD");
                cn.AddInParameter(cmd, "@ID_PARALELO_MATERIA", DbType.String, ID_PARALELO_MATERIA);
                cn.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                cn.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                cn.LoadDataSet(cmd, ds, "DefaultView");
                string outMensaje = cn.GetParameterValue(cmd, "@outMensaje").ToString();
                resultado = ds;
            }
            return resultado;
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void EliminarHorario(string ID_HORARIO_DETALLE)
        {
            if (ID_HORARIO_DETALLE != "0")
            {
                Database cn = DatabaseFactory.CreateDatabase("CAS_Data");
                DbCommand cmd = cn.GetStoredProcCommand("dbo.AdminHorarioDetalle");
                cn.AddInParameter(cmd, "@OPERACION", DbType.String, "EL");
                cn.AddInParameter(cmd, "@ID_HORARIO_DETALLE", DbType.Int32, Convert.ToInt32(ID_HORARIO_DETALLE));
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