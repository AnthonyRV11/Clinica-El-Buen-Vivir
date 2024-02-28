using System;
using CapaEntidades;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace CapaAccesoDatos
{
    public class DApagos
    {
        private string _cadenaConexion;
        private string _mensaje;


        public string Mensaje
        {
            get => _mensaje;
        }

        public DApagos(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public int Insertar(EntidadPagos pago)//Metodo para insertar un administrador
        {
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            int id = 0;
            string sentencia = "INSERT INTO PAGOS (ID_PACIENTE,ID_ADMINISTRADOR,TOTAL_A_PAGAR,DESCRIPCION_PAGO) VALUES(@ID_PACIENTE,@ID_ADMINISTRADOR,@TOTAL,@DESCRIPCION) select @@identity";
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID_PACIENTE", pago.geId_Paciente());
            comando.Parameters.AddWithValue("@ID_ADMINISTRADOR", pago.getId_Administrador());
            comando.Parameters.AddWithValue("@TOTAL", pago.getTotal());
            comando.Parameters.AddWithValue("@DESCRIPCION", pago.getDescripcion());
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

        public int Modificar(EntidadPagos pago)//Metodo para modificar un administrador
        {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "UPDATE PAGOS SET ID_PACIENTE= @ID_PACIENTE, ID_ADMINISTRADOR= @ID_ADMINISTRADOR,TOTAL_A_PAGAR= @TOTAL_A_PAGAR,DESCRIPCION_PAGO = @DESCRIPCION_PAGO WHERE NUM_FACTURA= @ID";
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID", pago.Num_Factura);
            comando.Parameters.AddWithValue("@ID_PACIENTE", pago.Id_Paciente);
            comando.Parameters.AddWithValue("@ID_ADMINISTRADOR", pago.Id_Administrador);
            comando.Parameters.AddWithValue("@TOTAL_A_PAGAR", pago.Total_Pagar);
            comando.Parameters.AddWithValue("@DESCRIPCION_PAGO", pago.Descripcion);
            try
            {
                conexion.Open();
                filasAfectadas = comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al modificar el pago: " + ex.Message);
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }
            return filasAfectadas;
        }//Fin del metodo modificar

        public EntidadPagos obtener(int id)//Metodo obtener
        {
            EntidadPagos pago = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader; //No tiene constructor, se llena con el execute
            string sentencia = string.Format("SELECT NUM_FACTURA, ID_PACIENTE, ID_ADMINISTRADOR,TOTAL_A_PAGAR,DESCRIPCION_PAGO FROM PAGOS WHERE NUM_FACTURA = {0}", id);

            //Si el id es texto se escribe entre comillas 
            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try
            {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    pago = new EntidadPagos();
                    dataReader.Read(); //Lee fila or fila del dataReader
                    pago.Num_Factura = dataReader.GetInt32(0);
                    pago.Id_Paciente = dataReader.GetInt32(1);
                    pago.Id_Administrador = dataReader.GetInt32(2);
                    pago.Total_Pagar = dataReader.GetDecimal(3);
                    pago.Descripcion = dataReader.GetString(4);
                    pago.Existe = true;
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el pago: " + ex.Message);
                throw;
            }
            return pago;
        }//Fin del metodo obtener

        public DataSet Listar(string condicion, string orden)//Metodo para lista la lista
        {
            DataSet datos = new DataSet();//Se guarda la tabla de la consulta de SQL
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "SELECT NUM_FACTURA, ID_PACIENTE, ID_ADMINISTRADOR,TOTAL_A_PAGAR,DESCRIPCION_PAGO from PAGOS";

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
                adapter.Fill(datos, "PAGOS");
            }
            catch (Exception)
            {
                throw;
            }

            return datos;
        }//Fin del metodo listar

        public int Eliminar(EntidadPagos pagos)//Metodo para eliminar administrador
        {
            int afectado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "DELETE FROM PAGOS";
            sentencia = string.Format("{0} WHERE NUM_FACTURA = {1}", sentencia, pagos.Num_Factura);
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
