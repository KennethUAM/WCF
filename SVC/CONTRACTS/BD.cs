using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using DAL.BD;
using BLL.BD;
using System.Data;

namespace SVC.CONTRACTS
{
    public class BD : INTERFACES.IBD
    {
        public DataTable Get_DT_Param(DataTable DT_Param)
        {
            DT_Param = new DataTable("PARAMETROS");
            DT_Param.Columns.Add("Nom_Param");
            DT_Param.Columns.Add("Tipo_Dato_Param");
            DT_Param.Columns.Add("Valor_Param");

            return DT_Param;
        }

        public string Login(string usuario, string password)
        { 
            var mensaje = ""; 
            cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
            cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();
            DataTable DT_Param = new DataTable("PARAMETROS");

            DT_Param.Columns.Add("usuario");
            DT_Param.Columns.Add("1");
            DT_Param.Columns.Add("valor");


            DataRow row = DT_Param.NewRow();
            row["usuario"] = "usuario";
            row["1"] = "6";
            row["valor"] = usuario;

            DataRow rowx = DT_Param.NewRow();
            rowx["usuario"] = "password";
            rowx["1"] = "6";
            rowx["valor"] = password;



            DT_Param.Rows.Add(row);
            DT_Param.Rows.Add(rowx);
            Obj_BD_DAL.sNomSP = "GEN_Login";
            Obj_BD_DAL.sNomTabla = "usuario";
            Obj_BD_DAL.DT_Parametros = DT_Param;


            Obj_BD_BLL.ExecDataAdapter(ref Obj_BD_DAL);
            DataTable DT_Resultado = new DataTable("resultado");
            if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
            {
                DT_Resultado = Obj_BD_DAL.DS.Tables[0];
                mensaje = DT_Resultado.Rows[0][0].ToString();
            }




           return mensaje;

        }

            public DataTable ListarFiltrar(string sNombreTabla, string sNombreSP, DataTable DT_Param)
        {
            cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
            cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();

            Obj_BD_DAL.sNomSP = sNombreSP;
            Obj_BD_DAL.sNomTabla = sNombreTabla;
            Obj_BD_DAL.DT_Parametros = DT_Param;

            Obj_BD_BLL.ExecDataAdapter(ref Obj_BD_DAL);

            if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
            {
                return Obj_BD_DAL.DS.Tables[0];
            }
            else
            {
                return null;
            }
        }






        public string Ins_Upd_Delete(string sNombreSP, string sIndAxn, DataTable DT_Param)
        {
            cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
            cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();

            Obj_BD_DAL.sNomSP = sNombreSP;
            Obj_BD_DAL.sIndAxn = sIndAxn;
            Obj_BD_DAL.DT_Parametros = DT_Param;

            Obj_BD_BLL.ExecCommand(ref Obj_BD_DAL);

            if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
            {
                return Obj_BD_DAL.sValorScalar;
            }
            else
            {
                return Obj_BD_DAL.sMsjErrorBD;
            }
        }
    }
}
