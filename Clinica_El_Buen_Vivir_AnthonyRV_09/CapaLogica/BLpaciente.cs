using System;
using CapaEntidades;
using CapaAccesoDatos;
using System.Data;
using System.Collections.Generic;

namespace CapaLogica
{
    public class BLpaciente
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;
        public string Mensaje
        {
            get => _mensaje;
        }
        public BLpaciente(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }


        public int Insertar(EntidadPaciente paciente)//Metodo para insertar de la capa Acceso a datos
        {
            int id_paciente = 0;
            DApaciente accesoDatos = new DApaciente(_cadenaConexion);
            try
            {
                id_paciente = accesoDatos.Insertar(paciente);
                _mensaje = accesoDatos.Mensaje;
            }
            catch (Exception)
            {
                throw;
            }

            return id_paciente;
        }//Fin del metodo insertar

        public int Modificar(EntidadPaciente paciente)
        {
            int resultado;
            DApaciente accesoDatos = new DApaciente(_cadenaConexion);
            try
            {
                resultado = accesoDatos.Modificar(paciente);
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }


        public EntidadPaciente Obtener(int id)
        {
            EntidadPaciente paciente;
            DApaciente accesoDatos = new DApaciente(_cadenaConexion);
            try
            {
                paciente = accesoDatos.obtener(id);
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener el paciente: " + ex.Message);
            }
            return paciente;
        }

        public DataSet Listar(string condicion, string orden)
        {
            DataSet DS;
            DApaciente accesoDatos = new DApaciente(_cadenaConexion);
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

        public int Eliminar(EntidadPaciente paciente)
        {
            int resultado;
            DApaciente accesoDatos = new DApaciente(_cadenaConexion);
            try
            {
                //Aqui se pueden hacer las validaciones
                //o agregar una logica de programacion 
                resultado = accesoDatos.Eliminar(paciente);
                _mensaje = accesoDatos.Mensaje;
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }
    }
}

