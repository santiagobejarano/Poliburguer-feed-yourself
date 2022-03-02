using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

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


        int contadorHamgurguesa = 0;
        int contadorPapa = 0;
        int contadorHotDog = 0;
        int contadorCola = 0;
        int contadorAgua = 0;
        int contadorTe = 0;
        int contadorChocolate = 0;
        int contadorHelado = 0;

        double subtotal;
        double total = 0;
        int stockHamburguesa = 70;
        int stockPapa = 40;
        int stockHotDog = 40;
        int stockCola = 100;
        int stockAgua = 80;
        int stockTe = 80;
        int stockChocolate = 50;
        int stockHelado = 50;

        public Form1()
        {
            InitializeComponent();
            listBox1.Text = "";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void header_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void lblFactura_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
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



                if (string.IsNullOrEmpty(txtNombres.Text) || string.IsNullOrEmpty(txtApellidos.Text) || string.IsNullOrEmpty(txtCI.Text))
                {
                    MessageBox.Show("Algunos parametros en blanco");
                }
                else
                {
                    Persona persona;
                    persona.Nombre = txtNombres.Text;
                    persona.Apellido = txtApellidos.Text;
                    persona.CI = txtCI.Text;
                    subtotal += contadorHamgurguesa * productos[0].precio;
                    stockHamburguesa -= contadorHamgurguesa;
                    subtotal += contadorPapa * productos[1].precio;
                    stockPapa -= contadorPapa;
                    subtotal += contadorHotDog * productos[2].precio;
                    stockHotDog -= contadorHotDog;
                    subtotal += contadorCola * productos[3].precio;
                    stockCola -= contadorCola;
                    subtotal += contadorAgua * productos[4].precio;
                    stockAgua -= contadorAgua;
                    subtotal += contadorTe * productos[5].precio;
                    stockTe -= contadorTe;
                    subtotal += contadorChocolate * productos[6].precio;
                    stockChocolate -= contadorChocolate;
                    subtotal += contadorHelado * productos[7].precio;
                    stockHelado -= contadorHelado;


                    total = subtotal + subtotal * 0.12;
                    DateTime now = DateTime.UtcNow.Date;
                    Fecha fechaActual;
                    fechaActual.dia = now.ToString("dd");
                    fechaActual.mes = now.ToString("MM");
                    fechaActual.anio = now.ToString("yyyy");

                    Factura factura;
                    factura.nombre = persona.Nombre + " " + persona.Apellido;
                    factura.CI = persona.CI;
                    factura.fecha = fechaActual.dia + " / " + fechaActual.mes + " / " + fechaActual.anio;
                    factura.subtotal = subtotal;
                    factura.total = total;
                    factura.pedidos = "Productos comprados: \n";

                    listBox1.Items.Add(factura.nombre);
                    listBox1.Items.Add(factura.CI);
                    listBox1.Items.Add("Fecha: ");
                    listBox1.Items.Add(factura.fecha);

                    if (contadorHamgurguesa > 0)
                    {
                        factura.pedidos += "Hamburguesas: " + contadorHamgurguesa.ToString() + "\n";
                    }
                    if (contadorPapa > 0)
                    {
                        factura.pedidos += "Salchipapas: " + contadorPapa.ToString() + "\n";
                    }
                    if (contadorHotDog > 0)
                    {
                        factura.pedidos += "Hot Dogs: " + contadorHotDog.ToString() + "\n";
                    }
                    if (contadorCola > 0)
                    {
                        factura.pedidos += "Colas: " + contadorCola.ToString() + "\n";
                    }
                    if (contadorAgua > 0)
                    {
                        factura.pedidos += "Aguas: " + contadorAgua.ToString() + "\n";
                    }
                    if (contadorTe > 0)
                    {
                        factura.pedidos += "Tés: " + contadorTe.ToString() + "\n";
                    }
                    if (contadorChocolate > 0)
                    {
                        factura.pedidos += "Chocolates: " + contadorChocolate.ToString() + "\n";
                    }
                    if (contadorHelado > 0)
                    {
                        factura.pedidos += "Helados: " + contadorHelado.ToString() + "\n";
                    }

                    string[] values = factura.pedidos.Split('\n');

                    foreach (string value in values)
                    {
                        if (value.Trim() == "")
                            continue;
                        listBox1.Items.Add(value.Trim());
                    }

                    listBox1.Items.Add("Subtotal: " + factura.subtotal);
                    listBox1.Items.Add("Total: " + factura.total);

                }
                txtNombres.Text = "";
                txtApellidos.Text = "";
                txtCI.Text = "";
                txtContadorBurger.Text = "0";
                txtContadorPapa.Text = "0";
                txtContadorHotdog.Text = "0";
                txtContadorCola.Text = "0";
                txtContadorAgua.Text = "0";
                txtContadorTe.Text = "0";
                txtContadorChoco.Text = "0";
                txtContadorHelado.Text = "0";

                contadorHamgurguesa = 0;
                contadorPapa = 0;
                contadorHotDog = 0;
                contadorCola = 0;
                contadorAgua = 0;
                contadorTe = 0;
                contadorChocolate = 0;
                contadorHelado = 0;

                

            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio algun error");
                throw;
            }
        }

        private void btnDismeuirBurger_Click(object sender, EventArgs e)
        {
            if (contadorHamgurguesa > 0)
            {
                contadorHamgurguesa--;
                txtContadorBurger.Text = contadorHamgurguesa.ToString();
            }
        }

        private void btnAumentarBurger_Click(object sender, EventArgs e)
        {
            if (contadorHamgurguesa >= 0 && contadorHamgurguesa < stockHamburguesa)
            {
                contadorHamgurguesa++;
                txtContadorBurger.Text = contadorHamgurguesa.ToString();
            }
        }

        private void btnDismeuirPapa_Click(object sender, EventArgs e)
        {
            if (contadorPapa > 0)
            {
                contadorPapa--;
                txtContadorPapa.Text = contadorPapa.ToString();
            }
        }

        private void btnAumentarPapa_Click(object sender, EventArgs e)
        {
            if (contadorPapa >= 0 && contadorPapa < stockPapa)
            {
                contadorPapa++;
                txtContadorPapa.Text = contadorPapa.ToString();
            }
        }

        private void btnDismeuirHotdog_Click(object sender, EventArgs e)
        {
            if (contadorHotDog > 0)
            {
                contadorHotDog--;
                txtContadorHotdog.Text = contadorHotDog.ToString();
            }
        }

        private void btnAumentarHotdog_Click(object sender, EventArgs e)
        {
            if (contadorHotDog >= 0 && contadorHotDog < stockHotDog)
            {
                contadorHotDog++;
                txtContadorHotdog.Text = contadorHotDog.ToString();
            }
        }

        private void btnDismeuirCola_Click(object sender, EventArgs e)
        {
            if (contadorCola > 0)
            {
                contadorCola--;
                txtContadorCola.Text = contadorCola.ToString();
            }
        }

        private void btnAumentarCola_Click(object sender, EventArgs e)
        {
            if (contadorCola >= 0 && contadorCola < stockCola)
            {
                contadorCola++;
                txtContadorCola.Text = contadorCola.ToString();
            }
        }

        private void btnDismeuirAgua_Click(object sender, EventArgs e)
        {
            if (contadorAgua > 0)
            {
                contadorAgua--;
                txtContadorAgua.Text = contadorAgua.ToString();
            }
        }

        private void btnAumentarAgua_Click(object sender, EventArgs e)
        {
            if (contadorAgua >= 0 && contadorAgua < stockAgua)
            {
                contadorAgua++;
                txtContadorAgua.Text = contadorAgua.ToString();
            }
        }

        private void btnDismeuirTe_Click(object sender, EventArgs e)
        {
            if (contadorTe > 0)
            {
                contadorTe--;
                txtContadorTe.Text = contadorTe.ToString();
            }
        }

        private void btnAumentarTe_Click(object sender, EventArgs e)
        {
            if (contadorTe >= 0 && contadorTe < stockTe)
            {
                contadorTe++;
                txtContadorTe.Text = contadorTe.ToString();
            }
        }

        private void btnDismeuirChoco_Click(object sender, EventArgs e)
        {
            if (contadorChocolate > 0)
            {
                contadorChocolate--;
                txtContadorChoco.Text = contadorChocolate.ToString();
            }
        }

        private void btnAumentarChoco_Click(object sender, EventArgs e)
        {
            if (contadorChocolate >= 0 && contadorChocolate < stockChocolate)
            {
                contadorChocolate++;
                txtContadorChoco.Text = contadorChocolate.ToString();
            }
        }

        private void btnDismeuirHelado_Click(object sender, EventArgs e)
        {
            if (contadorChocolate > 0)
            {
                contadorHelado--;
                txtContadorHelado.Text = contadorChocolate.ToString();
            }
        }

        private void btnAumentarHelado_Click(object sender, EventArgs e)
        {
            if (contadorHelado >= 0 && contadorHelado < stockHelado)
            {
                contadorHelado++;
                txtContadorHelado.Text = contadorHelado.ToString();
            }
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



                if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtCi.Text))
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
                    subtotal += contadorHotDog * productos[2].precio;
                    stockHotDog -= contadorHotDog;
                    subtotal += contadorCola * productos[3].precio;
                    stockCola -= contadorCola;
                    subtotal += contadorAgua * productos[4].precio;
                    stockAgua -= contadorAgua;
                    subtotal += contadorTe * productos[5].precio;
                    stockTe -= contadorTe;
                    subtotal += contadorChocolate * productos[6].precio;
                    stockChocolate -= contadorChocolate;
                    subtotal += contadorHelado * productos[7].precio;
                    stockHelado -= contadorHelado;


                    total = subtotal + subtotal * 0.12;
                    DateTime now = DateTime.UtcNow.Date;
                    Fecha fechaActual;
                    fechaActual.dia = now.ToString("dd");
                    fechaActual.mes = now.ToString("MM");
                    fechaActual.anio = now.ToString("yyyy");

                    Factura factura;
                    factura.nombre = persona.Nombre + " " + persona.Apellido;
                    factura.CI = persona.CI;
                    factura.fecha = fechaActual.dia + " / " + fechaActual.mes + " / " + fechaActual.anio;
                    factura.subtotal = subtotal;
                    factura.total = total;
                    factura.pedidos = "Productos comprados: \n";

                    listBox1.Items.Add(factura.nombre);
                    listBox1.Items.Add(factura.CI);
                    listBox1.Items.Add("Fecha: ");
                    listBox1.Items.Add(factura.fecha);

                    if (contadorHamgurguesa > 0)
                    {
                        factura.pedidos += "Hamburguesas: " + contadorHamgurguesa.ToString() + "\n";
                    }
                    if (contadorPapa > 0)
                    {
                        factura.pedidos += "Salchipapas: " + contadorPapa.ToString() + "\n";
                    }
                    if (contadorHotDog > 0)
                    {
                        factura.pedidos += "Hot Dogs: " + contadorHotDog.ToString() + "\n";
                    }
                    if (contadorCola > 0)
                    {
                        factura.pedidos += "Colas: " + contadorCola.ToString() + "\n";
                    }
                    if (contadorAgua > 0)
                    {
                        factura.pedidos += "Aguas: " + contadorAgua.ToString() + "\n";
                    }
                    if (contadorTe > 0)
                    {
                        factura.pedidos += "Tés: " + contadorTe.ToString() + "\n";
                    }
                    if (contadorChocolate > 0)
                    {
                        factura.pedidos += "Chocolates: " + contadorChocolate.ToString() + "\n";
                    }
                    if (contadorHelado > 0)
                    {
                        factura.pedidos += "Helados: " + contadorHelado.ToString() + "\n";
                    }

                    string[] values = factura.pedidos.Split('\n');

                    foreach (string value in values)
                    {
                        if (value.Trim() == "")
                            continue;
                        listBox1.Items.Add(value.Trim());
                    }

                    listBox1.Items.Add("Subtotal: " + factura.subtotal);
                    listBox1.Items.Add("Total: " + factura.total);

                }
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtCi.Text = "";
                lblContador1.Text = "0";
                lblContador2.Text = "0";
                lblContador3.Text = "0";
                lblContador4.Text = "0";
                lblContador5.Text = "0";
                lblContador6.Text = "0";
                lblContador7.Text = "0";
                lblContador8.Text = "0";

            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio algun error");
                throw;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (contadorHamgurguesa>=0 && contadorHamgurguesa<stockHamburguesa)
            {
                contadorHamgurguesa++;
                lblContador1.Text=contadorHamgurguesa.ToString();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (contadorHamgurguesa > 0)
            {
                contadorHamgurguesa--;
                lblContador1.Text = contadorHamgurguesa.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (contadorPapa >= 0 && contadorPapa<stockPapa)
            {
                contadorPapa++;
                lblContador2.Text = contadorPapa.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (contadorPapa > 0)
            {
                contadorPapa--;
                lblContador2.Text = contadorPapa.ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (contadorHotDog >= 0 && contadorHotDog<stockHotDog)
            {
                contadorHotDog++;
                lblContador3.Text = contadorHotDog.ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (contadorHotDog > 0)
            {
                contadorHotDog--;
                lblContador3.Text = contadorHotDog.ToString();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (contadorCola >= 0 && contadorCola<stockCola)
            {
                contadorCola++;
                lblContador4.Text = contadorCola.ToString();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (contadorCola > 0)
            {
                contadorCola--;
                lblContador4.Text = contadorCola.ToString();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (contadorAgua >= 0 && contadorAgua<stockAgua)
            {
                contadorAgua++;
                lblContador5.Text = contadorAgua.ToString();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (contadorAgua > 0)
            {
                contadorAgua--;
                lblContador5.Text = contadorAgua.ToString();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (contadorTe >= 0 && contadorTe<stockTe)
            {
                contadorTe++;
                lblContador6.Text = contadorTe.ToString();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (contadorTe > 0)
            {
                contadorTe--;
                lblContador6.Text = contadorTe.ToString();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (contadorChocolate >= 0 && contadorChocolate<stockChocolate)
            {
                contadorChocolate++;
                lblContador7.Text = contadorChocolate.ToString();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (contadorChocolate > 0)
            {
                contadorChocolate--;
                lblContador7.Text = contadorChocolate.ToString();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (contadorHelado >= 0 && contadorHelado<stockHelado)
            {
                contadorHelado++;
                lblContador8.Text = contadorHelado.ToString();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (contadorHelado > 0)
            {
                contadorHelado--;
                lblContador8.Text = contadorHelado.ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("h:mm:ss");
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyy");
        }
    }
}
