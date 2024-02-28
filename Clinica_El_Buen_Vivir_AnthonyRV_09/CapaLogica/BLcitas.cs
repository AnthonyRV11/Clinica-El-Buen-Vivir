using System;
using CapaEntidades;
using CapaAccesoDatos;
using System.Data;
using System.Collections.Generic;

namespace CapaLogica
{
    public class BLcitas
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;
        public string Mensaje
        {
            get => _mensaje;
        }
        public BLcitas(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public int Insertar(EntidadCitas cita)//Metodo para insertar de la capa Acceso a datos
        {
            int id = 0;
            DAcitas accesoDatos = new DAcitas(_cadenaConexion);
            try
            {
                id = accesoDatos.Insertar(cita);
            }
            catch (Exception)
            {
                throw;
            }

            return id;
        }//Fin del metodo insertar

        public int Modificar(EntidadCitas cita)
        {
            DAcitas accesoDatos = new DAcitas(_cadenaConexion);
            return accesoDatos.Modificar(cita);
        }

        public EntidadCitas Obtener(int id)
        {
            EntidadCitas cita;
            DAcitas accesoDatos = new DAcitas(_cadenaConexion);
            try
            {
                cita = accesoDatos.obtener(id);
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener la cita: " + ex.Message);
            }
            return cita;
        }

        public DataSet Listar(string condicion, string orden)
        {
            DataSet DS;
            DAcitas accesoDatos = new DAcitas(_cadenaConexion);
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

        public int Eliminar(EntidadCitas citas)
        {
            int resultado;
            DAcitas accesoDatos = new DAcitas(_cadenaConexion);
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
