using System;
using System.Windows.Forms;
using CapaLogica;
using CapaEntidades;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaInterfaz
{
    public partial class FrmMedicamento : Form
    {
        EntidadMedicamento medicamentoRegistrado;
        public FrmMedicamento()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private EntidadMedicamento GenerarEntidad()//Metodo para generar una entidad
        {
            EntidadMedicamento medicamento = new EntidadMedicamento();
            if (!string.IsNullOrEmpty(txtIdMedicamento.Text))
            {
                medicamentoRegistrado = medicamento;
            }
            else
            {
                medicamento = new EntidadMedicamento();
            }
            medicamento.setNombre(txtNombre.Text);
            medicamento.setCantidad(Convert.ToInt32(txtCantidad.Text));
            medicamento.setDescripcion(txtDescripcion.Text);
            return medicamento;
        }//Fin del metodo para generar entidad

        private void CargarListaDataSet(string condicion = "", string orden = "")//Metodo para cargar lista
        {
            BLmedicamento logica = new BLmedicamento(Configuracion.getConnectionString);
            DataSet DSmedicamento;
            try
            {
                DSmedicamento = logica.Listar(condicion, orden);
                grdMedicamentos.DataSource = DSmedicamento;
                grdMedicamentos.DataMember = DSmedicamento.Tables["Medicamentos"].TableName;

            }
            catch (Exception)
            {
                MessageBox.Show("Ocurio un error", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//Fin metodo cargar lista

        private void Limpiar()//Metodo limpiar
        {
            txtIdMedicamento.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            BLmedicamento logica = new BLmedicamento(Configuracion.getConnectionString);
            EntidadMedicamento medicamento;
            int resultado;
            string Mensaje = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtCantidad.Text) && !string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    medicamento = GenerarEntidad();
                    if (!medicamento.Existe)
                    {
                        resultado = logica.Insertar(medicamento);
                        Mensaje = "Medicamento Insertado correctamente";
                    }
                    else
                    {
                        resultado = logica.Modificar(medicamento);
                        Mensaje = "Medicamento modificado correctamente";

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

        private void FrmMedicamento_Load(object sender, EventArgs e)
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
            EntidadMedicamento medicamento;
            int resultado;
            BLmedicamento logica = new BLmedicamento(Configuracion.getConnectionString);
            try
            {
                if (!string.IsNullOrEmpty(txtIdMedicamento.Text))
                {
                    medicamento = logica.Obtener(int.Parse(txtIdMedicamento.Text));
                    if (medicamento != null)
                    {
                        resultado = logica.Eliminar(medicamento);
                        MessageBox.Show("Eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        CargarListaDataSet();
                    }
                    else
                    {
                        MessageBox.Show("Medicamento no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        CargarListaDataSet();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un medicamento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cargar(int id)
        {
            EntidadMedicamento medicamento = new EntidadMedicamento();
            BLmedicamento traer = new BLmedicamento(Configuracion.getConnectionString);

            try
            {
                medicamento = traer.Obtener(id);
                if (medicamento != null)
                {
                    txtIdMedicamento.Text = medicamento.Id_Medicamento.ToString();
                    txtNombre.Text = medicamento.Nombre;
                    txtCantidad.Text = medicamento.Cantidad.ToString();
                    txtDescripcion.Text = medicamento.Descripcion;
                }
                else
                {
                    MessageBox.Show("El medicamento no esta en la base de datos", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            int id = Convert.ToInt32(txtIdMedicamento.Text);
            Cargar(id);
        }
    }
}
