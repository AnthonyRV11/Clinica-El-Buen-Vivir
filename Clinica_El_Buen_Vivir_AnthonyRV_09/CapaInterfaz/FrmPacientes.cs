using System;
using System.Windows.Forms;
using CapaLogica;
using CapaEntidades;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaInterfaz
{
    public partial class FrmPacientes : Form
    {
        EntidadPaciente pacienteRegistrado;
        public FrmPacientes()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private EntidadPaciente GenerarEntidad()//Metodo para generar una entidad
        {
            EntidadPaciente paciente = new EntidadPaciente();
            if (!string.IsNullOrEmpty(txtIdPaciente.Text))
            {
                pacienteRegistrado = paciente;
            }
            else
            {
                paciente = new EntidadPaciente();
            }
            paciente.setNombre(txtNombre.Text);
            paciente.setApellido1(txtApellido1.Text);
            paciente.setApellido2(txtApellido2.Text);
            paciente.setCedula(txtCedula.Text);
            paciente.setTelefono(txtTelefono.Text);
            paciente.setCorreo(txtCorreo.Text);
            return paciente;
        }//Fin del metodo para generar entidad

        private void CargarListaDataSet(string condicion = "", string orden = "")//Metodo para cargar lista
        {
            BLpaciente logica = new BLpaciente(Configuracion.getConnectionString);
            DataSet DSpaciente;
            try
            {
                DSpaciente = logica.Listar(condicion, orden);
                grdPaciente.DataSource = DSpaciente;
                grdPaciente.DataMember = DSpaciente.Tables["Pacientes"].TableName;

            }
            catch (Exception)
            {
                MessageBox.Show("Ocurio un error", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//Fin metodo cargar lista

        private void Limpiar()//Metodo limpiar
        {
            txtIdPaciente.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido1.Text = string.Empty;
            txtApellido2.Text = string.Empty;
            txtCedula.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCorreo.Text = string.Empty;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            BLpaciente logica = new BLpaciente(Configuracion.getConnectionString);
            EntidadPaciente paciente;
            int resultado;
            string Mensaje = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtApellido2.Text) && !string.IsNullOrEmpty(txtApellido1.Text) && !string.IsNullOrEmpty(txtCedula.Text) && !string.IsNullOrEmpty(txtTelefono.Text) && !string.IsNullOrEmpty(txtCorreo.Text))
                {
                    paciente = GenerarEntidad();
                    if (!paciente.Existe)
                    {
                        resultado = logica.Insertar(paciente);
                        Mensaje = "Paciente Insertado correctamente";
                    }
                    else
                    {
                        resultado = logica.Modificar(paciente);
                        Mensaje = "Paciente modificado correctamente";

                    }
                    Limpiar();
                    MessageBox.Show(Mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListaDataSet();
                }
                else
                {
                    MessageBox.Show("Datos Obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmPacientes_Load(object sender, EventArgs e)
        {
            try
            {
                CargarListaDataSet();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            EntidadPaciente paciente;
            int resultado;
            BLpaciente logica = new BLpaciente(Configuracion.getConnectionString);
            try
            {
                if (!string.IsNullOrEmpty(txtIdPaciente.Text))
                {
                    paciente = logica.Obtener(int.Parse(txtIdPaciente.Text));
                    if (paciente != null)
                    {
                        resultado = logica.Eliminar(paciente);
                        MessageBox.Show("Eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        CargarListaDataSet();
                    }
                    else
                    {
                        MessageBox.Show("Paciente no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        CargarListaDataSet();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un paciente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cargar(int id)
        {
            EntidadPaciente paciente = new EntidadPaciente();
            BLpaciente traer = new BLpaciente(Configuracion.getConnectionString);

            try
            {
                paciente = traer.Obtener(id);
                if (paciente != null)
                {
                    txtIdPaciente.Text = paciente.Id_Paciente.ToString();
                    txtNombre.Text = paciente.Nombre1;
                    txtApellido1.Text = paciente.Apellida11;
                    txtApellido2.Text = paciente.Apellido21;
                    txtCedula.Text = paciente.Cedula1;
                    txtTelefono.Text = paciente.Telefono1;
                    txtCorreo.Text = paciente.Correo1;
                }
                else
                {
                    MessageBox.Show("El paciente no esta en la base de datos", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarListaDataSet();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIdPaciente.Text);
            Cargar(id);
        }
    }
}
