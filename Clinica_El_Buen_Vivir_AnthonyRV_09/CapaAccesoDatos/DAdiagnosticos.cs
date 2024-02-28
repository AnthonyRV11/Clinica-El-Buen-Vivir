using System;
using CapaEntidades;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace CapaAccesoDatos
{
    public class DAdiagnosticos
    {
        private string _cadenaConexion;
        private string _mensaje;


        public string Mensaje
        {
            get => _mensaje;
        }

        public DAdiagnosticos(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public int Insertar(EntidadDiagnosticos diag)//Metodo para insertar un administrador
        {
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            int id = 0;
            string sentencia = "INSERT INTO DIAGNOSTICOS (ID_MEDICAMENTO , ID_CITA,ID_MEDICO,DESCRIPCION) VALUES(@ID_MEDICAMENTO, @ID_CITA, @ID_MEDICO,@DESCRIPCION) select @@identity";
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID_MEDICAMENTO", diag.Id_Medicamento);
            comando.Parameters.AddWithValue("@ID_CITA", diag.Id_Cita);
            comando.Parameters.AddWithValue("@ID_MEDICO", diag.Id_Medico);
            comando.Parameters.AddWithValue("@DESCRIPCION", diag.Descripcion);
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

        public int Modificar(EntidadDiagnosticos diag)//Metodo para modificar un administrador
        {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "UPDATE DIAGNOSTICOS SET ID_MEDICAMENTO= @ID_MEDICAMENTO, ID_CITA= @ID_CITA,ID_MEDICO= @ID_MEDICO,DESCRIPCION= @DESCRIPCION WHERE ID_DIAGNOSTICO= @ID_DIAGNOSTICO";
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID_DIAGNOSTICO", diag.Id_Diagnostico);
            comando.Parameters.AddWithValue("@ID_MEDICAMENTO", diag.Id_Medicamento);
            comando.Parameters.AddWithValue("@ID_CITA", diag.Id_Cita);
            comando.Parameters.AddWithValue("@ID_MEDICO", diag.Id_Medico);
            comando.Parameters.AddWithValue("@DESCRIPCION", diag.Descripcion);
            try
            {
                conexion.Open();
                filasAfectadas = comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al modificar el diagnostico: " + ex.Message);
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }
            return filasAfectadas;
        }//Fin del metodo modificar

        public EntidadDiagnosticos obtener(int id)//Metodo obtener
        {
            EntidadDiagnosticos diag = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader; //No tiene constructor, se llena con el execute
            string sentencia = string.Format("SELECT ID_DIAGNOSTICO,ID_MEDICAMENTO,ID_CITA,ID_MEDICO,DESCRIPCION FROM DIAGNOSTICOS WHERE ID_DIAGNOSTICO = {0}", id);

            //Si el id es texto se escribe entre comillas 
            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try
            {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    diag = new EntidadDiagnosticos();
                    dataReader.Read(); //Lee fila or fila del dataReader
                    diag.Id_Diagnostico = dataReader.GetInt32(0);
                    diag.Id_Medicamento = dataReader.GetInt32(1);
                    diag.Id_Cita = dataReader.GetInt32(2);
                    diag.Id_Medico = dataReader.GetInt32(3);
                    diag.Descripcion = dataReader.GetString(4);
                    diag.Existe = true;
                }
                conexion.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return diag;
        }//Fin del metodo obtener

        public DataSet Listar(string condicion, string orden)//Metodo para lista la lista
        {
            DataSet datos = new DataSet();//Se guarda la tabla de la consulta de SQL
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "Select ID_DIAGNOSTICO,ID_MEDICAMENTO,ID_CITA,ID_MEDICO,DESCRIPCION from DIAGNOSTICOS";

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
                adapter.Fill(datos, "DIAGNOSTICOS");
            }
            catch (Exception)
            {
                throw;
            }

            return datos;
        }//Fin del metodo listar

        public int Eliminar(EntidadDiagnosticos diag)//Metodo para eliminar administrador
        {
            int afectado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "DELETE FROM DIAGNOSTICOS";
            sentencia = string.Format("{0} WHERE ID_DIAGNOSTICO = {1}", sentencia, diag.Id_Diagnostico);
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
