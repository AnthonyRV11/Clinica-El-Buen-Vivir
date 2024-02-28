using System;
using System.Windows.Forms;
using CapaLogica;
using CapaEntidades;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaInterfaz
{
    public partial class FrmBitacora : Form
    {
        public FrmBitacora()
        {
            InitializeComponent();
        }

        private void CargarListaDataSet(string condicion = "", string orden = "")//Metodo para cargar lista
        {
            BLbitacora logica = new BLbitacora(Configuracion.getConnectionString);
            DataSet DSmedicamento;
            try
            {
                DSmedicamento = logica.Listar(condicion, orden);
                grdBitacora.DataSource = DSmedicamento;
                grdBitacora.DataMember = DSmedicamento.Tables["Bitacora"].TableName;

            }
            catch (Exception)
            {
                MessageBox.Show("Ocurio un error", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//Fin metodo cargar lista

        private void FrmBitacora_Load(object sender, EventArgs e)
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
