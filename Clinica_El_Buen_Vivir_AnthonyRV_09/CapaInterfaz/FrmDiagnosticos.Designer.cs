
namespace CapaInterfaz
{
    partial class FrmDiagnosticos
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
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnVerMedicamento = new System.Windows.Forms.Button();
            this.btnMedico = new System.Windows.Forms.Button();
            this.btnVerCita = new System.Windows.Forms.Button();
            this.grdVerDiagnosticos = new System.Windows.Forms.DataGridView();
            this.Id_Diagnostico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_Medicamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_Medico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_Cita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtId_Medicamento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDiagnostico = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCita = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIdMedico = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerDiagnosticos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(767, 155);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(94, 69);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(767, 305);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(94, 69);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(767, 380);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(94, 69);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnVerMedicamento
            // 
            this.btnVerMedicamento.Location = new System.Drawing.Point(12, 12);
            this.btnVerMedicamento.Name = "btnVerMedicamento";
            this.btnVerMedicamento.Size = new System.Drawing.Size(200, 74);
            this.btnVerMedicamento.TabIndex = 3;
            this.btnVerMedicamento.Text = "Ver medicamento";
            this.btnVerMedicamento.UseVisualStyleBackColor = true;
            this.btnVerMedicamento.Click += new System.EventHandler(this.btnVerMedicamento_Click);
            // 
            // btnMedico
            // 
            this.btnMedico.Location = new System.Drawing.Point(334, 12);
            this.btnMedico.Name = "btnMedico";
            this.btnMedico.Size = new System.Drawing.Size(200, 73);
            this.btnMedico.TabIndex = 4;
            this.btnMedico.Text = "Ver medico";
            this.btnMedico.UseVisualStyleBackColor = true;
            this.btnMedico.Click += new System.EventHandler(this.btnMedico_Click);
            // 
            // btnVerCita
            // 
            this.btnVerCita.Location = new System.Drawing.Point(661, 13);
            this.btnVerCita.Name = "btnVerCita";
            this.btnVerCita.Size = new System.Drawing.Size(200, 73);
            this.btnVerCita.TabIndex = 5;
            this.btnVerCita.Text = "Ver citas";
            this.btnVerCita.UseVisualStyleBackColor = true;
            this.btnVerCita.Click += new System.EventHandler(this.btnVerCita_Click);
            // 
            // grdVerDiagnosticos
            // 
            this.grdVerDiagnosticos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVerDiagnosticos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_Diagnostico,
            this.Id_Medicamento,
            this.Id_Medico,
            this.Id_Cita,
            this.Descripcion});
            this.grdVerDiagnosticos.Location = new System.Drawing.Point(12, 230);
            this.grdVerDiagnosticos.Name = "grdVerDiagnosticos";
            this.grdVerDiagnosticos.RowHeadersWidth = 51;
            this.grdVerDiagnosticos.RowTemplate.Height = 29;
            this.grdVerDiagnosticos.Size = new System.Drawing.Size(733, 219);
            this.grdVerDiagnosticos.TabIndex = 6;
            // 
            // Id_Diagnostico
            // 
            this.Id_Diagnostico.DataPropertyName = "ID_DIAGNOSTICO";
            this.Id_Diagnostico.HeaderText = "Id_Diagnostico";
            this.Id_Diagnostico.MinimumWidth = 6;
            this.Id_Diagnostico.Name = "Id_Diagnostico";
            this.Id_Diagnostico.Width = 125;
            // 
            // Id_Medicamento
            // 
            this.Id_Medicamento.DataPropertyName = "ID_MEDICAMENTO";
            this.Id_Medicamento.HeaderText = "Id_Medicamento";
            this.Id_Medicamento.MinimumWidth = 6;
            this.Id_Medicamento.Name = "Id_Medicamento";
            this.Id_Medicamento.Width = 125;
            // 
            // Id_Medico
            // 
            this.Id_Medico.DataPropertyName = "ID_MEDICO";
            this.Id_Medico.HeaderText = "Id_Medico";
            this.Id_Medico.MinimumWidth = 6;
            this.Id_Medico.Name = "Id_Medico";
            this.Id_Medico.Width = 125;
            // 
            // Id_Cita
            // 
            this.Id_Cita.DataPropertyName = "ID_CITA";
            this.Id_Cita.HeaderText = "Id_Cita";
            this.Id_Cita.MinimumWidth = 6;
            this.Id_Cita.Name = "Id_Cita";
            this.Id_Cita.Width = 125;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "DESCRIPCION";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.MinimumWidth = 6;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Width = 250;
            // 
            // txtId_Medicamento
            // 
            this.txtId_Medicamento.Location = new System.Drawing.Point(12, 196);
            this.txtId_Medicamento.Name = "txtId_Medicamento";
            this.txtId_Medicamento.Size = new System.Drawing.Size(87, 28);
            this.txtId_Medicamento.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Id_Medicamento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Id_Diagnostico";
            // 
            // txtDiagnostico
            // 
            this.txtDiagnostico.Location = new System.Drawing.Point(12, 131);
            this.txtDiagnostico.Name = "txtDiagnostico";
            this.txtDiagnostico.Size = new System.Drawing.Size(83, 28);
            this.txtDiagnostico.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(181, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Id_Cita";
            // 
            // txtCita
            // 
            this.txtCita.Location = new System.Drawing.Point(181, 131);
            this.txtCita.Name = "txtCita";
            this.txtCita.Size = new System.Drawing.Size(85, 28);
            this.txtCita.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(181, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Id_Medico";
            // 
            // txtIdMedico
            // 
            this.txtIdMedico.Location = new System.Drawing.Point(181, 196);
            this.txtIdMedico.Name = "txtIdMedico";
            this.txtIdMedico.Size = new System.Drawing.Size(85, 28);
            this.txtIdMedico.TabIndex = 14;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(347, 131);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(398, 93);
            this.txtDescripcion.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(347, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Descripcion";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(767, 230);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(94, 69);
            this.btnBuscar.TabIndex = 17;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // FrmDiagnosticos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 461);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtIdMedico);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCita);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDiagnostico);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtId_Medicamento);
            this.Controls.Add(this.grdVerDiagnosticos);
            this.Controls.Add(this.btnVerCita);
            this.Controls.Add(this.btnMedico);
            this.Controls.Add(this.btnVerMedicamento);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmDiagnosticos";
            this.Text = "FrmDiagnosticos";
            this.Load += new System.EventHandler(this.FrmDiagnosticos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdVerDiagnosticos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnVerMedicamento;
        private System.Windows.Forms.Button btnMedico;
        private System.Windows.Forms.Button btnVerCita;
        private System.Windows.Forms.DataGridView grdVerDiagnosticos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Diagnostico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Medicamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Medico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Cita;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.TextBox txtId_Medicamento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDiagnostico;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCita;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIdMedico;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBuscar;
    }
}