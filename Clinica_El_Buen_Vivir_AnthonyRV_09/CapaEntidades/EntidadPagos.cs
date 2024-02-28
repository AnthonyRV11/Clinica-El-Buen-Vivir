using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadPagos
    {
        //Atributos
        int num_Factura;
        int id_Paciente;
        int id_Administrador;
        decimal total_Pagar;
        string descripcion;
        bool existe;

        //Constructor con parametros
        public EntidadPagos(int num_Factura, int id_Paciente, int id_Administrador, decimal total_Pagar, string descripcion, bool existe)
        {
            this.num_Factura = num_Factura;
            this.id_Paciente = id_Paciente;
            this.id_Administrador = id_Administrador;
            this.total_Pagar = total_Pagar;
            this.descripcion = descripcion;
            this.existe = existe;
        }
        //Constructor sin parametros
        public EntidadPagos()
        {
            this.num_Factura = 0;
            this.id_Paciente = 0;
            this.id_Administrador = 0;
            this.total_Pagar = 0;
            this.descripcion = string.Empty;
            this.existe = true;
        }
        //Metodos set y get
        public int Num_Factura { get => num_Factura; set => num_Factura = value; }
        public int Id_Paciente { get => id_Paciente; set => id_Paciente = value; }
        public int Id_Administrador { get => id_Administrador; set => id_Administrador = value; }
        public decimal Total_Pagar { get => total_Pagar; set => total_Pagar = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public bool Existe { get => existe; set => existe = value; }
        //Metodos set y get F2
        public int getNum_Factura() { return num_Factura; }
        public int geId_Paciente() { return id_Paciente; }
        public int getId_Administrador() { return id_Administrador; }
        public decimal getTotal() { return total_Pagar; }
        public string getDescripcion() { return descripcion; }
        public bool getExiste() { return existe; }

        public void setNum_Factura(int num_Factura) { this.num_Factura = num_Factura; }
        public void setId_Paciente(int id_Paciente) { this.id_Paciente = id_Paciente; }
        public void setId_Administrador(int id_Administrador) { this.Id_Administrador = id_Administrador; }
        public void setTotal(decimal total) { this.total_Pagar = total; }
        public void setDescripcion(string descripcion) { this.descripcion = descripcion; }
        public void setExiste(bool existe) { this.existe = existe; }
    }
}
