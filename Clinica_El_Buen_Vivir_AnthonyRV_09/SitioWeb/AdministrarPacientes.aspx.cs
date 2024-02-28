using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;
using CapaLogica;

namespace SitioWeb
{
    public partial class AdministrarPacientes : System.Web.UI.Page
    {
        //Variable global para mostrar mensaje
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
        /// Funcion para generar la entidad o si existe modificarla
        /// </summary>
        private void GenerarEntidad()
        {
            EntidadPaciente cliente = new EntidadPaciente();
            BLpaciente logica = new BLpaciente(clsConfiguracion.getConnectionString);
            int resultado;

                if (Session["id_del_paciente"] != null)
            {
                // modificar
                cliente.Id_Paciente = int.Parse(Session["id_del_paciente"].ToString());
                cliente.setNombre(TxtNombre.Text);
                cliente.setTelefono(TxtTelefono.Text);
                cliente.setApellido1(TxtApellido1.Text);
                cliente.setApellido2(TxtApellido2.Text);

                cliente.setCorreo(TxtCorreo.Text);
                resultado = logica.Modificar(cliente);
                mensajeScript = string.Format("javascript:MostrarMensaje('Se modificaron los datos correctamente')");
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
            else
            {
                if (TxtNombre.Text != string.Empty &&
                    TxtApellido1.Text != string.Empty &&
                    TxtApellido2.Text != string.Empty &&
                    TxtCedula.Text != string.Empty &&
                    TxtTelefono.Text != string.Empty)
                {
                    // Insertar
                    cliente.setNombre(TxtNombre.Text);
                    cliente.setTelefono(TxtTelefono.Text);
                    cliente.setApellido1(TxtApellido1.Text);
                    cliente.setApellido2(TxtApellido2.Text);
                    cliente.setCedula(TxtCedula.Text);
                    cliente.setCorreo(TxtCorreo.Text);
                    resultado = logica.Insertar(cliente);
                    mensajeScript = string.Format("javascript:MostrarMensaje('{0}')", logica.Mensaje);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                }
                else
                {
                    mensajeScript = string.Format("javascript:MostrarMensaje('Falta informacion para agregar el paciente')");
                }
                
            }
           

        }//fin GenerarEntidad

        /// <summary>
        /// Funcion de inicio para cargar la pantalla
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
                        TxtCedula.ReadOnly = true;
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
                            mensajeScript = string.Format("javascript:MostrarMensaje('Cliente no encontrado')");
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
        /// Funcion que se le asigna al boton de cancelar para direccionar a el formulario de pacientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pacientes.aspx");
        }

        /// <summary>
        /// Funcion que se le da al boton de guardar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            GenerarEntidad();
        }




    }
}