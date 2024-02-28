using System;
using CapaEntidades;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Collections.Generic;
namespace CapaAccesoDatos
{
    public class DAagenda
    {
        private string _cadenaConexion;
        private string _mensaje;


        public string Mensaje
        {
            get => _mensaje;
        }

        public DAagenda(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public int Insertar(EntidadAgenda agenda)//Metodo para insertar un administrador
        {
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            int id = 0;
            string sentencia = "INSERT INTO AGENDA_MEDICOS(ID_MEDICO,FECHA_HORA,DISPONIBILIDAD) VALUES(@ID,@FECHA,@DISPONIBILIDAD) select @@identity";
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID", agenda.Id_Medico);
            comando.Parameters.AddWithValue("@FECHA", agenda.FechaHora);
            comando.Parameters.AddWithValue("@DISPONIBILIDAD", agenda.Disponibilidad);
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

        public int Modificar(EntidadAgenda agenda)//Metodo para modificar un administrador
        {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "UPDATE AGENDA_MEDICOS SET ID_MEDICO= @ID,FECHA_HORA = @FECHA, DISPONIBILIDAD = @DISPONIBILIDAD  WHERE ID_AGENDA= @ID_AGENDA";
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID_AGENDA", agenda.Id_Agenda);
            comando.Parameters.AddWithValue("@ID", agenda.Id_Medico);
            comando.Parameters.AddWithValue("@FECHA", agenda.FechaHora);
            comando.Parameters.AddWithValue("@DISPONIBILIDAD", agenda.Disponibilidad);
            try
            {
                conexion.Open();
                filasAfectadas = comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al modificar la agenda: " + ex.Message);
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }
            return filasAfectadas;
        }//Fin del metodo modificar

        public EntidadAgenda obtener(int id)//Metodo obtener
        {
            EntidadAgenda agenda = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader; //No tiene constructor, se llena con el execute
            string sentencia = string.Format("SELECT ID_AGENDA, ID_MEDICO, FECHA_HORA,DISPONIBILIDAD FROM AGENDA_MEDICOS WHERE ID_AGENDA = {0}", id);

            //Si el id es texto se escribe entre comillas 
            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try
            {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    agenda = new EntidadAgenda();
                    dataReader.Read(); //Lee fila or fila del dataReader
                    agenda.Id_Agenda = dataReader.GetInt32(0);
                    agenda.Id_Medico = dataReader.GetInt32(1);
                    agenda.FechaHora = dataReader.GetDateTime(2);
                    agenda.Disponibilidad = dataReader.GetString(3);
                    agenda.Existe = true;
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return agenda;
        }//Fin del metodo obtener

        public DataSet Listar(string condicion, string orden)//Metodo para lista la lista
        {
            DataSet datos = new DataSet();//Se guarda la tabla de la consulta de SQL
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "Select ID_AGENDA, ID_MEDICO, FECHA_HORA,DISPONIBILIDAD from AGENDA_MEDICOS";

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
                adapter.Fill(datos, "AGENDA_MEDICOS");
            }
            catch (Exception)
            {
                throw;
            }

            return datos;
        }//Fin del metodo listar

        public int Eliminar(EntidadAgenda agenda)//Metodo para eliminar administrador
        {
            int afectado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "DELETE FROM AGENDA_MEDICOS";
            sentencia = string.Format("{0} WHERE ID_AGENDA = {1}", sentencia, agenda.Id_Agenda);
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
