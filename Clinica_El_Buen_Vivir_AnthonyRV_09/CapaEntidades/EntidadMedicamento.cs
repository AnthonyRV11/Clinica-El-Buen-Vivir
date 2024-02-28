using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadMedicamento
    {
        //Atributos
        int id_Medicamento;
        string nombre;
        int cantidad;
        string descripcion;
        bool existe;

        //Constructor con parametros
        public EntidadMedicamento(int id_Medicamento, string nombre, int cantidad, string descripcion, bool existe)
        {
            this.id_Medicamento = id_Medicamento;
            this.nombre = nombre;
            this.cantidad = cantidad;
            this.descripcion = descripcion;
            this.existe = existe;
        }
        //Constructor con parametros
        public EntidadMedicamento()
        {
            this.id_Medicamento = 0;
            this.nombre = string.Empty;
            this.cantidad = 0;
            this.descripcion = string.Empty;
            existe = false;
        }
        //Metodos set y get
        public int Id_Medicamento { get => id_Medicamento; set => id_Medicamento = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public bool Existe { get => existe; set => existe = value; }

        //Get
        public int getId_Medicamento() { return id_Medicamento; }
        public string getNombre() { return nombre; }
        public int getCantidad() { return cantidad; }
        public string getDescripcion() { return descripcion; }
        public bool getExiste() { return existe; }
        //Set
        public void setId_Medicamento(int id_medicamento) { this.id_Medicamento = id_medicamento; }
        public void setNombre(string nombre) { this.nombre = nombre; }
        public void setCantidad(int cantidad) { this.cantidad = cantidad; }
        public void setDescripcion(string descripcion) { this.descripcion = descripcion; }
        public void setExiste(bool existe) { this.existe = existe; }
    }
}
