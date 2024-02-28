using System;
using CapaEntidades;
using CapaAccesoDatos;
using System.Data;
using System.Collections.Generic;

namespace CapaLogica
{
    public class BLbitacora
    {
        private string _cadenaConexion;
        private string _mensaje;
        public string Mensaje
        {
            get => _mensaje;
        }
        public BLbitacora(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        public DataSet Listar(string condicion, string orden)
        {
            DataSet DS;
            DAbitacora accesoDatos = new DAbitacora(_cadenaConexion);
            try
            {
                DS = accesoDatos.Listar(condicion, orden);
            }
            catch (Exception)
            {

                throw;
            }
            return DS;
        }
    }
}
