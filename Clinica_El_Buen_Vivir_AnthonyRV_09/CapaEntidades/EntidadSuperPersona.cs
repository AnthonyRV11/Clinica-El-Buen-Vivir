using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public abstract class EntidadSuperPersona
    {
        //Atributo
        string nombre;
        string apellida1;
        string apellido2;
        string cedula;
        string telefono;
        string correo;

        //Constructor con parametros
        protected EntidadSuperPersona(string nombre, string apellida1, string apellido2, string cedula, string telefono, string correo)
        {
            this.nombre = nombre;
            this.apellida1 = apellida1;
            this.apellido2 = apellido2;
            this.cedula = cedula;
            this.telefono = telefono;
            this.correo = correo;
        }
        //Constructor sin parametros
        protected EntidadSuperPersona()
        {
            this.nombre = string.Empty;
            this.apellida1 = string.Empty;
            this.apellido2 = string.Empty;
            this.cedula = string.Empty;
            this.telefono = string.Empty;
            this.correo = string.Empty;
        }

        //Metodos set y get
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellida1 { get => apellida1; set => apellida1 = value; }
        public string Apellido2 { get => apellido2; set => apellido2 = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }

        //Metodos set y get F2

        public string getNombre() { return nombre; }
        public string getApellido1() { return apellida1; }
        public string getApellido2() { return apellido2; }
        public string getCedula() { return cedula; }
        public string getTelefono() { return telefono; }
        public string getCorreo() { return correo; }

        public void setNombre(string nombre) { this.nombre = nombre; }
        public void setApellido1(string apellido1) { this.apellida1 = apellido1; }
        public void setApellido2(string apellido2) { this.apellido2 = apellido2; }
        public void setCedula(string cedula) { this.cedula = cedula; }
        public void setTelefono(string telefono) { this.telefono = telefono; }
        public void setCorreo(string correo) { this.correo = correo; }


    }
}
