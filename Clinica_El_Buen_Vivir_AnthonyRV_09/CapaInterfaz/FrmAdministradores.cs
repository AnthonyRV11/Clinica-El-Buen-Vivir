using System;
using System.Windows.Forms;
using CapaLogica;
using CapaEntidades;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaInterfaz
{
    public partial class FrmAdministradores : Form
    {
        //variable global para un cliente
        EntidadAdministrador AdminRegistrado;
        public FrmAdministradores()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }//Metodo para cerrar el formulario

        private EntidadAdministrador GenerarEntidad()//Metodo para generar una entidad
        {
            EntidadAdministrador admin = new EntidadAdministrador();
            if (!string.IsNullOrEmpty(txtIdAdministrador.Text))
            {
                AdminRegistrado = admin; 
            }
            else
            {
                admin = new EntidadAdministrador();
            }
            admin.setNombre(txtNombre.Text);
            admin.setPuesto(txtPuesto.Text);
            admin.setApellido1(txtApellido2.Text);
            admin.setApellido2(txtApellido1.Text);
            admin.setCedula(txtCedula.Text);
            admin.setTelefono(txtTelefono.Text);
            admin.setCorreo(txtCorreo.Text);
            return admin;
        }//Fin del metodo para generar entidad

        private void CargarListaDataSet(string condicion = "", string orden = "")//Metodo para cargar lista
        {
            BLadministrador logica = new BLadministrador(Configuracion.getConnectionString);
            DataSet DSadmin;
            try
            {
                DSadmin = logica.Listar(condicion, orden);
                grdAdmin.DataSource = DSadmin;
                grdAdmin.DataMember = DSadmin.Tables["Administradores"].TableName;

            }
            catch (Exception)
            {
                MessageBox.Show("Ocurio un error", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//Fin metodo cargar lista

        private void Limpiar()//Metodo limpiar
        {
            txtIdAdministrador.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido1.Text = string.Empty;
            txtApellido2.Text = string.Empty;
            txtCedula.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtPuesto.Text = string.Empty;
        }

        private void btnAgregar_Click(object sender, EventArgs e)//Metodo para el boton guardar
        {
            BLadministrador logica = new BLadministrador(Configuracion.getConnectionString);
            EntidadAdministrador admin;
            int resultado;
            string Mensaje = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtPuesto.Text) && !string.IsNullOrEmpty(txtApellido2.Text) && !string.IsNullOrEmpty(txtApellido1.Text) && !string.IsNullOrEmpty(txtCedula.Text) && !string.IsNullOrEmpty(txtTelefono.Text) && !string.IsNullOrEmpty(txtCorreo.Text))
                {
                    admin = GenerarEntidad();
                    if (!admin.Existe)
                    {
                        resultado = logica.Insertar(admin);
                        Mensaje = "Administrador Insertado correctamente";
                    }
                    else
                    {
                        resultado = logica.Modificar(admin);
                        Mensaje = "Administrador modificado correctamente";

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

        private void FrmAdministradores_Load(object sender, EventArgs e)
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
            EntidadAdministrador admin;
            int resultado;
            BLadministrador logica = new BLadministrador(Configuracion.getConnectionString);
            try
            {
                if (!string.IsNullOrEmpty(txtIdAdministrador.Text))
                {
                    admin = logica.Obtener(int.Parse(txtIdAdministrador.Text));
                    if (admin != null)
                    {
                        resultado = logica.Eliminar(admin);
                        MessageBox.Show("Eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        CargarListaDataSet();
                    }
                    else
                    {
                        MessageBox.Show("Administrador no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        CargarListaDataSet();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un administrador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIdAdministrador.Text);
            Cargar(id);
        }

        private void Cargar(int id)
        {
            EntidadAdministrador admin = new EntidadAdministrador();
            BLadministrador traer = new BLadministrador(Configuracion.getConnectionString);

            try
            {
                admin = traer.Obtener(id);
                if (admin != null)
                {
                    txtIdAdministrador.Text = admin.Id_Administrador.ToString();
                    txtNombre.Text = admin.Nombre;
                    txtPuesto.Text = admin.Puesto;
                    txtApellido1.Text = admin.Apellido1;
                    txtApellido2.Text = admin.Apellido2;
                    txtCedula.Text = admin.Cedula;
                    txtTelefono.Text = admin.Telefono;
                    txtCorreo.Text = admin.Correo;
                }
                else
                {
                    MessageBox.Show("El administrador no esta en la base de datos", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
