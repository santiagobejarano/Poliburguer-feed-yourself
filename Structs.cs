using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace structs
{
    internal class Program
    {
        struct Fecha
        {
            int dia;
            int mes;
            int anio;
        }
        struct Categoria
        {
            string nombre;
        }
        struct Cliente
        {
            string nombres;
            string apellidos;
            int ID;
        }
        struct Producto
        {
            string nombre;
            int stock;
            float precio;
            Categoria categoria;
            int ID;
        }
        public struct Factura
        {
            public string nombre;
            public string CI;
            public string fecha;
            public double subtotal;
            public double total;
            public string pedidos;
        }
    }
    static void Main(string[] args)
    {
    }
}

