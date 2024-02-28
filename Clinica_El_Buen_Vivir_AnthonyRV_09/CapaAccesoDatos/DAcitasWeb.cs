using System;
using CapaEntidades;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace CapaAccesoDatos
{
    public class DAcitasWeb
    {
        private string _cadenaConexion;
        private string _mensaje;


        public string Mensaje
        {
            get => _mensaje;
        }

        public DAcitasWeb(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public int Insertar(EntidadCitasWeb cita)//Metodo para insertar un administrador
        {
            int resultado = 1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "InsertarCita";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Connection = conexion;

            comando.Parameters.AddWithValue("@ID_AGENDA", cita.Id_agenda);
            comando.Parameters.AddWithValue("@ID_PACIENTE", cita.Id_paciente);
            comando.Parameters.AddWithValue("@HORARIO", cita.Horario);

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

        public DataSet Listar(string condicion, string orden)//Metodo para lista la lista
        {
            DataSet datos = new DataSet();//Se guarda la tabla de la consulta de SQL
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "Select ID_CITA,ID_AGENDA,P.ID_PACIENTE,P.NOMBRE_PACIENTE,HORARIO from CITAS_WEB CW JOIN PACIENTES P ON CW.ID_PACIENTE = P.ID_PACIENTE ";

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
                adapter.Fill(datos, "CITAS_WEB");
            }
            catch (Exception)
            {
                throw;
            }

            return datos;
        }//Fin del metodo listar

        public int Eliminar(EntidadCitasWeb cita)//Metodo para eliminar administrador
        {
            int afectado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "DELETE FROM CITAS_WEB";
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
