using System;
using CapaEntidades;
using CapaAccesoDatos;
using System.Data;
using System.Collections.Generic;

namespace CapaLogica
{
    public class BLadministrador
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;
        public string Mensaje
        {
            get => _mensaje;
        }
        public BLadministrador(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        
        public int Insertar(EntidadAdministrador admin)//Metodo para insertar de la capa Acceso a datos
        {
            int id_cliente = 0;
            DAadministradores accesoDatos = new DAadministradores(_cadenaConexion);
            try
            {
                id_cliente = accesoDatos.Insertar(admin);
            }
            catch (Exception)
            {
                throw;
            }

            return id_cliente;
        }//Fin del metodo insertar

        public int Modificar(EntidadAdministrador admin)
        {
            DAadministradores accesoDatos = new DAadministradores(_cadenaConexion);
            return accesoDatos.Modificar(admin);
        }


        public EntidadAdministrador Obtener(int id)
        {
            EntidadAdministrador admin;
            DAadministradores accesoDatos = new DAadministradores(_cadenaConexion);
            try
            {
                admin = accesoDatos.obtener(id);
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener el administrador: " + ex.Message);
            }
            return admin;
        }

        public DataSet Listar(string condicion, string orden)
        {
            DataSet DS;
            DAadministradores accesoDatos = new DAadministradores(_cadenaConexion);
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

        public int Eliminar(EntidadAdministrador cliente)
        {
            int resultado;
            DAadministradores accesoDatos = new DAadministradores(_cadenaConexion);
            try
            {
                //Aqui se pueden hacer las validaciones
                //o agregar una logica de programacion 
                resultado = accesoDatos.Eliminar(cliente);
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }
    }
}
