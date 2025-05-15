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
    public partial class Cancelaciones: Form
    {
        public Cancelaciones()
        {
            InitializeComponent();
        }

        
        private void button5_Click(object sender, EventArgs e)
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            AbrirformEnPanel(new Eliminar_Reservacion());
        }
    }
}
