using System;
using System.Windows.Forms;

namespace miPrimeaAplicacion
{
    public partial class login : Form
    {
        private Conexion_base_datos objConexion;

        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
            try
            {
                objConexion = new Conexion_base_datos();
                btnIngresar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No fue posible abrir la base de datos: " + ex.Message, "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            if (!string.IsNullOrEmpty(objConexion.CredencialesIniciales))
            {
                MessageBox.Show(
                    "Se crearon tres cuentas de prueba. Puedes usar cualquiera para ingresar:\n\n" +
                    objConexion.CredencialesIniciales,
                    "Usuarios iniciales",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (objConexion != null) objConexion.objConexion.Dispose();
            base.OnFormClosed(e);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim() == "" || txtClave.Text == "")
            {
                MessageBox.Show("Escriba el usuario y la clave.", "Inicio de sesion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!objConexion.validarUsuario(txtUsuario.Text.Trim(), txtClave.Text))
            {
                MessageBox.Show("Usuario o clave incorrectos. Acceso denegado.", "Inicio de sesion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClave.Clear();
                txtClave.Focus();
                return;
            }

            Hide();
            using (frmPrincipal principal = new frmPrincipal())
            {
                principal.ShowDialog();
            }
            Close();
        }

        private void chkMostrarClave_CheckedChanged(object sender, EventArgs e)
        {
            txtClave.UseSystemPasswordChar = !chkMostrarClave.Checked;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
