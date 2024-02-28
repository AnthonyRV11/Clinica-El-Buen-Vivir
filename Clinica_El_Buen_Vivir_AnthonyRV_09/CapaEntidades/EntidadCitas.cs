using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadCitas
    {
        //Atributos
        int id_Cita;
        int id_agenda;
        int id_paciente;
        bool existe;

        //Constructor con parametros
        public EntidadCitas(int id_Cita,int id_agenda,int id_paciente, bool existe)
        {
            this.id_Cita = id_Cita;
            this.id_agenda = id_agenda;
            this.id_paciente = id_paciente;
            this.existe = existe;
        }
        //Constructor con parametros
        public EntidadCitas()
        {
            this.id_Cita = 0;
            this.id_agenda = 0;
            this.id_paciente = 0;
            this.existe = true;
        }
        //Metodos set y get
        public int Id_Cita { get => id_Cita; set => id_Cita = value; }
        public int Id_agenda { get => id_agenda; set => id_agenda = value; }
        public int Id_paciente { get => id_paciente; set => id_paciente = value; }
        public bool Existe { get => existe; set => existe = value; }
        //Metodos set y get F2
        public int getId_Cita() { return id_Cita; }
        public int getId_Agenda() { return id_agenda; }
        public int getId_Paciente() { return id_paciente; }
        public bool getExiste() { return existe; }

        public void setId_Cita(int id_cita) { this.id_Cita = id_cita; }
        public void setId_Agenda(int id_Agenda) { this.id_agenda = id_Agenda; }
        public void setId_Paciente(int id_Paciente) { this.id_paciente = id_Paciente; }
        public void setExiste(bool existe) { this.existe = existe; }
    }
}
