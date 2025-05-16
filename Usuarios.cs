using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; 

namespace MAD_VENTANAS
{
    public partial class Usuarios : Form
    {
        // Cadena de conexión (ajusta según tu servidor/usuario/BD)
        private readonly string connString =
            "server=localhost;user id=root;password=3d99025;database=hoteles;SslMode=None;default command timeout=30;";

        public Usuarios()
        {
            InitializeComponent();
            // Asociar eventos a botones
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += BtnCancelar_Click;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Leer valores de los controles
            string correo = txtCorreoElectronico.Text.Trim();
            string contrasena = txtContrasena.Text;
            string nombreComp = txtNombreCompleto.Text.Trim();
            string numeroNomina = txtNumeroNomina.Text.Trim();
            DateTime fnac = dateTimePickerFechaNacimiento.SelectionStart.Date;
            string telCasa = txtTelefonoCasa.Text.Trim();
            string telCel = txtTelefonoCelular.Text.Trim();

            // Validación mínima
            if (string.IsNullOrEmpty(correo) ||
                string.IsNullOrEmpty(contrasena) ||
                string.IsNullOrEmpty(nombreComp) ||
                string.IsNullOrEmpty(numeroNomina))
            {
                MessageBox.Show(
                    "Completa Correo, Contraseña, Nombre y Número de Nómina.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                using (var conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    string sql = @"
                        INSERT INTO Usuarios
                          (correo, contrasena, nombre, apellidos, numeroNomina, fechaNacimiento, telefonoCasa, telefonoCelular)
                        VALUES
                          (@correo, @contrasena, @nombre, @apellidos, @nomina, @fnac, @telCasa, @telCel)";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@correo", correo);
                        cmd.Parameters.AddWithValue("@contrasena", contrasena);

                        // Dividir Nombre Completo en nombre/apellidos
                        var partes = nombreComp.Split(new[] { ' ' }, 2);
                        cmd.Parameters.AddWithValue("@nombre", partes[0]);
                        cmd.Parameters.AddWithValue("@apellidos", partes.Length > 1 ? partes[1] : "");

                        cmd.Parameters.AddWithValue("@nomina", numeroNomina);
                        cmd.Parameters.AddWithValue("@fnac", fnac);
                        cmd.Parameters.AddWithValue("@telCasa", telCasa);
                        cmd.Parameters.AddWithValue("@telCel", telCel);

                        int filas = cmd.ExecuteNonQuery();
                        if (filas > 0)
                        {
                            MessageBox.Show(
                                "Usuario guardado correctamente.",
                                "Éxito",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                            // Limpiar campos tras guardar
                            txtCorreoElectronico.Clear();
                            txtContrasena.Clear();
                            txtNombreCompleto.Clear();
                            txtNumeroNomina.Clear();
                            txtTelefonoCasa.Clear();
                            txtTelefonoCelular.Clear();
                        }
                        else
                        {
                            MessageBox.Show(
                                "No se pudo guardar el usuario.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    $"Error de MySQL {ex.Number}: {ex.Message}",
                    "Error de Base de Datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error inesperado: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            // Cierra la ventana sin guardar
            this.Close();
        }
    }
}
