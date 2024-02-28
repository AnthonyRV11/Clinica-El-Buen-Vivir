using System;
using CapaEntidades;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace CapaAccesoDatos
{
    public class DAespecialidad
    {
        private string _cadenaConexion;
        private string _mensaje;


        public string Mensaje
        {
            get => _mensaje;
        }

        public DAespecialidad(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public int Insertar(EntidadEspecialidades espe)//Metodo para insertar un administrador
        {
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            int id = 0;
            string sentencia = "INSERT INTO ESPECIALIDADES(NOMBRE_ESPECIALIDAD) VALUES(@NOMBRE) select @@identity";
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@NOMBRE", espe.Nombre_especialidad);
            comando.CommandText = sentencia;
            try
            {
                conexion.Open();
                id = Convert.ToInt32(comando.ExecuteScalar());
                conexion.Close();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }
            return id;
        }//Fin del insertar

        public int Modificar(EntidadEspecialidades espe)//Metodo para modificar un administrador
        {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "UPDATE ESPECIALIDADES SET NOMBRE_ESPECIALIDAD= @NOMBRE WHERE ID_ESPECIALIDAD= @ID";
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID", espe.Id_Especialidad);
            comando.Parameters.AddWithValue("@NOMBRE", espe.Nombre_especialidad);
            try
            {
                conexion.Open();
                filasAfectadas = comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al modificar la especialidad: " + ex.Message);
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }
            return filasAfectadas;
        }//Fin del metodo modificar

        public EntidadEspecialidades obtener(int id)//Metodo obtener
        {
            EntidadEspecialidades espe = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader; //No tiene constructor, se llena con el execute
            string sentencia = string.Format("SELECT ID_ESPECIALIDAD,NOMBRE_ESPECIALIDAD FROM ESPECIALIDADES WHERE ID_ESPECIALIDAD = {0}", id);

            //Si el id es texto se escribe entre comillas 
            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try
            {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    espe = new EntidadEspecialidades();
                    dataReader.Read(); //Lee fila or fila del dataReader
                    espe.Id_Especialidad = dataReader.GetInt32(0);
                    espe.Nombre_especialidad = dataReader.GetString(1);
                    espe.Existe = true;
                }
                conexion.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return espe;
        }//Fin del metodo obtener

        public DataSet Listar(string condicion, string orden)//Metodo para lista la lista
        {
            DataSet datos = new DataSet();//Se guarda la tabla de la consulta de SQL
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "Select ID_ESPECIALIDAD, NOMBRE_ESPECIALIDAD from ESPECIALIDADES";

            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = string.Format("{0} where {1}", sentencia, condicion);
            }

            if (!string.IsNullOrEmpty(orden))
            {
                sentencia = string.Format("{0} where {1}", sentencia, orden);
            }
            try
            {
                //Se prepara adapter 
                adapter = new SqlDataAdapter(sentencia, conexion);
                //ejecutar sentencia
                adapter.Fill(datos, "ESPECIALIDADES");
            }
            catch (Exception)
            {
                throw;
            }

            return datos;
        }//Fin del metodo listar

        public int Eliminar(EntidadEspecialidades espe)//Metodo para eliminar administrador
        {
            int afectado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "DELETE FROM ESPECIALIDADES";
            sentencia = string.Format("{0} WHERE ID_ESPECIALIDAD = {1}", sentencia, espe.Id_Especialidad);
            comando.CommandText = sentencia;
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                afectado = comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }
            return afectado;
        }//Fin metodo eliminar
    }
}
