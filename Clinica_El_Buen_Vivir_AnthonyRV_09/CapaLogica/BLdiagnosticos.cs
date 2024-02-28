using System;
using CapaEntidades;
using CapaAccesoDatos;
using System.Data;
using System.Collections.Generic;

namespace CapaLogica
{
    public class BLdiagnosticos
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;
        public string Mensaje
        {
            get => _mensaje;
        }
        public BLdiagnosticos(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public int Insertar(EntidadDiagnosticos diag)//Metodo para insertar de la capa Acceso a datos
        {
            int id = 0;
            DAdiagnosticos accesoDatos = new DAdiagnosticos(_cadenaConexion);
            try
            {
                id = accesoDatos.Insertar(diag);
            }
            catch (Exception)
            {
                throw;
            }

            return id;
        }//Fin del metodo insertar

        public int Modificar(EntidadDiagnosticos diag)
        {
            DAdiagnosticos accesoDatos = new DAdiagnosticos(_cadenaConexion);
            return accesoDatos.Modificar(diag);
        }

        public EntidadDiagnosticos Obtener(int id)
        {
            EntidadDiagnosticos diag;
            DAdiagnosticos accesoDatos = new DAdiagnosticos(_cadenaConexion);
            try
            {
                diag = accesoDatos.obtener(id);
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener el diagnostico: " + ex.Message);
            }
            return diag;
        }

        public DataSet Listar(string condicion, string orden)
        {
            DataSet DS;
            DAdiagnosticos accesoDatos = new DAdiagnosticos(_cadenaConexion);
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

        public int Eliminar(EntidadDiagnosticos diag)
        {
            int resultado;
            DAdiagnosticos accesoDatos = new DAdiagnosticos(_cadenaConexion);
            try
            {
                //Aqui se pueden hacer las validaciones
                //o agregar una logica de programacion 
                resultado = accesoDatos.Eliminar(diag);
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }

    }
}
