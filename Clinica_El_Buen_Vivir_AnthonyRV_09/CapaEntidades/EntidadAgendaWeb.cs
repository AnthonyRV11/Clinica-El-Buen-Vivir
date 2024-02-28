using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadAgendaWeb
    {
        //Atributos
        int id_Agenda;
        int id_Medico;
        DateTime hora_Inicio;
        DateTime hora_Fin;
        int id_Especialidad;

        //Constructor con parametros
        public EntidadAgendaWeb(int id_Agenda, int id_Medico, DateTime hora_Inicio, DateTime hora_Fin, int id_Especialidad)
        {
            this.id_Agenda = id_Agenda;
            this.id_Medico = id_Medico;
            this.hora_Inicio = hora_Inicio;
            this.hora_Fin = hora_Fin;
            this.id_Especialidad = id_Especialidad;
        }

        //Constructor sin parametros
        public EntidadAgendaWeb()
        {
            this.id_Agenda = 0;
            this.id_Medico = 0;
            this.hora_Inicio = DateTime.Now;
            this.hora_Fin = DateTime.Now;
            this.id_Especialidad = 0;
        }

        //Metodos de acceso
        public int Id_Agenda { get => id_Agenda; set => id_Agenda = value; }
        public int Id_Medico { get => id_Medico; set => id_Medico = value; }
        public DateTime Hora_Inicio { get => hora_Inicio; set => hora_Inicio = value; }
        public DateTime Hora_Fin { get => hora_Fin; set => hora_Fin = value; }
        public int Id_Especialidad { get => id_Especialidad; set => id_Especialidad = value; }
    }
}
