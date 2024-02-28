using System;
using System.Windows.Forms;
using CapaLogica;
using CapaEntidades;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaInterfaz
{
    public partial class FrmEspecialidades : Form
    {
        //variable global para un cliente
        EntidadEspecialidades espeRegistrado;
        public FrmEspecialidades()
        {
            InitializeComponent();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private EntidadEspecialidades GenerarEntidad()//Metodo para generar una entidad
        {
            EntidadEspecialidades espe = new EntidadEspecialidades();
            if (!string.IsNullOrEmpty(txtIdEspecialidad.Text))
            {
                espeRegistrado = espe;
            }
            else
            {
                espe = new EntidadEspecialidades();
            }
            espe.setNombre_Especialidad(txtNombre.Text);
            return espe;
        }//Fin del metodo para generar entidad

        private void CargarListaDataSet(string condicion = "", string orden = "")//Metodo para cargar lista
        {
            BLespecialidad logica = new BLespecialidad(Configuracion.getConnectionString);
            DataSet DSespe;
            try
            {
                DSespe = logica.Listar(condicion, orden);
                grdEspecialidad.DataSource = DSespe;
                grdEspecialidad.DataMember = DSespe.Tables["ESPECIALIDADES"].TableName;

            }
            catch (Exception)
            {
                MessageBox.Show("Ocurio un error", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//Fin metodo cargar lista

        private void Limpiar()//Metodo limpiar
        {
            txtIdEspecialidad.Text = string.Empty;
            txtNombre.Text = string.Empty;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            BLespecialidad logica = new BLespecialidad(Configuracion.getConnectionString);
            EntidadEspecialidades espe;
            int resultado;
            string Mensaje = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(txtNombre.Text))
                {
                    espe = GenerarEntidad();
                    if (!espe.Existe)
                    {
                        resultado = logica.Insertar(espe);
                        Mensaje = "Especialidad Insertada correctamente";
                    }
                    else
                    {
                        resultado = logica.Modificar(espe);
                        Mensaje = "Especialidad modificada correctamente";

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

        private void FrmEspecialidades_Load(object sender, EventArgs e)
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
            EntidadEspecialidades espe;
            int resultado;
            BLespecialidad logica = new BLespecialidad(Configuracion.getConnectionString);
            try
            {
                if (!string.IsNullOrEmpty(txtIdEspecialidad.Text))
                {
                    espe = logica.Obtener(int.Parse(txtIdEspecialidad.Text));
                    if (espe != null)
                    {
                        resultado = logica.Eliminar(espe);
                        MessageBox.Show("Eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        CargarListaDataSet();
                    }
                    else
                    {
                        MessageBox.Show("Especialidad no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        CargarListaDataSet();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una especialidad", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIdEspecialidad.Text);
            Cargar(id);
        }

        private void Cargar(int id)
        {
            EntidadEspecialidades espe = new EntidadEspecialidades();
            BLespecialidad traer = new BLespecialidad(Configuracion.getConnectionString);

            try
            {
                espe = traer.Obtener(id);
                if (espe != null)
                {
                    txtIdEspecialidad.Text = espe.getId_Especialidad().ToString();
                    txtNombre.Text = espe.getNombre_Especialidad();
                }
                else
                {
                    MessageBox.Show("La especialidad no esta en la base de datos", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
