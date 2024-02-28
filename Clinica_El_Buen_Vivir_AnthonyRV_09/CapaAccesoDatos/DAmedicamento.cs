using System;
using CapaEntidades;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace CapaAccesoDatos
{
    public class DAmedicamento
    {
        private string _cadenaConexion;
        private string _mensaje;


        public string Mensaje
        {
            get => _mensaje;
        }

        public DAmedicamento(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public int Insertar(EntidadMedicamento medicamento)//Metodo para insertar un administrador
        {
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            int id = 0;
            string sentencia = "INSERT INTO MEDICAMENTOS (NOMBRE_MEDICAMENTO,CANTIDAD,DESCRIPCION) VALUES(@NOMBRE,@CANTIDAD,@DESCRIPCION) select @@identity";
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@NOMBRE", medicamento.Nombre);
            comando.Parameters.AddWithValue("@CANTIDAD", medicamento.Cantidad);
            comando.Parameters.AddWithValue("@DESCRIPCION", medicamento.Descripcion);
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

        public int Modificar(EntidadMedicamento medicamento)//Metodo para modificar un administrador
        {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "UPDATE MEDICAMENTOS SET NOMBRE_MEDICAMENTO= @NOMBRE,CANTIDAD = @CANTIDAD, DESCRIPCION = @DESCRIPCION  WHERE ID_MEDICAMENTO= @ID";
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID", medicamento.Id_Medicamento);
            comando.Parameters.AddWithValue("@NOMBRE", medicamento.Nombre);
            comando.Parameters.AddWithValue("@CANTIDAD", medicamento.Cantidad);
            comando.Parameters.AddWithValue("@DESCRIPCION", medicamento.Descripcion);
            try
            {
                conexion.Open();
                filasAfectadas = comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al modificar el medicamento: " + ex.Message);
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }
            return filasAfectadas;
        }//Fin del metodo modificar

        public EntidadMedicamento obtener(int id)//Metodo obtener
        {
            EntidadMedicamento medicamento = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader; //No tiene constructor, se llena con el execute
            string sentencia = string.Format("SELECT ID_MEDICAMENTO, NOMBRE_MEDICAMENTO, CANTIDAD,DESCRIPCION FROM MEDICAMENTOS WHERE ID_MEDICAMENTO = {0}", id);

            //Si el id es texto se escribe entre comillas 
            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try
            {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    medicamento = new EntidadMedicamento();
                    dataReader.Read(); //Lee fila or fila del dataReader
                    medicamento.Id_Medicamento = dataReader.GetInt32(0);
                    medicamento.Nombre = dataReader.GetString(1);
                    medicamento.Cantidad = dataReader.GetInt32(2);
                    medicamento.Descripcion = dataReader.GetString(3);
                    medicamento.Existe = true;
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return medicamento;
        }//Fin del metodo obtener

        public DataSet Listar(string condicion, string orden)//Metodo para lista la lista
        {
            DataSet datos = new DataSet();//Se guarda la tabla de la consulta de SQL
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "Select ID_MEDICAMENTO, NOMBRE_MEDICAMENTO, CANTIDAD,DESCRIPCION from MEDICAMENTOS";

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
                adapter.Fill(datos, "MEDICAMENTOS");
            }
            catch (Exception)
            {
                throw;
            }

            return datos;
        }//Fin del metodo listar

        public int Eliminar(EntidadMedicamento medicamento)//Metodo para eliminar administrador
        {
            int afectado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "DELETE FROM MEDICAMENTOS";
            sentencia = string.Format("{0} WHERE ID_MEDICAMENTO = {1}", sentencia, medicamento.Id_Medicamento);
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
