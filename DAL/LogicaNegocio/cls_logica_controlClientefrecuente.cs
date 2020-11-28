using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.LogicaNegocio
{
    public class cls_logica_controlClientefrecuente
    {
        #region

        private String nombre_cliente;
        private String apellido_cliente;
        private String numero_cliente;
        private String email_cliente;
        private int idDireccion_cliente;
        private int idCategoria_cliente;
        private byte status_cliente;


        #endregion

        public string Nombre_cliente { get => nombre_cliente; set => nombre_cliente = value; }
        public string Apellido_cliente { get => apellido_cliente; set => apellido_cliente = value; }
        public string Numero_cliente { get => numero_cliente; set => numero_cliente = value; }
        public string Email_cliente { get => email_cliente; set => email_cliente = value; }
        public int IdDireccion_cliente { get => idDireccion_cliente; set => idDireccion_cliente = value; }
        public int IdCategoria_cliente { get => idCategoria_cliente; set => idCategoria_cliente = value; }
        public byte Status_cliente { get => status_cliente; set => status_cliente = value; }



    }
}
