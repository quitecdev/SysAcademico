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
    public class AdminMateriaParalelo
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet ObtenerMateriaParalelo(string ID_MATERIA)
        {
            DataSet ds = new DataSet("DefaultView");
            ds.Tables.Add("DefaultView");
            DataSet resultado = null;
            if (ID_MATERIA != "0")
            {
                ds = new DataSet("DefaultView");
                ds.Tables.Add("DefaultView");
                Database cn = DatabaseFactory.CreateDatabase("CAS_Data");
                DbCommand cmd = cn.GetStoredProcCommand("dbo.AdminParaleloMateria");
                cn.AddInParameter(cmd, "@OPERACION", DbType.String, "OBP");
                cn.AddInParameter(cmd, "@ID_MATERIA", DbType.String, ID_MATERIA);
                cn.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                cn.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                cn.LoadDataSet(cmd, ds, "DefaultView");
                string outMensaje = cn.GetParameterValue(cmd, "@outMensaje").ToString();
                resultado = ds;
            }
            return resultado;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void ActualizarMateria(string ID_PARALELO_MATERIA, string MAX_ASIGANDO, string DESCRIPCION_PARALELO, string DESCRIPCION_UNIVERSIDAD)
        {
            if (ID_PARALELO_MATERIA != "0")
            {
                Database cn = DatabaseFactory.CreateDatabase("CAS_Data");
                DbCommand cmd = cn.GetStoredProcCommand("dbo.AdminParaleloMateria");
                cn.AddInParameter(cmd, "@OPERACION", DbType.String, "ACM");
                cn.AddInParameter(cmd, "@ID_PARALELO_MATERIA", DbType.String, ID_PARALELO_MATERIA);
                cn.AddInParameter(cmd, "@MAX_ASIGANDO", DbType.String, MAX_ASIGANDO);
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