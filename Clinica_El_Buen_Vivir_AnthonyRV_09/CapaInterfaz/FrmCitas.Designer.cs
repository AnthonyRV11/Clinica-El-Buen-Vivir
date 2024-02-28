
namespace CapaInterfaz
{
    partial class FrmCitas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCitas));
            this.grdCitas = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnVerAgenda = new System.Windows.Forms.Button();
            this.btnVerPaciente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCita = new System.Windows.Forms.TextBox();
            this.txtPaciente = new System.Windows.Forms.TextBox();
            this.txtAgenda = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdCitas)).BeginInit();
            this.SuspendLayout();
            // 
            // grdCitas
            // 
            this.grdCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCitas.Location = new System.Drawing.Point(13, 226);
            this.grdCitas.Name = "grdCitas";
            this.grdCitas.RowHeadersWidth = 51;
            this.grdCitas.RowTemplate.Height = 29;
            this.grdCitas.Size = new System.Drawing.Size(390, 188);
            this.grdCitas.TabIndex = 0;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(462, 39);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(105, 73);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(462, 341);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(105, 73);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(462, 235);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(105, 73);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(462, 132);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(105, 73);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnVerAgenda
            // 
            this.btnVerAgenda.Location = new System.Drawing.Point(14, 29);
            this.btnVerAgenda.Name = "btnVerAgenda";
            this.btnVerAgenda.Size = new System.Drawing.Size(108, 83);
            this.btnVerAgenda.TabIndex = 5;
            this.btnVerAgenda.Text = "Ver agenda";
            this.btnVerAgenda.UseVisualStyleBackColor = true;
            this.btnVerAgenda.Click += new System.EventHandler(this.btnVerAgenda_Click);
            // 
            // btnVerPaciente
            // 
            this.btnVerPaciente.Location = new System.Drawing.Point(13, 137);
            this.btnVerPaciente.Name = "btnVerPaciente";
            this.btnVerPaciente.Size = new System.Drawing.Size(109, 83);
            this.btnVerPaciente.TabIndex = 6;
            this.btnVerPaciente.Text = "Ver pacientes";
            this.btnVerPaciente.UseVisualStyleBackColor = true;
            this.btnVerPaciente.Click += new System.EventHandler(this.btnVerPaciente_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(338, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Id cita";
            // 
            // txtCita
            // 
            this.txtCita.Location = new System.Drawing.Point(278, 190);
            this.txtCita.Name = "txtCita";
            this.txtCita.Size = new System.Drawing.Size(125, 28);
            this.txtCita.TabIndex = 8;
            // 
            // txtPaciente
            // 
            this.txtPaciente.Location = new System.Drawing.Point(128, 190);
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.Size = new System.Drawing.Size(125, 28);
            this.txtPaciente.TabIndex = 9;
            // 
            // txtAgenda
            // 
            this.txtAgenda.Location = new System.Drawing.Point(129, 77);
            this.txtAgenda.Name = "txtAgenda";
            this.txtAgenda.Size = new System.Drawing.Size(125, 28);
            this.txtAgenda.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Id agenda";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Id paciente";
            // 
            // FrmCitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(598, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAgenda);
            this.Controls.Add(this.txtPaciente);
            this.Controls.Add(this.txtCita);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVerPaciente);
            this.Controls.Add(this.btnVerAgenda);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.grdCitas);
            this.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmCitas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Citas";
            this.Load += new System.EventHandler(this.FrmCitas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCitas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdCitas;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnVerAgenda;
        private System.Windows.Forms.Button btnVerPaciente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCita;
        private System.Windows.Forms.TextBox txtPaciente;
        private System.Windows.Forms.TextBox txtAgenda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}