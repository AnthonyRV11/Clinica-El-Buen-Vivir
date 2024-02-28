using System;
using System.Windows.Forms;
using CapaLogica;
using CapaEntidades;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaInterfaz
{
    public partial class FrmAgenda : Form
    {
        EntidadAgenda agendaRegistrado;
        public FrmAgenda()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnVerMedicos_Click(object sender, EventArgs e)
        {
            FrmMedicos frmVermedicos = new FrmMedicos();
            frmVermedicos.Show();
        }

        private EntidadAgenda GenerarEntidad()//Metodo para generar una entidad
        {
            EntidadAgenda agenda = new EntidadAgenda();
            if (!string.IsNullOrEmpty(txtAgenda.Text))
            {
                agendaRegistrado = agenda;
            }
            else
            {
                agenda = new EntidadAgenda();
            }
            agenda.setMedico(Convert.ToInt32(txtMedico.Text));
            agenda.setFecha(Convert.ToDateTime(dtpFecha.Text));
            agenda.setDisponibilidad(txtDisponible.Text);
            return agenda;
        }//Fin del metodo para generar entidad

        private void CargarListaDataSet(string condicion = "", string orden = "")//Metodo para cargar lista
        {
            BLagenda logica = new BLagenda(Configuracion.getConnectionString);
            DataSet DSagenda;
            try
            {
                DSagenda = logica.Listar(condicion, orden);
                grdAgenda.DataSource = DSagenda;
                grdAgenda.DataMember = DSagenda.Tables["AGENDA_MEDICOS"].TableName;

            }
            catch (Exception)
            {
                MessageBox.Show("Ocurio un error", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//Fin metodo cargar lista

        private void Limpiar()//Metodo limpiar
        {
            txtMedico.Text = string.Empty;
            txtAgenda.Text = string.Empty;
            txtDisponible.Text = string.Empty;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            BLagenda logica = new BLagenda(Configuracion.getConnectionString);
            EntidadAgenda agenda;
            int resultado;
            string Mensaje = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(txtAgenda.Text) && !string.IsNullOrEmpty(txtMedico.Text) && !string.IsNullOrEmpty(txtDisponible.Text))
                {
                    agenda = GenerarEntidad();
                    if (!agenda.Existe)
                    {
                        resultado = logica.Insertar(agenda);
                        Mensaje = "Agenda Insertada correctamente";
                    }
                    else
                    {
                        resultado = logica.Modificar(agenda);
                        Mensaje = "Agenda modificada correctamente";

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

        private void FrmAgenda_Load(object sender, EventArgs e)
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
            EntidadAgenda agenda;
            int resultado;
            BLagenda logica = new BLagenda(Configuracion.getConnectionString);
            try
            {
                if (!string.IsNullOrEmpty(txtAgenda.Text))
                {
                    agenda = logica.Obtener(int.Parse(txtAgenda.Text));
                    if (agenda != null)
                    {
                        resultado = logica.Eliminar(agenda);
                        MessageBox.Show("Eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        CargarListaDataSet();
                    }
                    else
                    {
                        MessageBox.Show("Agenda no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        CargarListaDataSet();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una agenda", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cargar(int id)
        {
            EntidadAgenda agenda = new EntidadAgenda();
            BLagenda traer = new BLagenda(Configuracion.getConnectionString);

            try
            {
                agenda = traer.Obtener(id);
                if (agenda != null)
                {
                    txtAgenda.Text = agenda.Id_Agenda.ToString();
                    txtMedico.Text = agenda.Id_Medico.ToString();
                    dtpFecha.Text = agenda.FechaHora.ToString();
                    txtDisponible.Text = agenda.Disponibilidad;
                }
                else
                {
                    MessageBox.Show("La agenda no esta en la base de datos", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            int id = Convert.ToInt32(txtAgenda.Text);
            Cargar(id);
        }
    }
}
