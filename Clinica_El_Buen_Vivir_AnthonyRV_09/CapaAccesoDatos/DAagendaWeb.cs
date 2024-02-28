using System;
using CapaEntidades;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Collections.Generic;
namespace CapaAccesoDatos
{
    public class DAagendaWeb
    {
        private string _cadenaConexion;
        private string _mensaje;


        public string Mensaje
        {
            get => _mensaje;
        }

        public DAagendaWeb(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public DataSet Listar(string condicion, string orden)//Metodo para lista la lista
        {
            DataSet datos = new DataSet();//Se guarda la tabla de la consulta de SQL
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "Select ID_AGENDA,AW.ID_ESPECIALIDAD, AW.ID_MEDICO,NOMBRE_MEDICO,HORA_INICIO,HORA_FIN from AGENDA_WEB AW JOIN MEDICOS_ESPECIALISTAS MP ON AW.ID_MEDICO = MP.ID_MEDICO";

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
                adapter.Fill(datos, "AGENDA_WEB");
            }
            catch (Exception)
            {
                throw;
            }

            return datos;
        }//Fin del metodo listar


    }
}
