using System;
using System.Windows.Forms;
using CapaLogica;
using CapaEntidades;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaInterfaz
{
    public partial class FrmDiagnosticos : Form
    {
        EntidadDiagnosticos diagRegistrado;
        public FrmDiagnosticos()
        {
            InitializeComponent();
        }

        private void btnMedico_Click(object sender, EventArgs e)
        {
            FrmMedicos verlo = new FrmMedicos();
            verlo.Show();
        }

        private void btnVerCita_Click(object sender, EventArgs e)
        {
            FrmCitas verlas = new FrmCitas();
            verlas.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnVerMedicamento_Click(object sender, EventArgs e)
        {
            FrmMedicamento verMedi = new FrmMedicamento();
            verMedi.Show();
        }

        private EntidadDiagnosticos GenerarEntidad()//Metodo para generar una entidad
        {
            EntidadDiagnosticos diag = new EntidadDiagnosticos();
            if (!string.IsNullOrEmpty(txtDiagnostico.Text))
            {
                diagRegistrado = diag;
            }
            else
            {
                diag = new EntidadDiagnosticos();
            }
            diag.setId_Medicamento(Convert.ToInt32(txtId_Medicamento.Text));
            diag.setId_Cita(Convert.ToInt32(txtCita.Text));
            diag.setId_Medico(Convert.ToInt32(txtIdMedico.Text));
            diag.setDescripcion(txtDescripcion.Text);
            return diag;
        }//Fin del metodo para generar entidad

        private void CargarListaDataSet(string condicion = "", string orden = "")//Metodo para cargar lista
        {
            BLdiagnosticos logica = new BLdiagnosticos(Configuracion.getConnectionString);
            DataSet DS;
            try
            {
                DS = logica.Listar(condicion, orden);
                grdVerDiagnosticos.DataSource = DS;
                grdVerDiagnosticos.DataMember = DS.Tables["DIAGNOSTICOS"].TableName;

            }
            catch (Exception)
            {
                MessageBox.Show("Ocurio un error", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//Fin metodo cargar lista

        private void Limpiar()//Metodo limpiar
        {
            txtId_Medicamento.Text = string.Empty;
            txtIdMedico.Text = string.Empty;
            txtDiagnostico.Text = string.Empty;
            txtCita.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            BLdiagnosticos logica = new BLdiagnosticos(Configuracion.getConnectionString);
            EntidadDiagnosticos diag;
            int resultado;
            string Mensaje = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(txtId_Medicamento.Text) && !string.IsNullOrEmpty(txtIdMedico.Text) && !string.IsNullOrEmpty(txtCita.Text) && !string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    diag = GenerarEntidad();
                    if (!diag.Existe)
                    {
                        resultado = logica.Insertar(diag);
                        Mensaje = "Diagnostico Insertado correctamente";
                    }
                    else
                    {
                        resultado = logica.Modificar(diag);
                        Mensaje = "Diagnostico modificado correctamente";

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

        private void FrmDiagnosticos_Load(object sender, EventArgs e)
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
            EntidadDiagnosticos diag;
            int resultado;
            BLdiagnosticos logica = new BLdiagnosticos(Configuracion.getConnectionString);
            try
            {
                if (!string.IsNullOrEmpty(txtDiagnostico.Text))
                {
                    diag = logica.Obtener(int.Parse(txtDiagnostico.Text));
                    if (diag != null)
                    {
                        resultado = logica.Eliminar(diag);
                        MessageBox.Show("Eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        CargarListaDataSet();
                    }
                    else
                    {
                        MessageBox.Show("El diagnostico no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        CargarListaDataSet();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un diagnostico", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cargar(int id)
        {
            EntidadDiagnosticos diag = new EntidadDiagnosticos();
            BLdiagnosticos traer = new BLdiagnosticos(Configuracion.getConnectionString);

            try
            {
                diag = traer.Obtener(id);
                if (diag != null)
                {
                    txtDiagnostico.Text = diag.Id_Diagnostico.ToString();
                    txtIdMedico.Text = diag.Id_Medico.ToString();
                    txtId_Medicamento.Text = diag.Id_Medicamento.ToString();
                    txtCita.Text = diag.Id_Cita.ToString();
                    txtDescripcion.Text = diag.Descripcion;
                }
                else
                {
                    MessageBox.Show("El diagnostico no esta en la base de datos", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            int id = Convert.ToInt32(txtDiagnostico.Text);
            Cargar(id);
        }
    }
}
