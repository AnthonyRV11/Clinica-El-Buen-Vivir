using System;
using CapaEntidades;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace CapaAccesoDatos
{
    public class DAcitas
    {
        private string _cadenaConexion;
        private string _mensaje;


        public string Mensaje
        {
            get => _mensaje;
        }

        public DAcitas(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public int Insertar(EntidadCitas cita)//Metodo para insertar un administrador
        {
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            int id = 0;
            string sentencia = "INSERT INTO CITAS (ID_AGENDA,ID_PACIENTE) VALUES(@ID_AGENDA,@ID_PACIENTE) select @@identity";
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID_AGENDA", cita.Id_agenda);
            comando.Parameters.AddWithValue("@ID_PACIENTE", cita.Id_paciente);
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

        public int Modificar(EntidadCitas cita)//Metodo para modificar un administrador
        {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "UPDATE CITAS SET ID_AGENDA= @ID_AGENDA,ID_PACIENTE = @ID_PACIENTE  WHERE ID_CITA= @ID";
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID", cita.Id_Cita);
            comando.Parameters.AddWithValue("@ID_AGENDA", cita.Id_agenda);
            comando.Parameters.AddWithValue("@ID_PACIENTE", cita.Id_paciente);
            try
            {
                conexion.Open();
                filasAfectadas = comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al modificar la cita" + ex.Message);
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }
            return filasAfectadas;
        }//Fin del metodo modificar

        public EntidadCitas obtener(int id)//Metodo obtener
        {
            EntidadCitas cita = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader; //No tiene constructor, se llena con el execute
            string sentencia = string.Format("SELECT ID_CITA, ID_AGENDA,ID_PACIENTE FROM CITAS WHERE ID_CITA = {0}", id);

            //Si el id es texto se escribe entre comillas 
            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try
            {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    cita = new EntidadCitas();
                    dataReader.Read(); //Lee fila or fila del dataReader
                    cita.Id_Cita = dataReader.GetInt32(0);
                    cita.Id_agenda = dataReader.GetInt32(1);
                    cita.Id_paciente = dataReader.GetInt32(2);
                    cita.Existe = true;
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return cita;
        }//Fin del metodo obtener

        public DataSet Listar(string condicion, string orden)//Metodo para lista la lista
        {
            DataSet datos = new DataSet();//Se guarda la tabla de la consulta de SQL
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "Select ID_CITA,ID_AGENDA,ID_PACIENTE from CITAS";

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
                adapter.Fill(datos, "CITAS");
            }
            catch (Exception)
            {
                throw;
            }

            return datos;
        }//Fin del metodo listar

        public int Eliminar(EntidadCitas cita)//Metodo para eliminar administrador
        {
            int afectado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "DELETE FROM CITAS";
            sentencia = string.Format("{0} WHERE ID_CITA = {1}", sentencia, cita.Id_Cita);
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
