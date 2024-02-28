using System;
using System.Windows.Forms;
using CapaLogica;
using CapaEntidades;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaInterfaz
{
    public partial class FrmCitas : Form
    {
        EntidadCitas citaRegistrada;
        public FrmCitas()
        {
            InitializeComponent();
        }

        private void btnVerAgenda_Click(object sender, EventArgs e)
        {
            FrmAgenda verAgenda = new FrmAgenda();
            verAgenda.Show();
        }

        private void btnVerPaciente_Click(object sender, EventArgs e)
        {
            FrmPacientes verPacientes = new FrmPacientes();
            verPacientes.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private EntidadCitas GenerarEntidad()//Metodo para generar una entidad
        {
            EntidadCitas cita = new EntidadCitas();
            if (!string.IsNullOrEmpty(txtCita.Text))
            {
                citaRegistrada = cita;
            }
            else
            {
                cita = new EntidadCitas();
            }
            cita.setId_Agenda(Convert.ToInt32(txtAgenda.Text));
            cita.setId_Paciente(Convert.ToInt32(txtPaciente.Text));
            return cita;
        }//Fin del metodo para generar entidad

        private void CargarListaDataSet(string condicion = "", string orden = "")//Metodo para cargar lista
        {
            BLcitas logica = new BLcitas(Configuracion.getConnectionString);
            DataSet DScita;
            try
            {
                DScita = logica.Listar(condicion, orden);
                grdCitas.DataSource = DScita;
                grdCitas.DataMember = DScita.Tables["Citas"].TableName;

            }
            catch (Exception)
            {
                MessageBox.Show("Ocurio un error", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//Fin metodo cargar lista

        private void Limpiar()//Metodo limpiar
        {
            txtPaciente.Text = string.Empty;
            txtAgenda.Text = string.Empty;
            txtCita.Text = string.Empty;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            BLcitas logica = new BLcitas(Configuracion.getConnectionString);
            EntidadCitas citas;
            int resultado;
            string Mensaje = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(txtPaciente.Text) && !string.IsNullOrEmpty(txtAgenda.Text))
                {
                    citas = GenerarEntidad();
                    if (!citas.Existe)
                    {
                        resultado = logica.Insertar(citas);
                        Mensaje = "Cita Insertada correctamente";
                    }
                    else
                    {
                        resultado = logica.Modificar(citas);
                        Mensaje = "Cita modificada correctamente";

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

        private void FrmCitas_Load(object sender, EventArgs e)
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EntidadCitas cita;
            int resultado;
            BLcitas logica = new BLcitas(Configuracion.getConnectionString);
            try
            {
                if (!string.IsNullOrEmpty(txtCita.Text))
                {
                    cita = logica.Obtener(int.Parse(txtCita.Text));
                    if (cita != null)
                    {
                        resultado = logica.Eliminar(cita);
                        MessageBox.Show("Eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        CargarListaDataSet();
                    }
                    else
                    {
                        MessageBox.Show("Esta cita no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        CargarListaDataSet();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una cita", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cargar(int id)
        {
            EntidadCitas cita = new EntidadCitas();
            BLcitas traer = new BLcitas(Configuracion.getConnectionString);

            try
            {
                cita = traer.Obtener(id);
                if (cita != null)
                {
                    txtCita.Text = cita.Id_Cita.ToString();
                    txtAgenda.Text = cita.Id_agenda.ToString();
                    txtPaciente.Text = cita.Id_paciente.ToString();
                }
                else
                {
                    MessageBox.Show("La cita no esta en la base de datos", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            int id = Convert.ToInt32(txtCita.Text);
            Cargar(id);
        }
    }
}
