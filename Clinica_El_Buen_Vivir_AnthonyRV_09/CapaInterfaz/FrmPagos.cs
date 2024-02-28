using System;
using System.Windows.Forms;
using CapaLogica;
using CapaEntidades;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaInterfaz
{
    public partial class FrmPagos : Form
    {
        EntidadPagos pagoRegistrado;
        public FrmPagos()
        {
            InitializeComponent();
        }

        private void btnVerAdministrador_Click(object sender, EventArgs e)
        {
            FrmAdministradores admin = new FrmAdministradores();
            admin.Show();
        }

        private void btnPaciente_Click(object sender, EventArgs e)
        {
            FrmPacientes paci = new FrmPacientes();
            paci.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private EntidadPagos GenerarEntidad()//Metodo para generar una entidad
        {
            EntidadPagos pago = new EntidadPagos();
            if (!string.IsNullOrEmpty(txtFactura.Text))
            {
                pagoRegistrado = pago;
            }
            else
            {
                pago = new EntidadPagos();
            } 
            pago.setId_Paciente(Convert.ToInt32(txtPaciente.Text));
            pago.setId_Administrador(Convert.ToInt32(txtAdministrador.Text));
            pago.setDescripcion(txtDescripcion.Text);
            pago.setTotal(Convert.ToDecimal(txtTotal.Text));
            return pago;
        }//Fin del metodo para generar entidad

        private void CargarListaDataSet(string condicion = "", string orden = "")//Metodo para cargar lista
        {
            BLpagos logica = new BLpagos(Configuracion.getConnectionString);
            DataSet DS;
            try
            {
                DS = logica.Listar(condicion, orden);
                grdPagos.DataSource = DS;
                grdPagos.DataMember = DS.Tables["Pagos"].TableName;

            }
            catch (Exception)
            {
                MessageBox.Show("Ocurio un error", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//Fin metodo cargar lista

        private void Limpiar()//Metodo limpiar
        {
            txtFactura.Text = string.Empty;
            txtPaciente.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtTotal.Text = string.Empty;
            txtAdministrador.Text = string.Empty;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            BLpagos logica = new BLpagos(Configuracion.getConnectionString);
            EntidadPagos pago;
            int resultado;
            string Mensaje = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(txtPaciente.Text) && !string.IsNullOrEmpty(txtAdministrador.Text) && !string.IsNullOrEmpty(txtTotal.Text) && !string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    pago = GenerarEntidad();
                    if (!pago.Existe)
                    {
                        resultado = logica.Insertar(pago);
                        Mensaje = "Pago Insertado correctamente";
                    }
                    else
                    {
                        resultado = logica.Modificar(pago);
                        Mensaje = "Pago modificado correctamente";

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

        private void FrmPagos_Load(object sender, EventArgs e)
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
            EntidadPagos pago;
            int resultado;
            BLpagos logica = new BLpagos(Configuracion.getConnectionString);
            try
            {
                if (!string.IsNullOrEmpty(txtFactura.Text))
                {
                    pago = logica.Obtener(Convert.ToInt32(txtFactura.Text));
                    if (pago != null)
                    {
                        resultado = logica.Eliminar(pago);
                        MessageBox.Show("Eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        CargarListaDataSet();
                    }
                    else
                    {
                        MessageBox.Show("El pago no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        CargarListaDataSet();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un pago", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cargar(int id)
        {
            EntidadPagos pagos = new EntidadPagos();
            BLpagos traer = new BLpagos(Configuracion.getConnectionString);

            try
            {
                pagos = traer.Obtener(id);
                if (pagos != null)
                {
                    txtFactura.Text = pagos.Num_Factura.ToString();
                    txtPaciente.Text = pagos.Id_Paciente.ToString();
                    txtTotal.Text = pagos.Total_Pagar.ToString();
                    txtAdministrador.Text = pagos.Id_Administrador.ToString();
                    txtDescripcion.Text = pagos.Descripcion;
                }
                else
                {
                    MessageBox.Show("La factura no esta en la base de datos", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            int id = Convert.ToInt32(txtFactura.Text);
            Cargar(id);
        }
    }
}
