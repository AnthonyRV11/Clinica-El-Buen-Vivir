using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadMedico
    {
        //Atributos
        int id_Medico;
        int id_especialidad;
        string nombre;
        string apellida1;
        string apellido2;
        string cedula;
        string telefono;
        string correo;
        int experiencia;
        bool existe;

        //Constructor con parametros
        public EntidadMedico(int id_Medico, int id_especialidad, string nombre, string apellida1, string apellido2, string cedula, string telefono, string correo, int experiencia, bool existe)
        {
            this.id_Medico = id_Medico;
            this.id_especialidad = id_especialidad;
            this.nombre = nombre;
            this.apellida1 = apellida1;
            this.apellido2 = apellido2;
            this.cedula = cedula;
            this.telefono = telefono;
            this.correo = correo;
            this.experiencia = experiencia;
            this.existe = existe;
        }
        //Constructor sin parametros
        public EntidadMedico()
        {
            this.id_Medico = 0;
            this.id_especialidad = 0;
            this.nombre = string.Empty;
            this.apellida1 = string.Empty;
            this.apellido2 = string.Empty;
            this.cedula = string.Empty;
            this.telefono = string.Empty;
            this.correo = string.Empty;
            this.experiencia = 0;
            this.existe = false;
        }
        //Metodos set y get
        public int Id_Medico { get => id_Medico; set => id_Medico = value; }
        public int Id_especialidad { get => id_especialidad; set => id_especialidad = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellida1 { get => apellida1; set => apellida1 = value; }
        public string Apellido2 { get => apellido2; set => apellido2 = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }
        public int Experiencia { get => experiencia; set => experiencia = value; }
        public bool Existe { get => existe; set => existe = value; }
        //Metodos set y get F2
        public int getId_Medico() { return id_Medico; }
        public int getId_Especialidad() { return id_especialidad; }
        public string getNombre() { return nombre; }
        public string getApellido1() { return apellida1; }
        public string getApellido2() { return apellido2; }
        public string getCedula() { return cedula; }
        public string getTelefono() { return telefono; }
        public string getCorreo() { return correo; }
        public int getExperiencia() { return experiencia; }
        public bool getExiste() { return existe; }

        public void setId_Medico(int id_Medico) { this.id_Medico = id_Medico; }
        public void setId_Especialidad(int id_Especialidad) { this.id_especialidad = id_Especialidad; }
        public void setNombre(string nombre) { this.nombre = nombre; }
        public void setApellido1(string apellido1) { this.apellida1 = apellido1; }
        public void setApellido2(string apellido2) { this.apellido2 = apellido2; }
        public void setCedula(string cedula) { this.cedula = cedula; }
        public void setTelefono(string telefono) { this.telefono = telefono; }
        public void setCorreo(string correo) { this.correo = correo; }
        public void setExperiencia(int experiencia) { this.experiencia = experiencia; }
        public void setExiste(bool existe) { this.existe = existe; }
    }


}
