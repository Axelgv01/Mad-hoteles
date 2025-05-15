using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MAD_VENTANAS
{
    public partial class Login : Form
    {
        // Cadena de conexión con SSL desactivado y timeout
        private readonly string connString =
            "server=localhost;user id=root;password=2017042Axel;database=hoteles;SslMode=None;default command timeout=30;";

        public Login()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();
            string contrasena = txtContrasena.Text;

            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show(
                    "Por favor ingresa correo y contraseña.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                using (var con = new MySqlConnection(connString))
                {
                    con.Open();
                    string sql =
                        "SELECT idUsuario, nombre FROM usuarios " +
                        "WHERE correo = @correo AND contrasena = @contrasena";

                    using (var cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@correo", correo);
                        cmd.Parameters.AddWithValue("@contrasena", contrasena);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show(
                                    "Bienvenido " + reader["nombre"].ToString(),
                                    "Éxito",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );

                                // Mostrar formulario principal
                                this.Hide();
                                var mainForm = new Form1();
                                mainForm.Show();
                            }
                            else
                            {
                                MessageBox.Show(
                                    "Usuario o contraseña incorrectos.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    $"MySQL Error {ex.Number}: {ex.Message}",
                    "Error de MySQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
