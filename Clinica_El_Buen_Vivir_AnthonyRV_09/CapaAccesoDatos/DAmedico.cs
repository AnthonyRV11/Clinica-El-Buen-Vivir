using System;
using CapaEntidades;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace CapaAccesoDatos
{
    public class DAmedico
    {
        private string _cadenaConexion;
        private string _mensaje;


        public string Mensaje
        {
            get => _mensaje;
        }

        public DAmedico(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public int Insertar(EntidadMedico medi)//Metodo para insertar un administrador
        {
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            int id = 0;
            string sentencia = "INSERT INTO MEDICOS_ESPECIALISTAS (ID_ESPECIALIDAD , NOMBRE_MEDICO, APELLIDO1,APELLIDO2,CEDULA,TELEFONO,CORREO,EXPERIENCIA) VALUES(@ID_ESPECIALIDAD , @NOMBRE_MEDICO, @APELLIDO1,@APELLIDO2,@CEDULA,@TELEFONO,@CORREO,@EXPERIENCIA) select @@identity";
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID_ESPECIALIDAD", medi.Id_especialidad);
            comando.Parameters.AddWithValue("@NOMBRE_MEDICO", medi.Nombre);
            comando.Parameters.AddWithValue("@APELLIDO1", medi.Apellida1);
            comando.Parameters.AddWithValue("@APELLIDO2", medi.Apellido2);
            comando.Parameters.AddWithValue("@CEDULA", medi.Cedula);
            comando.Parameters.AddWithValue("@TELEFONO", medi.Telefono);
            comando.Parameters.AddWithValue("@CORREO", medi.Correo);
            comando.Parameters.AddWithValue("@EXPERIENCIA", medi.Experiencia);
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

        public int Modificar(EntidadMedico medi)//Metodo para modificar un administrador
        {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "UPDATE MEDICOS_ESPECIALISTAS SET ID_ESPECIALIDAD= @ID_ESPECIALIDAD, NOMBRE_MEDICO= @NOMBRE_MEDICO, APELLIDO1= @APELLIDO1,APELLIDO2= @APELLIDO2,CEDULA = @CEDULA, TELEFONO=@TELEFONO,CORREO = @CORREO,EXPERIENCIA = @EXPERIENCIA WHERE ID_MEDICO= @ID_MEDICO";
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID_MEDICO", medi.Id_Medico);
            comando.Parameters.AddWithValue("@ID_ESPECIALIDAD", medi.Id_especialidad);
            comando.Parameters.AddWithValue("@NOMBRE_MEDICO", medi.Nombre);
            comando.Parameters.AddWithValue("@APELLIDO1", medi.Apellida1);
            comando.Parameters.AddWithValue("@APELLIDO2", medi.Apellido2);
            comando.Parameters.AddWithValue("@CEDULA", medi.Cedula);
            comando.Parameters.AddWithValue("@TELEFONO", medi.Telefono);
            comando.Parameters.AddWithValue("@CORREO", medi.Correo);
            comando.Parameters.AddWithValue("@EXPERIENCIA", medi.Experiencia);
            try
            {
                conexion.Open();
                filasAfectadas = comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al modificar el medico: " + ex.Message);
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }
            return filasAfectadas;
        }//Fin del metodo modificar

        public EntidadMedico obtener(int id)//Metodo obtener
        {
            EntidadMedico medi = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader; //No tiene constructor, se llena con el execute
            string sentencia = string.Format("SELECT ID_MEDICO,ID_ESPECIALIDAD , NOMBRE_MEDICO, APELLIDO1,APELLIDO2,CEDULA,TELEFONO,CORREO,EXPERIENCIA FROM MEDICOS_ESPECIALISTAS WHERE ID_MEDICO = {0}", id);

            //Si el id es texto se escribe entre comillas 
            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try
            {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    medi = new EntidadMedico();
                    dataReader.Read(); //Lee fila or fila del dataReader
                    medi.Id_Medico = dataReader.GetInt32(0);
                    medi.Id_especialidad = dataReader.GetInt32(1);
                    medi.Nombre = dataReader.GetString(2);
                    medi.Apellida1 = dataReader.GetString(3);
                    medi.Apellido2 = dataReader.GetString(4);
                    medi.Cedula = dataReader.GetString(5);
                    medi.Telefono = dataReader.GetString(6);
                    medi.Correo = dataReader.GetString(7);
                    medi.Experiencia = dataReader.GetInt32(2);
                    medi.Existe = true;
                }
                conexion.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return medi;
        }//Fin del metodo obtener

        public DataSet Listar(string condicion, string orden)//Metodo para lista la lista
        {
            DataSet datos = new DataSet();//Se guarda la tabla de la consulta de SQL
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "Select ID_MEDICO,ID_ESPECIALIDAD , NOMBRE_MEDICO, APELLIDO1,APELLIDO2,CEDULA,TELEFONO,CORREO,EXPERIENCIA  from MEDICOS_ESPECIALISTAS";

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
                adapter.Fill(datos, "MEDICOS_ESPECIALISTAS");
            }
            catch (Exception)
            {
                throw;
            }

            return datos;
        }//Fin del metodo listar

        public int Eliminar(EntidadMedico medi)//Metodo para eliminar administrador
        {
            int afectado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "DELETE FROM MEDICOS_ESPECIALISTAS";
            sentencia = string.Format("{0} WHERE ID_MEDICO = {1}", sentencia, medi.Id_Medico);
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
