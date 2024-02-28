using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadEspecialidades
    {
        //Atributos
        int id_Especialidad;
        string nombre_especialidad;
        bool existe;

        //Constructor con parametros
        public EntidadEspecialidades(int id_Especialidad, string nombre_especialidad, bool existe)
        {
            this.id_Especialidad = id_Especialidad;
            this.nombre_especialidad = nombre_especialidad;
            this.existe = existe;
        }
        //Constructor con parametros
        public EntidadEspecialidades()
        {
            this.id_Especialidad = 0;
            this.nombre_especialidad = string.Empty;
            this.existe = true;
        }
        //Metodos set y get
        public int Id_Especialidad { get => id_Especialidad; set => id_Especialidad = value; }
        public string Nombre_especialidad { get => nombre_especialidad; set => nombre_especialidad = value; }
        public bool Existe { get => existe; set => existe = value; }
        //Metodos set y get F2
        public int getId_Especialidad() { return id_Especialidad; }
        public string getNombre_Especialidad() { return nombre_especialidad; }
        public bool getExiste() { return existe; }

        public void setId_Especialidad(int id_Especialidad) { this.Id_Especialidad = id_Especialidad; }
        public void setNombre_Especialidad(string Nombre_Especialidad) { this.Nombre_especialidad = Nombre_Especialidad; }
        public void setExiste(bool existe) { this.existe = existe; }
    }

}
