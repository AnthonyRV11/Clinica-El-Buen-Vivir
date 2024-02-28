using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadPaciente
    {
        //Atributo
        int  id_Paciente;
        string nombre;
        string apellida1;
        string apellido2;
        string cedula;
        string telefono;
        string correo;
        bool existe;

        //Constructor con parametros
        public EntidadPaciente(int id_Paciente, string nombre, string apellida1, string apellido2, string cedula, string telefono, string correo, bool existe)
        {
            this.id_Paciente = id_Paciente;
            this.nombre = nombre;
            this.apellida1 = apellida1;
            this.apellido2 = apellido2;
            this.cedula = cedula;
            this.telefono = telefono;
            this.correo = correo;
            this.existe = existe;
        }

        //Constructor sin parametros
        public EntidadPaciente()
        {
            this.id_Paciente = 0;
            this.nombre = string.Empty;
            this.apellida1 = string.Empty;
            this.apellido2 = string.Empty;
            this.cedula = string.Empty;
            this.telefono = string.Empty;
            this.correo = string.Empty;
            this.existe = false;
        }

        //Metodos set y get
        public int Id_Paciente { get => id_Paciente; set => id_Paciente = value; }
        public string Nombre1 { get => nombre; set => nombre = value; }
        public string Apellida11 { get => apellida1; set => apellida1 = value; }
        public string Apellido21 { get => apellido2; set => apellido2 = value; }
        public string Cedula1 { get => cedula; set => cedula = value; }
        public string Telefono1 { get => telefono; set => telefono = value; }
        public string Correo1 { get => correo; set => correo = value; }
        public bool Existe { get => existe; set => existe = value; }
        //Metodos set y get F2
        public int getId_Paciente() { return id_Paciente; }
        public string getNombre() { return nombre; }
        public string getApellido1() { return apellida1; }
        public string getApellido2() { return apellido2; }
        public string getCedula() { return cedula; }
        public string getTelefono() { return telefono; }
        public string getCorreo() { return correo; }
        public bool getExiste() { return existe; }

        public void setId_Paciente(int id_Administrador) { this.id_Paciente = id_Administrador; }
        public void setNombre(string nombre) { this.nombre = nombre; }
        public void setApellido1(string apellido1) { this.apellida1 = apellido1; }
        public void setApellido2(string apellido2) { this.apellido2 = apellido2; }
        public void setCedula(string cedula) { this.cedula = cedula; }
        public void setTelefono(string telefono) { this.telefono = telefono; }
        public void setCorreo(string correo) { this.correo = correo; }
        public void setExiste(bool existe) { this.existe = existe; }
    }
}

