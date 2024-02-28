using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadAgenda
    {
        //Atributos
        int id_Agenda;
        int id_Medico;
        DateTime fechaHora;
        string disponibilidad;
        bool existe;

        //Constructor con parametros
        public EntidadAgenda(int id_Agenda, int id_Medico, DateTime fechaHora, string disponibilidad, bool existe)
        {
            this.id_Agenda = id_Agenda;
            this.id_Medico = id_Medico;
            this.fechaHora = fechaHora;
            this.disponibilidad = disponibilidad;
            this.existe = existe;
        }
        //Constructor con parametros
        public EntidadAgenda()
        {
            this.id_Agenda = 0;
            this.id_Medico = 0;
            this.fechaHora = DateTime.Now; ;
            this.disponibilidad = string.Empty;
            this.existe = true;
        }
        //Metodos set y get
        public int Id_Agenda { get => id_Agenda; set => id_Agenda = value; }
        public int Id_Medico { get => id_Medico; set => id_Medico = value; }
        public DateTime FechaHora { get => fechaHora; set => fechaHora = value; }
        public string Disponibilidad { get => disponibilidad; set => disponibilidad = value; }
        public bool Existe { get => existe; set => existe = value; }
        //Metodos set y get F2

        public int getAgenda() { return id_Agenda; }
        public int getMedico() { return id_Medico; }
        public DateTime getFecha() { return fechaHora; }
        public bool getExiste() { return existe; }

        public void setAgenda(int agenda) { this.Id_Agenda = agenda; }
        public void setMedico(int medico) { this.Id_Medico = medico; }
        public void setFecha(DateTime fecha) { this.fechaHora = fecha; }
        public void setDisponibilidad(string disponibilidad) { this.disponibilidad = disponibilidad; }
        public void setExiste(bool existe) { this.existe = existe; }
    }
}
