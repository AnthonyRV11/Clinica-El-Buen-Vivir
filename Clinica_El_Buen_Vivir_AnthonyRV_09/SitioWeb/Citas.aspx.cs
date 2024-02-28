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
    public partial class Citas : System.Web.UI.Page
    {
        //Mensaje golbal
        string mensajeScript = string.Empty;

        /// <summary>
        /// Funcion para limpiar pantalla
        /// </summary>
        public void Limpiar()
        {
            TxtId.Text = string.Empty;
            TxtNombre.Text = string.Empty;
        }

        /// <summary>
        /// Funcion para cargar la lista de las citas del paciente
        /// </summary>
        /// <param name="condicion"></param>
        /// <param name="orden"></param>
        private void CargarListaDataSet(string condicion = "", string orden = "")
        {
            //carga el datagridview con el dataset
            BLcitasWeb logica = new BLcitasWeb(clsConfiguracion.getConnectionString);
            DataSet DS;

            condicion = $"P.ID_PACIENTE = {TxtId.Text}";

            try
            {
                DS = logica.Listar(condicion, orden);
                grdCitas.DataSource = DS;
                grdCitas.DataMember = DS.Tables[0].TableName;
                //Para que se visualicen los datos en web 
                grdCitas.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }// fin CargarListaDataSet

        /// <summary>
        /// Funcion para cargar los datos con la session que llegue a la pagina principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            EntidadPaciente clientes;
            BLpaciente logica = new BLpaciente(clsConfiguracion.getConnectionString);
            int identificacion;
            try
            {
                if (!Page.IsPostBack)
                {
                    // si el id se obtiene en el otro formulario
                    if (Session["id_del_paciente"] != null)
                    {
                        identificacion = int.Parse(Session["id_del_paciente"].ToString());
                        clientes = logica.Obtener(identificacion);
                        if (clientes.Existe)
                        {
                            TxtId.Text = clientes.Id_Paciente.ToString();
                            TxtNombre.Text = clientes.Nombre1;
                            CargarListaDataSet();
                        }
                        else
                        {// cliete encontrado
                            mensajeScript = string.Format("javascript:MostrarMensaje('Paciente no encontrado')");
                            ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                        }
                    }
                    else
                    {
                        // si la sesion no tiene nada es que agregamaos un nuevo cliente
                        Limpiar();
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeScript = string.Format("javascript:MostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                Response.Redirect("AdministracionClientes.aspx");
            }
        }

        /// <summary>
        /// Accion al boton buscar que busca el paciente en la lista 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pacientes.aspx");
        }

        /// <summary>
        /// Llamamos al boton de buscar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

    }
}