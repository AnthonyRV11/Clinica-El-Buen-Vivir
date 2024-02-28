using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;
using CapaLogica;
using System.Data;

namespace SitioWeb
{
    public partial class AgendarCitas : System.Web.UI.Page
    {
        //Variable global para el mensaje 
        string mensajeScript = string.Empty;

        /// <summary>
        /// Funcion para limpiar todos los datos en pantalla
        /// </summary>
        public void Limpiar()
        {
            TxtId.Text = string.Empty;
            TxtNombre.Text = string.Empty;
            TxtTelefono.Text = string.Empty;
            TxtCorreo.Text = string.Empty;
            TxtApellido1.Text = string.Empty;
            TxtApellido2.Text = string.Empty;
            TxtCedula.Text = string.Empty;
        }

        /// <summary>
        /// Funcion para generar la entidad de la cita web
        /// </summary>
        /// <returns></returns>
        private EntidadCitasWeb GenerarEntidad()
        {
            EntidadCitasWeb cita = new EntidadCitasWeb();

            cita.Id_agenda = Convert.ToInt32(TxtIdAgenda.Text);
            cita.Id_paciente = Convert.ToInt32(TxtId.Text);
            cita.Horario = TimeSpan.Parse(TxtHorario.Text);
            return cita;
        }

        /// <summary>
        /// Funcion para cargar la pantalla en un inicio 
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
                            TxtTelefono.Text = clientes.Telefono1;
                            TxtCorreo.Text = clientes.Correo1;
                            TxtApellido1.Text = clientes.Apellida11;
                            TxtApellido2.Text = clientes.Apellido21;
                            TxtCedula.Text = clientes.Cedula1;
                            TxtId.Visible = true;
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
        /// Funcion para cargar la lista de la agenda de un especialista en especifico
        /// </summary>
        /// <param name="condicion"></param>
        /// <param name="orden"></param>
        private void CargarListaDataSet(string condicion = "", string orden = "")
        {
            //carga el datagridview con el dataset
            BLagendaWeb logica = new BLagendaWeb(clsConfiguracion.getConnectionString);
            DataSet DS;

            condicion= $"MP.ID_ESPECIALIDAD = {DropDownList1.SelectedValue}";

            try
            {
                DS = logica.Listar(condicion, orden);
                grdAgenda.DataSource = DS;
                grdAgenda.DataMember = DS.Tables[0].TableName;
                //Para que se visualicen los datos en web 
                grdAgenda.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }// fin CargarListaDataSet


        /// <summary>
        /// Funcion que direcciona para buscar un paciente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pacientes.aspx");
        }

        /// <summary>
        /// Accion al boton que llama el limpiar los datos del paciente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Boton que llama el cargar la lista 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnEspecialidad_Click(object sender, EventArgs e)
        {
            CargarListaDataSet();
        }

        /// <summary>
        /// Funcion al formulario para poder pasar la pagina 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdAgenda_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAgenda.PageIndex = e.NewPageIndex;
            CargarListaDataSet();
        }

        /// <summary>
        /// Funcion al boton de selecionar que carga todos los datos del paciente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LnkSeleccionar_Command(object sender, CommandEventArgs e)
        {
            string agenda = e.CommandArgument.ToString();

            foreach (GridViewRow r in grdAgenda.Rows)
            {
                if (r.Cells[0].Text == agenda)
                {
                    TxtIdAgenda.Text = r.Cells[0].Text;
                    TxtIdEspecialidad.Text = r.Cells[1].Text;
                    TxtIdMedico.Text = r.Cells[2].Text;
                    TxtNombreMedico.Text = r.Cells[3].Text;
                    TxtInicio.Text = r.Cells[4].Text;
                    TxtFin.Text = r.Cells[5].Text;
                    PlnAgendarCita.Visible = true;
                    PlnAgendaMedico.Visible = true;
                }
            }
           
        }

        /// <summary>
        /// Accion al boton agendar cita que verifica todos los datos con el precidimientto almacenado que verifica todo en la base de datos para poder agendar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnAgendar_Click(object sender, EventArgs e)
        {
            EntidadCitasWeb Cita;

            BLcitasWeb logica = new BLcitasWeb(clsConfiguracion.getConnectionString);
            int resultado;
            try
            {
                if (!string.IsNullOrEmpty(TxtId.Text) &&
                    !string.IsNullOrEmpty(TxtIdAgenda.Text) &&
                    !string.IsNullOrEmpty(TxtHorario.Text)
                   )
                {
                    Cita = GenerarEntidad();

                    resultado = logica.Insertar(Cita);

                    if (resultado > 0)
                    {
                        Limpiar();
                        mensajeScript = string.Format("javascript:MostrarMensaje('{0}')", logica.Mensaje);
                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                    }
                    else
                    {
                        mensajeScript = string.Format("javascript:MostrarMensaje('{0}')", logica.Mensaje);
                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                    }
                }
                else
                {
                    mensajeScript = string.Format("javascript:MostrarMensaje('Los datos son obligatorios')");
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                }
            }
            catch (Exception ex)
            {

                mensajeScript = string.Format("javascript:MostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);

            }
        }
    }
}