using System;
using CapaEntidades;
using CapaAccesoDatos;
using System.Data;
using System.Collections.Generic;

namespace CapaLogica
{
    public class BLpagos
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;
        public string Mensaje
        {
            get => _mensaje;
        }
        public BLpagos(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public int Insertar(EntidadPagos pago)//Metodo para insertar de la capa Acceso a datos
        {
            int id = 0;
            DApagos accesoDatos = new DApagos(_cadenaConexion);
            try
            {
                id = accesoDatos.Insertar(pago);
            }
            catch (Exception)
            {
                throw;
            }

            return id;
        }//Fin del metodo insertar

        public int Modificar(EntidadPagos pago)
        {
            DApagos accesoDatos = new DApagos(_cadenaConexion);
            return accesoDatos.Modificar(pago);
        }

        public EntidadPagos Obtener(int id)
        {
            EntidadPagos pago;
            DApagos accesoDatos = new DApagos(_cadenaConexion);
            try
            {
                pago = accesoDatos.obtener(id);
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener el pago: " + ex.Message);
            }
            return pago;
        }

        public DataSet Listar(string condicion, string orden)
        {
            DataSet DS;
            DApagos accesoDatos = new DApagos(_cadenaConexion);
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

        public int Eliminar(EntidadPagos pago)
        {
            int resultado;
            DApagos accesoDatos = new DApagos(_cadenaConexion);
            try
            {
                //Aqui se pueden hacer las validaciones
                //o agregar una logica de programacion 
                resultado = accesoDatos.Eliminar(pago);
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }

    }
}
