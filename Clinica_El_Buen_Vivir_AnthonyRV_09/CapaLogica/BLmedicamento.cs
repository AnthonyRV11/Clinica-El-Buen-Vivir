using System;
using CapaEntidades;
using CapaAccesoDatos;
using System.Data;
using System.Collections.Generic;

namespace CapaLogica
{
    public class BLmedicamento
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;
        public string Mensaje
        {
            get => _mensaje;
        }
        public BLmedicamento(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public int Insertar(EntidadMedicamento medicamento)//Metodo para insertar de la capa Acceso a datos
        {
            int id_medicamento = 0;
            DAmedicamento accesoDatos = new DAmedicamento(_cadenaConexion);
            try
            {
                id_medicamento = accesoDatos.Insertar(medicamento);
            }
            catch (Exception)
            {
                throw;
            }

            return id_medicamento;
        }//Fin del metodo insertar

        public int Modificar(EntidadMedicamento medicamento)
        {
            DAmedicamento accesoDatos = new DAmedicamento(_cadenaConexion);
            return accesoDatos.Modificar(medicamento);
        }

        public EntidadMedicamento Obtener(int id)
        {
            EntidadMedicamento medicamento;
            DAmedicamento accesoDatos = new DAmedicamento(_cadenaConexion);
            try
            {
                medicamento = accesoDatos.obtener(id);
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener el medicamento: " + ex.Message);
            }
            return medicamento;
        }

        public DataSet Listar(string condicion, string orden)
        {
            DataSet DS;
            DAmedicamento accesoDatos = new DAmedicamento(_cadenaConexion);
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

        public int Eliminar(EntidadMedicamento medicamento)
        {
            int resultado;
            DAmedicamento accesoDatos = new DAmedicamento(_cadenaConexion);
            try
            {
                //Aqui se pueden hacer las validaciones
                //o agregar una logica de programacion 
                resultado = accesoDatos.Eliminar(medicamento);
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }

    }
}
