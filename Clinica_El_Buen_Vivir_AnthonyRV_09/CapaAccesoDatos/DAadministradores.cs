using System;
using CapaEntidades;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace CapaAccesoDatos
{
    public class DAadministradores
    {
        private string _cadenaConexion;
        private string _mensaje;


        public string Mensaje
        {
            get => _mensaje;
        }

        public DAadministradores(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public int Insertar(EntidadAdministrador admin)//Metodo para insertar un administrador
        {
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            int id = 0;
            string sentencia = "INSERT INTO ADMINISTRADORES (NOMBRE_ADMINISTRADOR, PUESTO_LABORAL, APELLIDO1,APELLIDO2,CEDULA,TELEFONO,CORREO) VALUES(@NOMBRE_ADMINISTRADOR,@PUESTO_LABORAL,@APELLIDO1,@APELLIDO2,@CEDULA,@TELEFONO,@CORREO) select @@identity";
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@NOMBRE_ADMINISTRADOR",admin.Nombre);
            comando.Parameters.AddWithValue("@PUESTO_LABORAL", admin.Puesto);
            comando.Parameters.AddWithValue("@APELLIDO1", admin.Apellido1);
            comando.Parameters.AddWithValue("@APELLIDO2", admin.Apellido2);
            comando.Parameters.AddWithValue("@CEDULA", admin.Cedula);
            comando.Parameters.AddWithValue("@TELEFONO", admin.Telefono);
            comando.Parameters.AddWithValue("@CORREO", admin.Correo);
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

        public int Modificar(EntidadAdministrador admin)//Metodo para modificar un administrador
        {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "UPDATE ADMINISTRADORES SET NOMBRE_ADMINISTRADOR= @NOMBRE_ADMINISTRADOR, PUESTO_LABORAL= @PUESTO_LABORAL, APELLIDO1= @APELLIDO1,APELLIDO2= @APELLIDO2,CEDULA = @CEDULA, TELEFONO=@TELEFONO,CORREO = @CORREO WHERE ID_ADMINISTRADOR= @ID_ADMINISTRADOR";
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID_ADMINISTRADOR", admin.Id_Administrador);
            comando.Parameters.AddWithValue("@NOMBRE_ADMINISTRADOR", admin.Nombre);
            comando.Parameters.AddWithValue("@PUESTO_LABORAL", admin.Puesto);
            comando.Parameters.AddWithValue("@APELLIDO1", admin.Apellido1);
            comando.Parameters.AddWithValue("@APELLIDO2", admin.Apellido2);
            comando.Parameters.AddWithValue("@CEDULA", admin.Cedula);
            comando.Parameters.AddWithValue("@TELEFONO", admin.Telefono);
            comando.Parameters.AddWithValue("@CORREO", admin.Correo);
            try
            {
                conexion.Open();
                filasAfectadas = comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al modificar el administrador: " + ex.Message);
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }
            return filasAfectadas;
        }//Fin del metodo modificar

        public EntidadAdministrador obtener(int id)//Metodo obtener
        {
            EntidadAdministrador admin = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader; //No tiene constructor, se llena con el execute
            string sentencia = string.Format("SELECT ID_ADMINISTRADOR, NOMBRE_ADMINISTRADOR, PUESTO_LABORAL,APELLIDO1,APELLIDO2,CEDULA,TELEFONO,CORREO FROM ADMINISTRADORES WHERE ID_ADMINISTRADOR = {0}", id);

            //Si el id es texto se escribe entre comillas 
            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try
            {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    admin = new EntidadAdministrador();
                    dataReader.Read(); //Lee fila or fila del dataReader
                    admin.Id_Administrador = dataReader.GetInt32(0);
                    admin.Nombre = dataReader.GetString(1);
                    admin.Puesto = dataReader.GetString(2);
                    admin.Apellido1 = dataReader.GetString(3);
                    admin.Apellido2 = dataReader.GetString(4);
                    admin.Cedula = dataReader.GetString(5);
                    admin.Telefono = dataReader.GetString(6);
                    admin.Correo = dataReader.GetString(7);
                    admin.Existe = true;
                }
                conexion.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return admin;
        }//Fin del metodo obtener

        public DataSet Listar(string condicion, string orden)//Metodo para lista la lista
        {
            DataSet datos = new DataSet();//Se guarda la tabla de la consulta de SQL
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "Select ID_ADMINISTRADOR, NOMBRE_ADMINISTRADOR, PUESTO_LABORAL,APELLIDO1,APELLIDO2,CEDULA,TELEFONO,CORREO from ADMINISTRADORES";

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
                adapter.Fill(datos, "ADMINISTRADORES");
            }
            catch (Exception)
            {
                throw;
            }

            return datos;
        }//Fin del metodo listar

        public int Eliminar(EntidadAdministrador admin)//Metodo para eliminar administrador
        {
            int afectado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "DELETE FROM ADMINISTRADORES";
            sentencia = string.Format("{0} WHERE ID_ADMINISTRADOR = {1}", sentencia, admin.Id_Administrador);
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
