using System;
using CapaEntidades;
using CapaAccesoDatos;
using System.Data;
using System.Collections.Generic;

namespace CapaLogica
{
    public class BLagenda
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;
        public string Mensaje
        {
            get => _mensaje;
        }
        public BLagenda(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public int Insertar(EntidadAgenda agenda)//Metodo para insertar de la capa Acceso a datos
        {
            int id = 0;
            DAagenda accesoDatos = new DAagenda(_cadenaConexion);
            try
            {
                id = accesoDatos.Insertar(agenda);
            }
            catch (Exception)
            {
                throw;
            }

            return id;
        }//Fin del metodo insertar

        public int Modificar(EntidadAgenda agenda)
        {
            DAagenda accesoDatos = new DAagenda(_cadenaConexion);
            return accesoDatos.Modificar(agenda);
        }

        public EntidadAgenda Obtener(int id)
        {
            EntidadAgenda agenda;
            DAagenda accesoDatos = new DAagenda(_cadenaConexion);
            try
            {
                agenda = accesoDatos.obtener(id);
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener la agenda: " + ex.Message);
            }
            return agenda;
        }

        public DataSet Listar(string condicion, string orden)
        {
            DataSet DS;
            DAagenda accesoDatos = new DAagenda(_cadenaConexion);
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

        public int Eliminar(EntidadAgenda agenda)
        {
            int resultado;
            DAagenda accesoDatos = new DAagenda(_cadenaConexion);
            try
            {
                //Aqui se pueden hacer las validaciones
                //o agregar una logica de programacion 
                resultado = accesoDatos.Eliminar(agenda);
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }

    }
}
