using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadDiagnosticos
    {
        //Atributos
        int id_Diagnostico;
        int id_Medicamento;
        int id_Cita;
        int id_Medico;
        string descripcion;
        bool existe;

        //Constructor con parametros
        public EntidadDiagnosticos(int id_Diagnostico, int id_Medicamento, int id_Cita, int id_Medico, string descripcion, bool existe)
        {
            this.id_Diagnostico = id_Diagnostico;
            this.id_Medicamento = id_Medicamento;
            this.id_Cita = id_Cita;
            this.id_Medico = id_Medico;
            this.descripcion = descripcion;
            this.existe = existe;
        }
        //Constructor con parametros
        public EntidadDiagnosticos()
        {
            this.id_Diagnostico = 0;
            this.id_Medicamento = 0;
            this.id_Cita = 0;
            this.id_Medico = 0;
            this.descripcion = string.Empty;
            this.existe = true;
        }
        //Metodos set y get
        public int Id_Diagnostico { get => id_Diagnostico; set => id_Diagnostico = value; }
        public int Id_Medicamento { get => id_Medicamento; set => id_Medicamento = value; }
        public int Id_Cita { get => id_Cita; set => id_Cita = value; }
        public int Id_Medico { get => id_Medico; set => id_Medico = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public bool Existe { get => existe; set => existe = value; }

        //Metodos set y get F2
        public int getId_Diagnostico() { return id_Diagnostico; }
        public int getId_Medicamento() { return id_Medicamento; }
        public int getId_Cita() { return id_Cita; }
        public int getId_Medico() { return id_Medico; }
        public string getDescripcion() { return descripcion; }
        public bool getExiste() { return existe; }

        public void setId_Diagnostico(int id_diagnostico) { this.id_Diagnostico = id_diagnostico; }
        public void setId_Medicamento(int id_medicamento) { this.id_Medicamento = id_medicamento; }
        public void setId_Cita(int id_cita) { this.id_Cita = id_cita; }
        public void setId_Medico(int id_medico) { this.id_Medico = id_medico; }
        public void setDescripcion(string descripcion) { this.descripcion = descripcion; }
        public void setExiste(bool Existe) { this.Existe = existe; }
    }
}
