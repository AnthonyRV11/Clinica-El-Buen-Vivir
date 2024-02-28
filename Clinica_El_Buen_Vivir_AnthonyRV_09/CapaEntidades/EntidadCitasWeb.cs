using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadCitasWeb
    {
        //Atributos
        int id_Cita;
        int id_agenda;
        int id_paciente;
        TimeSpan horario;

        //Constructor con parametros
        public EntidadCitasWeb(int id_Cita, int id_agenda, int id_paciente, TimeSpan horario)
        {
            this.id_Cita = id_Cita;
            this.id_agenda = id_agenda;
            this.id_paciente = id_paciente;
            this.horario = horario;
        }
        //Constructor con parametros
        public EntidadCitasWeb()
        {
            this.id_Cita = 0;
            this.id_agenda = 0;
            this.id_paciente = 0;
            this.horario = TimeSpan.Zero;
        }
        //Metodos set y get
        public int Id_Cita { get => id_Cita; set => id_Cita = value; }
        public int Id_agenda { get => id_agenda; set => id_agenda = value; }
        public int Id_paciente { get => id_paciente; set => id_paciente = value; }
        public TimeSpan Horario { get => horario; set => horario = value; }

    }
}
