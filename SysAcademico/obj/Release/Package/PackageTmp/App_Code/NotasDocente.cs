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
    public class NotasDocente
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet ObtenerDetalle(string ID_DOCENTE, string ID_NOTA, string ID_SEDE, string ID_CARRERA)
        {
            DataSet ds = new DataSet("DefaultView");
            ds.Tables.Add("DefaultView");
            DataSet resultado = null;
            if (ID_NOTA != "0")
            {
                ds = new DataSet("DefaultView");
                ds.Tables.Add("DefaultView");
                Database cn = DatabaseFactory.CreateDatabase("CAS_Data");
                DbCommand cmd = cn.GetStoredProcCommand("dbo.sp_NotasPivot");
                cn.AddInParameter(cmd, "@OPERACION", DbType.String, "OB");
                cn.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, ID_DOCENTE);
                cn.AddInParameter(cmd, "@ID_NOTA", DbType.String, ID_NOTA);
                cn.AddInParameter(cmd, "@ID_SEDE", DbType.String, ID_SEDE);
                cn.AddInParameter(cmd, "@ID_CARRERA", DbType.String, ID_CARRERA);
                cn.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                cn.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                cn.LoadDataSet(cmd, ds, "DefaultView");
                string outMensaje = cn.GetParameterValue(cmd, "@outMensaje").ToString();
                resultado = ds;
            }
            return resultado;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void ActualizarNota(string ID_ESTUDIANTE_NOTA, string ID_ESTUDIANTE, string ID_DOCENTE, string VALOR_NOTA, string DESCRIPCION_NOTA_DETALLE, string DESCRIPCION_PONDERACION, string NOMBRE, string NOTA)
        {
            if (ID_ESTUDIANTE_NOTA != "0")
            {
                Database cn = DatabaseFactory.CreateDatabase("CAS_Data");
                DbCommand cmd = cn.GetStoredProcCommand("dbo.AdminNota");
                cn.AddInParameter(cmd, "@OPERACION", DbType.String, "ANE");
                cn.AddInParameter(cmd, "@ID_ESTUDIANTE_NOTA", DbType.String, ID_ESTUDIANTE_NOTA);
                cn.AddInParameter(cmd, "@VALOR_NOTA", DbType.Decimal, Convert.ToDecimal(VALOR_NOTA));
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