using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidades;
using CapaLogica;

namespace SitioWeb
{
    public partial class Pacientes : System.Web.UI.Page
    {
        //Mensaje global
        string mensajeScript = string.Empty;
        
        /// <summary>
        ///Funcion para poder cargar la lista con todos los pacientes 
        /// </summary>
        /// <param name="condicion"></param>
        /// <param name="orden"></param>
        private void CargarListaDataSet(string condicion = "", string orden = "")
        {
            //carga el datagridview con el dataset
            BLpaciente logica = new BLpaciente(clsConfiguracion.getConnectionString);
            DataSet DS;

            try
            {
                DS = logica.Listar(condicion, orden);
                grdPacientes.DataSource = DS;
                grdPacientes.DataMember = DS.Tables[0].TableName;
                //Para que se visualicen los datos en web 
                grdPacientes.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }// fin CargarListaDataSet

        /// <summary>
        /// Accion para cargar todos los datos de los clientes cuando se carga la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //Se ejecuta cuando se refresca la pagina
            try
            {
                if (!IsPostBack)
                {
                    CargarListaDataSet();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }//Fin del cargar pagina

        /// <summary>
        /// Accion al boton buscar, dando como condicion de busqueda el nombre o similares
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string condicion = string.Format("NOMBRE_PACIENTE LIKE '%{0}%' ", TxtNombre.Text);
                CargarListaDataSet(condicion);
            }
            catch (Exception ex)
            {
                mensajeScript = string.Format("javascript:MostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }//Fin del evento al boton buscar

        /// <summary>
        /// Accion al boton de eliminar que llama el metodo de eliminar comprobando en la base de datos si se puede o no 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LnkEliminar_Command(object sender, CommandEventArgs e)
        {
            // leeer el idque es enviado por el commandaevet
            int id = int.Parse(e.CommandArgument.ToString());
            BLpaciente logica = new BLpaciente(clsConfiguracion.getConnectionString);
            EntidadPaciente paciente;
            try
            {
                paciente = logica.Obtener(id);
                if (paciente.Existe)
                {
                    if (logica.Eliminar(paciente) > 0)
                    {
                        // mensaje
                        mensajeScript = string.Format("javascript:MostrarMensaje('{0}')", logica.Mensaje);
                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);

                        CargarListaDataSet();
                        TxtNombre.Text = string.Empty;

                    }
                    else
                    {
                        mensajeScript = string.Format("javascript:MostrarMensaje('{0}')", logica.Mensaje);
                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                    }
                }

            }
            catch (Exception ex)
            {
                mensajeScript = string.Format("javascript:MostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }//Fin del evento al eliminar

        /// <summary>
        /// Accion al boton de modificar que redirecciona al formulario cargando todos los datos para modificar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LnkModificar_Command(object sender, CommandEventArgs e)
        {
            Session["id_del_paciente"] = e.CommandArgument.ToString();
            //Redireccionamos 
            Response.Redirect("AdministrarPacientes.aspx");
        }//Fin del evento al modificar

        /// <summary>
        /// Accion al boton agregar que redirecciona al formulario para poder agregar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            Session["id_del_paciente"] = null;
            Response.Redirect("AdministrarPacientes.aspx");
        }//Fin del evento al agregar

        /// <summary>
        /// Accion al boton seleccionar que carga todos los datos en la pagina de agendar cita
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LnkSeleccionar_Command(object sender, CommandEventArgs e)
        {
            Session["id_del_paciente"] = e.CommandArgument.ToString();
            //Redireccionamos 
            Response.Redirect("AgendarCitas.aspx");
        }//Fin del evento al seleccionar

        /// <summary>
        /// Accion al formulario para poder cargar datos en otra pagina de la lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdPacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPacientes.PageIndex = e.NewPageIndex;
            CargarListaDataSet();
        }

        /// <summary>
        /// Accion al boton para poder direccionar los datos y ver las citas del paciente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LnkPaciente_Command(object sender, CommandEventArgs e)
        {
            Session["id_del_paciente"] = e.CommandArgument.ToString();
            //Redireccionamos 
            Response.Redirect("Citas.aspx");
        }
    }
}