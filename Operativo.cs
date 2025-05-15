using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAD_VENTANAS
{
    public partial class Operativo: Form
    {
        public Operativo()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        
        private void button8_Click(object sender, EventArgs e)
        {
           


        }

        private void label3_Click(object sender, EventArgs e)

        {
            
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

        private void btnckeckin_Click(object sender, EventArgs e)
        {
            AbrirformEnPanel(new Check_In());
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void AbrirformEnPanel(object Formhijo)
        {
            if (this.PanelContenedor.Controls.Count > 0)
                this.PanelContenedor.Controls.RemoveAt(0);
            Form FH = Formhijo as Form;
            FH.TopLevel = false;
            FH.Dock = DockStyle.Fill;
            this.PanelContenedor.Controls.Add(FH);
            this.PanelContenedor.Tag = FH;
            FH.Show();

        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            AbrirformEnPanel(new Check_Out());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AbrirformEnPanel(new Gestion_de_Clientes());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AbrirformEnPanel(new Gestion_de_Reservaciones());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AbrirformEnPanel(new Gestion_de_Clientes());
        }
    }
}
