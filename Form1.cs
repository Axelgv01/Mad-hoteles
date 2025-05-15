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

namespace MAD_VENTANAS
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 250)
            {
                MenuVertical.Width = 70;
            }
            else
                MenuVertical.Width = 250;
        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconmaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            iconrestaurar.Visible = true;
            iconmaximizar.Visible = false;
        }

        private void iconminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconrestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            iconrestaurar.Visible = false;
            iconmaximizar.Visible = true;
        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle,0x112,0xf012,0);
        }

        private void AbrirformEnPanel(Form Formhijo)
        {
            // Verificar si ya hay un formulario dentro del PanelContenedor
            if (this.PanelContenedor.Controls.Count > 0)
            {
                // Cerrar y eliminar el formulario anterior
                Form formularioActual = this.PanelContenedor.Controls[0] as Form;
                if (formularioActual != null)
                {
                    formularioActual.Close(); // Cierra el formulario correctamente
                    formularioActual.Dispose(); // Libera recursos
                }
                this.PanelContenedor.Controls.Clear(); // Elimina el control del contenedor
            }

            // Configurar el nuevo formulario
            Formhijo.TopLevel = false;
            Formhijo.FormBorderStyle = FormBorderStyle.None; // Elimina los bordes si es necesario
            Formhijo.Dock = DockStyle.Fill;
            this.PanelContenedor.Controls.Add(Formhijo);
            this.PanelContenedor.Tag = Formhijo;
            Formhijo.BringToFront();
            Formhijo.Show();
        }


        private void btmprod_Click_1(object sender, EventArgs e)
        {
            AbrirformEnPanel(new Hoteles());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirformEnPanel(new Usuarios());
        }

        private void PanelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            AbrirformEnPanel(new Administrador());
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AbrirformEnPanel(new Operativo());
        }

        private void PanelContenedor_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirformEnPanel(new Tipos_de_Habitacion());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirformEnPanel(new Reservaciones());
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            AbrirformEnPanel(new Clientescs());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirformEnPanel(new Gestion_de_Clientes());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbrirformEnPanel(new Gestion_de_Reservaciones());
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            AbrirformEnPanel(new Check_In());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AbrirformEnPanel(new Check_Out());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AbrirformEnPanel(new Reporte_de_Ocupacion_por_Hotel ());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            AbrirformEnPanel(new Cancelaciones());
        }

        private void button13_Click(object sender, EventArgs e)
        {
            AbrirformEnPanel(new Reporte_de_Ventas());
        }

        private void button14_Click(object sender, EventArgs e)
        {
            AbrirformEnPanel(new Historial_del_Cliente());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();


        }
    }
}
