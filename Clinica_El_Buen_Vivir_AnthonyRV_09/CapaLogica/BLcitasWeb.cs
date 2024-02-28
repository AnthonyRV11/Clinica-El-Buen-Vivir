using System;
using CapaEntidades;
using CapaAccesoDatos;
using System.Data;
using System.Collections.Generic;

namespace CapaLogica
{
    public class BLcitasWeb
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;
        public string Mensaje
        {
            get => _mensaje;
        }
        public BLcitasWeb(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        public int Insertar(EntidadCitasWeb cita)//Metodo para insertar de la capa Acceso a datos
        {
            int id = 0;
            DAcitasWeb accesoDatos = new DAcitasWeb(_cadenaConexion);
            try
            {
                id = accesoDatos.Insertar(cita);
                _mensaje = accesoDatos.Mensaje; 
            }
            catch (Exception)
            {
                throw;
            }

            return id;
        }//Fin del metodo insertar

        public DataSet Listar(string condicion, string orden)
        {
            DataSet DS;
            DAcitasWeb accesoDatos = new DAcitasWeb(_cadenaConexion);
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

        public int Eliminar(EntidadCitasWeb citas)
        {
            int resultado;
            DAcitasWeb accesoDatos = new DAcitasWeb(_cadenaConexion);
            try
            {
                //Aqui se pueden hacer las validaciones
                //o agregar una logica de programacion 
                resultado = accesoDatos.Eliminar(citas);
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }


    }
}
