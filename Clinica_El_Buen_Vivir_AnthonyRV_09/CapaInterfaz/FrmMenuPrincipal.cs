using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaInterfaz
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void administrarInformacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAdministradores frmAdmin = new FrmAdministradores();
            frmAdmin.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void administrarInformacionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmPacientes frmPa = new FrmPacientes();
            frmPa.Show();
        }

        private void administrarInformacionToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            FrmEspecialidades frmEspe = new FrmEspecialidades();
            frmEspe.Show();
        }

        private void administrarInformacionToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmMedicamento frmMedi = new FrmMedicamento();
            frmMedi.Show();
        }

        private void diagnosticosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDiagnosticos frmDiag = new FrmDiagnosticos();
            frmDiag.Show();
        }

        private void administrarInformacionToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmMedicos frmMedico = new FrmMedicos();
            frmMedico.Show();
        }

        private void verBitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBitacora frmBi = new FrmBitacora();
            frmBi.Show();
        }

        private void agendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgenda frA = new FrmAgenda();
            frA.Show();
        }

        private void agendarCitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCitas Agendar = new FrmCitas();
            Agendar.Show();
        }

        private void realizarPagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPagos pagos = new FrmPagos();
            pagos.Show();
        }
    }
}
