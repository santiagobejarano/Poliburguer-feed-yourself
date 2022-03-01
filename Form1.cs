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
