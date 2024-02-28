
namespace CapaInterfaz
{
    partial class FrmAgenda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grdAgenda = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAgenda = new System.Windows.Forms.TextBox();
            this.btnVerMedicos = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMedico = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDisponible = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.Agenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disponibilidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Medico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdAgenda)).BeginInit();
            this.SuspendLayout();
            // 
            // grdAgenda
            // 
            this.grdAgenda.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.grdAgenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAgenda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Agenda,
            this.Fecha,
            this.Disponibilidad,
            this.Medico});
            this.grdAgenda.Location = new System.Drawing.Point(13, 135);
            this.grdAgenda.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grdAgenda.Name = "grdAgenda";
            this.grdAgenda.RowHeadersWidth = 51;
            this.grdAgenda.RowTemplate.Height = 29;
            this.grdAgenda.Size = new System.Drawing.Size(610, 236);
            this.grdAgenda.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Id agenda";
            // 
            // txtAgenda
            // 
            this.txtAgenda.Location = new System.Drawing.Point(16, 32);
            this.txtAgenda.Name = "txtAgenda";
            this.txtAgenda.Size = new System.Drawing.Size(132, 28);
            this.txtAgenda.TabIndex = 2;
            // 
            // btnVerMedicos
            // 
            this.btnVerMedicos.Location = new System.Drawing.Point(498, 2);
            this.btnVerMedicos.Name = "btnVerMedicos";
            this.btnVerMedicos.Size = new System.Drawing.Size(125, 58);
            this.btnVerMedicos.TabIndex = 3;
            this.btnVerMedicos.Text = "Ver medicos";
            this.btnVerMedicos.UseVisualStyleBackColor = true;
            this.btnVerMedicos.Click += new System.EventHandler(this.btnVerMedicos_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(527, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Id medico";
            // 
            // txtMedico
            // 
            this.txtMedico.Location = new System.Drawing.Point(498, 101);
            this.txtMedico.Name = "txtMedico";
            this.txtMedico.Size = new System.Drawing.Size(125, 28);
            this.txtMedico.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fecha ";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(16, 101);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(250, 28);
            this.dtpFecha.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(293, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Disponibilidad";
            // 
            // txtDisponible
            // 
            this.txtDisponible.Location = new System.Drawing.Point(293, 101);
            this.txtDisponible.Name = "txtDisponible";
            this.txtDisponible.Size = new System.Drawing.Size(170, 28);
            this.txtDisponible.TabIndex = 11;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(635, 300);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(118, 71);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(635, 9);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 71);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(635, 199);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(119, 81);
            this.btnEliminar.TabIndex = 14;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(635, 101);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(119, 81);
            this.btnBuscar.TabIndex = 15;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // Agenda
            // 
            this.Agenda.DataPropertyName = "ID_AGENDA";
            this.Agenda.HeaderText = "Agenda";
            this.Agenda.MinimumWidth = 6;
            this.Agenda.Name = "Agenda";
            this.Agenda.Width = 125;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "FECHA_HORA";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.MinimumWidth = 6;
            this.Fecha.Name = "Fecha";
            this.Fecha.Width = 125;
            // 
            // Disponibilidad
            // 
            this.Disponibilidad.DataPropertyName = "DISPONIBILIDAD";
            this.Disponibilidad.HeaderText = "Disponibilidad";
            this.Disponibilidad.MinimumWidth = 6;
            this.Disponibilidad.Name = "Disponibilidad";
            this.Disponibilidad.Width = 160;
            // 
            // Medico
            // 
            this.Medico.DataPropertyName = "ID_MEDICO";
            this.Medico.HeaderText = "Medico";
            this.Medico.MinimumWidth = 6;
            this.Medico.Name = "Medico";
            this.Medico.Width = 200;
            // 
            // FrmAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(765, 386);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.txtDisponible);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMedico);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnVerMedicos);
            this.Controls.Add(this.txtAgenda);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdAgenda);
            this.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmAgenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAgenda";
            this.Load += new System.EventHandler(this.FrmAgenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdAgenda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdAgenda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAgenda;
        private System.Windows.Forms.Button btnVerMedicos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMedico;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDisponible;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Agenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disponibilidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Medico;
    }
}