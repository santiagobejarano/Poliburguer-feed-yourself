using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poliburguer_feed_yourself
{
    public struct Persona
    {
        public string Nombre;
        public string Apellido;
        public string CI;
    }
    public struct Categoria
    {
        public string nombre;
    }
    public struct Producto
    {
        public string nombre;
        public int stock;
        public float precio;
        public Categoria Categoria;
        public int id;
    }
    public struct Fecha
    {
        public string dia;
        public string mes;
        public string anio;
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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria cat1, cat2, cat3;
                cat1.nombre = "Dulces";
                cat2.nombre = "Bebida";
                cat3.nombre = "Comida";

                Producto[] productos = new Producto[8];
                productos[0].nombre = "Hamburguesa";
                productos[0].stock = stockHamburguesa;
                productos[0].precio = 6;
                productos[0].Categoria = cat3;
                productos[0].id = 10001;

                productos[1].nombre = "Salchipapa";
                productos[1].stock = stockPapa;
                productos[1].precio = 3;
                productos[1].Categoria = cat3;
                productos[1].id = 10002;

                productos[2].nombre = "Hotdog";
                productos[2].stock = stockHotDog;
                productos[2].precio = 5;
                productos[2].Categoria = cat3;
                productos[2].id = 10003;

                productos[3].nombre = "Cola";
                productos[3].stock = stockCola;
                productos[3].precio = 2;
                productos[3].Categoria = cat2;
                productos[3].id = 10004;

                productos[4].nombre = "Agua";
                productos[4].stock = stockAgua;
                productos[4].precio = 1;
                productos[4].Categoria = cat2;
                productos[4].id = 10005;

                productos[5].nombre = "Te";
                productos[5].stock = stockTe;
                productos[5].precio = 2;
                productos[5].Categoria = cat2;
                productos[5].id = 10006;

                productos[6].nombre = "Chocolate";
                productos[6].stock = stockChocolate;
                productos[6].precio = 3;
                productos[6].Categoria = cat1;
                productos[6].id = 10007;

                productos[7].nombre = "Helado";
                productos[7].stock = stockHelado;
                productos[7].precio = 4;
                productos[7].Categoria = cat1;
                productos[7].id = 10008;



                if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtCi.Text))
                {
                    MessageBox.Show("Algunos parametros en blanco");
                }
                else
                {
                    Persona persona;
                    persona.Nombre = txtNombre.Text;
                    persona.Apellido = txtApellido.Text;
                    persona.CI = txtCi.Text;
                    subtotal += contadorHamgurguesa * productos[0].precio;
                    stockHamburguesa -= contadorHamgurguesa;
                    subtotal += contadorPapa * productos[1].precio;
                    stockPapa -= contadorPapa;
             

                    total = subtotal + subtotal * 0.12;
                    DateTime now = DateTime.UtcNow.Date;
                    Fecha fechaActual;
                    fechaActual.dia = now.ToString("dd");
                    fechaActual.mes = now.ToString("MM");
                    fechaActual.anio = now.ToString("yyyy");

                    listBox1.Items.Add(factura.nombre);
                    listBox1.Items.Add(factura.CI);
                    listBox1.Items.Add(factura.fecha);


                    

                    listBox1.Items.Add("Subtotal: " + factura.subtotal);
                    listBox1.Items.Add("Total: " + factura.total);

                }
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtCi.Text = "";
                lblContador1.Text = "0";
                lblContador2.Text = "0";
                
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio algun error");
                throw;
            }
        }
    }
}
