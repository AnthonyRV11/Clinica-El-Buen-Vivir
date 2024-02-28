using System;
using CapaEntidades;
using CapaAccesoDatos;
using System.Data;
using System.Collections.Generic;

namespace CapaLogica
{
    public class BLespecialidad
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;
        public string Mensaje
        {
            get => _mensaje;
        }
        public BLespecialidad(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public int Insertar(EntidadEspecialidades espe)//Metodo para insertar de la capa Acceso a datos
        {
            int id = 0;
            DAespecialidad accesoDatos = new DAespecialidad(_cadenaConexion);
            try
            {
                id = accesoDatos.Insertar(espe);
            }
            catch (Exception)
            {
                throw;
            }

            return id;
        }//Fin del metodo insertar

        public int Modificar(EntidadEspecialidades espe)
        {
            DAespecialidad accesoDatos = new DAespecialidad(_cadenaConexion);
            return accesoDatos.Modificar(espe);
        }

        public EntidadEspecialidades Obtener(int id)
        {
            EntidadEspecialidades espe;
            DAespecialidad accesoDatos = new DAespecialidad(_cadenaConexion);
            try
            {
                espe = accesoDatos.obtener(id);
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener la especialidad: " + ex.Message);
            }
            return espe;
        }

        public DataSet Listar(string condicion, string orden)
        {
            DataSet DS;
            DAespecialidad accesoDatos = new DAespecialidad(_cadenaConexion);
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

        public int Eliminar(EntidadEspecialidades espe)
        {
            int resultado;
            DAespecialidad accesoDatos = new DAespecialidad(_cadenaConexion);
            try
            {
                //Aqui se pueden hacer las validaciones
                //o agregar una logica de programacion 
                resultado = accesoDatos.Eliminar(espe);
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }

    }
}
