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
    public class AdminDocenteMaterias
    {
         [DataObjectMethod(DataObjectMethodType.Select)]
         public DataSet ObtenerMateriaHorario(string ID_DOCENTE, string ID_MATERIA)
         {
             DataSet ds = new DataSet("DefaultView");
             ds.Tables.Add("DefaultView");
             DataSet resultado = null;
             if (ID_DOCENTE != "0" && ID_MATERIA!="0")
             {
                 ds = new DataSet("DefaultView");
                 ds.Tables.Add("DefaultView");
                 Database cn = DatabaseFactory.CreateDatabase("CAS_Data");
                 DbCommand cmd = cn.GetStoredProcCommand("dbo.AdminDocenteMateriaParalelo");
                 cn.AddInParameter(cmd, "@OPERACION", DbType.String, "OFMD");
                 cn.AddInParameter(cmd, "@ID_DOCENTE", DbType.String, ID_DOCENTE);
                 cn.AddInParameter(cmd, "@ID_MATERIA", DbType.String, ID_MATERIA);
                 cn.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                 cn.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                 cn.LoadDataSet(cmd, ds, "DefaultView");
                 string outMensaje = cn.GetParameterValue(cmd, "@outMensaje").ToString();
                 resultado = ds;
             }
             return resultado;
         }


         [DataObjectMethod(DataObjectMethodType.Delete)]
         public void EliminarHorario(string ID_HORARIO_DETALLE, string ID_DOCENTE, string ID_MATERIA)
         {
             if (ID_HORARIO_DETALLE != "0")
             {
                 Database cn = DatabaseFactory.CreateDatabase("CAS_Data");
                 DbCommand cmd = cn.GetStoredProcCommand("dbo.AdminDocenteMateriaParalelo");
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


        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet ObtenerHorarioIntensivo(string ID_SEDE)
        {
            DataSet ds = new DataSet("DefaultView");
            ds.Tables.Add("DefaultView");
            DataSet resultado = null;
            if (ID_SEDE != "0" )
            {
                ds = new DataSet("DefaultView");
                ds.Tables.Add("DefaultView");
                Database cn = DatabaseFactory.CreateDatabase("CAS_Data");
                DbCommand cmd = cn.GetStoredProcCommand("dbo.AdminDocenteMateriaParalelo");
                cn.AddInParameter(cmd, "@OPERACION", DbType.String, "OHIN");
                cn.AddInParameter(cmd, "@ID_SEDE", DbType.String, ID_SEDE);
                cn.AddOutParameter(cmd, "@outMensaje", DbType.String, 200);
                cn.AddOutParameter(cmd, "@outID", DbType.Int32, 10);
                cn.LoadDataSet(cmd, ds, "DefaultView");
                string outMensaje = cn.GetParameterValue(cmd, "@outMensaje").ToString();
                resultado = ds;
            }
            return resultado;
        }


        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void EliminarHorarioIntensivo(string ID_HORARIO_DETALLE, string ID_DOCENTE, string ID_MATERIA)
        {
            if (ID_HORARIO_DETALLE != "0")
            {
                Database cn = DatabaseFactory.CreateDatabase("CAS_Data");
                DbCommand cmd = cn.GetStoredProcCommand("dbo.AdminDocenteMateriaParalelo");
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