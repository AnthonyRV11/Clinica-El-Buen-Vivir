using System;
using System.Windows.Forms;
using CapaLogica;
using CapaEntidades;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaInterfaz
{
    public partial class FrmMedicos : Form
    {
        //variable global para un medico
        EntidadMedico mediRegistrado;
        public FrmMedicos()
        {
            InitializeComponent();
        }

        private void btnVerEspecialidades_Click(object sender, EventArgs e)
        {
            FrmEspecialidades frmVerEspecialidades = new FrmEspecialidades();
            frmVerEspecialidades.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private EntidadMedico GenerarEntidad()//Metodo para generar una entidad
        {
            EntidadMedico medico = new EntidadMedico();
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                mediRegistrado = medico;
            }
            else
            {
                medico = new EntidadMedico();
            }
            medico.setId_Especialidad(Convert.ToInt32(txtEspecialidad.Text));
            medico.setNombre(txtNombre.Text);
            medico.setApellido1(txtApellido1.Text);
            medico.setApellido2(txtApellido2.Text);
            medico.setCedula(txtCedula.Text);
            medico.setTelefono(txtTelefono.Text);
            medico.setCorreo(txtCorreo.Text);
            medico.setExperiencia(Convert.ToInt32(txtExperiencia.Text));
            return medico;
        }//Fin del metodo para generar entidad

        private void CargarListaDataSet(string condicion = "", string orden = "")//Metodo para cargar lista
        {
            BLmedico logica = new BLmedico(Configuracion.getConnectionString);
            DataSet DSadmin;
            try
            {
                DSadmin = logica.Listar(condicion, orden);
                grdMedicos.DataSource = DSadmin;
                grdMedicos.DataMember = DSadmin.Tables["Medicos_Especialistas"].TableName;

            }
            catch (Exception)
            {
                MessageBox.Show("Ocurio un error", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//Fin metodo cargar lista

        private void Limpiar()//Metodo limpiar
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido1.Text = string.Empty;
            txtApellido2.Text = string.Empty;
            txtCedula.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtEspecialidad.Text = string.Empty;
            txtExperiencia.Text = string.Empty;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            BLmedico logica = new BLmedico(Configuracion.getConnectionString);
            EntidadMedico medi;
            int resultado;
            string Mensaje = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtEspecialidad.Text) && !string.IsNullOrEmpty(txtApellido2.Text) && !string.IsNullOrEmpty(txtApellido1.Text) && !string.IsNullOrEmpty(txtCedula.Text) && !string.IsNullOrEmpty(txtTelefono.Text) && !string.IsNullOrEmpty(txtCorreo.Text))
                {
                    medi = GenerarEntidad();
                    if (!medi.Existe)
                    {
                        resultado = logica.Insertar(medi);
                        Mensaje = "Medico Insertado correctamente";
                    }
                    else
                    {
                        resultado = logica.Modificar(medi);
                        Mensaje = "Medico modificado correctamente";

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

        private void FrmMedicos_Load(object sender, EventArgs e)
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
            EntidadMedico medi;
            int resultado;
            BLmedico logica = new BLmedico(Configuracion.getConnectionString);
            try
            {
                if (!string.IsNullOrEmpty(txtId.Text))
                {
                    medi = logica.Obtener(int.Parse(txtId.Text));
                    if (medi != null)
                    {
                        resultado = logica.Eliminar(medi);
                        MessageBox.Show("Eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        CargarListaDataSet();
                    }
                    else
                    {
                        MessageBox.Show("Medico no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        CargarListaDataSet();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un medico", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            Cargar(id);
        }

        private void Cargar(int id)
        {
            EntidadMedico medi = new EntidadMedico();
            BLmedico traer = new BLmedico(Configuracion.getConnectionString);

            try
            {
                medi = traer.Obtener(id);
                if (medi != null)
                {
                    txtId.Text = medi.Id_Medico.ToString();
                    txtNombre.Text = medi.Nombre;
                    txtApellido1.Text = medi.Apellida1;
                    txtApellido2.Text = medi.Apellido2;
                    txtCedula.Text = medi.Cedula;
                    txtTelefono.Text = medi.Telefono;
                    txtCorreo.Text = medi.Correo;
                    txtExperiencia.Text = medi.Experiencia.ToString();
                }
                else
                {
                    MessageBox.Show("El medico no esta en la base de datos", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarListaDataSet();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
