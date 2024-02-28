using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadAdministrador
    {
        //Atributos
        int id_Administrador;
        string puesto;
        string nombre;
        string apellido1;
        string apellido2;
        string cedula;
        string telefono;
        string correo;
        bool existe;

        //Constructor con parametros
        public EntidadAdministrador(int id_Administrador, string puesto, string nombre, string apellido1, string apellido2, string cedula, string telefono, string correo, bool existe)
        {
            this.id_Administrador = id_Administrador;
            this.puesto = puesto;
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.cedula = cedula;
            this.telefono = telefono;
            this.correo = correo;
            this.existe = existe;
        }
        //Constructor sin parametros
        public EntidadAdministrador()
        {
            this.id_Administrador = 0;
            this.puesto = string.Empty;
            this.nombre = string.Empty;
            this.apellido1 = string.Empty;
            this.apellido2 = string.Empty;
            this.cedula = string.Empty;
            this.telefono = string.Empty;
            this.correo = string.Empty;
            this.existe = false;
        }

        //Metodos set y get
        public int Id_Administrador { get => id_Administrador; set => id_Administrador = value; }
        public string Puesto { get => puesto; set => puesto = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido1 { get => apellido1; set => apellido1 = value; }
        public string Apellido2 { get => apellido2; set => apellido2 = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }
        public bool Existe { get => existe; set => existe = value; }

        //Metodos set y get F2
        public int getId_Administrador() { return id_Administrador; }
        public string getPuesto() { return puesto; }
        public string getNombre() { return nombre; }
        public string getApellido1() { return apellido1; }
        public string getApellido2() { return apellido2; }
        public string getCedula() { return cedula; }
        public string getTelefono() {return telefono; }
        public string getCorreo() { return correo; }

        public void setId_Administrador(int id_Administrador) { this.id_Administrador = id_Administrador; }
        public void setPuesto(string puesto) { this.puesto = puesto; }
        public void setNombre(string nombre) { this.nombre = nombre; }
        public void setApellido1(string apellido1) { this.apellido1 = apellido1; }
        public void setApellido2(string apellido2) { this.apellido2 = apellido2; }
        public void setCedula(string cedula) { this.cedula = cedula; }
        public void setTelefono(string telefono) { this.telefono = telefono; }
        public void setCorreo(string correo) { this.correo = correo; }
    }
}
