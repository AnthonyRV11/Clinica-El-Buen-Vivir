using System;
using CapaEntidades;
using CapaAccesoDatos;
using System.Data;
using System.Collections.Generic;

namespace CapaLogica
{
    public class BLmedico
    {
        private string _cadenaConexion;
        private string _mensaje;
        public string Mensaje
        {
            get => _mensaje;
        }
        public BLmedico(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public int Insertar(EntidadMedico medi)//Metodo para insertar de la capa Acceso a datos
        {
            int id_cliente = 0;
            DAmedico accesoDatos = new DAmedico(_cadenaConexion);
            try
            {
                id_cliente = accesoDatos.Insertar(medi);
            }
            catch (Exception)
            {
                throw;
            }

            return id_cliente;
        }//Fin del metodo insertar

        public int Modificar(EntidadMedico medi)
        {
            DAmedico accesoDatos = new DAmedico(_cadenaConexion);
            return accesoDatos.Modificar(medi);
        }

        public EntidadMedico Obtener(int id)
        {
            EntidadMedico medi;
            DAmedico accesoDatos = new DAmedico(_cadenaConexion);
            try
            {
                medi = accesoDatos.obtener(id);
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener el medico: " + ex.Message);
            }
            return medi;
        }

        public DataSet Listar(string condicion, string orden)
        {
            DataSet DS;
            DAmedico accesoDatos = new DAmedico(_cadenaConexion);
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

        public int Eliminar(EntidadMedico medico)
        {
            int resultado;
            DAmedico accesoDatos = new DAmedico(_cadenaConexion);
            try
            {
                //Aqui se pueden hacer las validaciones
                //o agregar una logica de programacion 
                resultado = accesoDatos.Eliminar(medico);
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }
    }
}
