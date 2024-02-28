using System;
using CapaEntidades;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace CapaAccesoDatos
{
    public class DApaciente
    {
        private string _cadenaConexion;
        private string _mensaje;


        public string Mensaje
        {
            get => _mensaje;
        }

        public DApaciente(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public int Insertar(EntidadPaciente paciente)//Metodo para insertar un administrador
        {
            int resultado = 1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "InsertarPaciente";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Connection = conexion;

            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@NOMBRE", paciente.Nombre1);
            comando.Parameters.AddWithValue("@APELLIDO1", paciente.Apellida11);
            comando.Parameters.AddWithValue("@APELLIDO2", paciente.Apellido21);
            comando.Parameters.AddWithValue("@CEDULA", paciente.Cedula1);
            comando.Parameters.AddWithValue("@TELEFONO", paciente.Telefono1);
            comando.Parameters.AddWithValue("@CORREO", paciente.Correo1);

            comando.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            //se declara otro parametro de retorno del SP que optenga el retorno de SP
            comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery(); //ejecuta el SP y se llenan las variables de retorno del SP
                resultado = Convert.ToInt32(comando.Parameters["@retorno"].Value);
                _mensaje = comando.Parameters["@MENSAJE"].Value.ToString();
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }//Fin del insertar

        public int Modificar(EntidadPaciente paciente)//Metodo para modificar un administrador
        {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "UPDATE PACIENTES SET NOMBRE_PACIENTE= @NOMBRE, APELLIDO1= @APELLIDO1,APELLIDO2= @APELLIDO2, TELEFONO=@TELEFONO,CORREO = @CORREO WHERE ID_PACIENTE= @ID";
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID", paciente.Id_Paciente);
            comando.Parameters.AddWithValue("@NOMBRE", paciente.Nombre1);
            comando.Parameters.AddWithValue("@APELLIDO1", paciente.Apellida11);
            comando.Parameters.AddWithValue("@APELLIDO2", paciente.Apellido21);
            comando.Parameters.AddWithValue("@TELEFONO", paciente.Telefono1);
            comando.Parameters.AddWithValue("@CORREO", paciente.Correo1);
            try
            {
                conexion.Open();
                filasAfectadas = comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al modificar el paciente: " + ex.Message);
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }
            return filasAfectadas;
        }//Fin del metodo modificar

        public EntidadPaciente obtener(int id)//Metodo obtener
        {
            EntidadPaciente paciente = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader; //No tiene constructor, se llena con el execute
            string sentencia = string.Format("SELECT ID_PACIENTE, NOMBRE_PACIENTE, APELLIDO1,APELLIDO2,CEDULA,TELEFONO,CORREO FROM PACIENTES WHERE ID_PACIENTE = {0}", id);

            //Si el id es texto se escribe entre comillas 
            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try
            {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    paciente = new EntidadPaciente();
                    dataReader.Read(); //Lee fila or fila del dataReader
                    paciente.Id_Paciente = dataReader.GetInt32(0);
                    paciente.Nombre1 = dataReader.GetString(1);
                    paciente.Apellida11 = dataReader.GetString(2);
                    paciente.Apellido21 = dataReader.GetString(3);
                    paciente.Cedula1 = dataReader.GetString(4);
                    paciente.Telefono1 = dataReader.GetString(5);
                    paciente.Correo1 = dataReader.GetString(6);
                    paciente.Existe = true;
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return paciente;
        }//Fin del metodo obtener

        public DataSet Listar(string condicion, string orden)//Metodo para lista la lista
        {
            DataSet datos = new DataSet();//Se guarda la tabla de la consulta de SQL
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "Select ID_PACIENTE, NOMBRE_PACIENTE, APELLIDO1,APELLIDO2,CEDULA,TELEFONO,CORREO from PACIENTES";

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
                adapter.Fill(datos, "PACIENTES");
            }
            catch (Exception)
            {
                throw;
            }

            return datos;
        }//Fin del metodo listar

        public int Eliminar(EntidadPaciente paciente)//Metodo para eliminar administrador
        {
            int afectado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "BorrarPaciente";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@IDPaciente", paciente.Id_Paciente);
            comando.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            //se declara otro parametro de retorno del SP que optenga el retorno de SP
            comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery(); //ejecuta el SP y se llenan las variables de retorno del SP
                afectado = Convert.ToInt32(comando.Parameters["@retorno"].Value);
                _mensaje = comando.Parameters["@MENSAJE"].Value.ToString();
            }
            catch (Exception)
            {
                throw;
            }
            return afectado;
        }//Fin metodo eliminar

    }
}
