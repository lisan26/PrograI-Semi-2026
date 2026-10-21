using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace miPrimeaAplicacion
{
    public partial class frm_usuario : Form
    {
        private Conexion_base_datos objConexion;
        private DataTable dtUsuarios = new DataTable();
        private int posicion;
        private string accion = "nuevo";

        public frm_usuario()
        {
            InitializeComponent();
        }

        private void frm_usuario_Load(object sender, EventArgs e)
        {
            try
            {
                objConexion = new Conexion_base_datos();
                obtenerDatos();
                activarEdicion(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No fue posible abrir la base de datos: " + ex.Message, "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (objConexion != null) objConexion.objConexion.Dispose();
            base.OnFormClosed(e);
        }

        private void obtenerDatos()
        {
            DataSet ds = objConexion.crearDs();
            dtUsuarios = ds.Tables["usuarios_USSS129326"];
            dtUsuarios.PrimaryKey = new DataColumn[] { dtUsuarios.Columns["idUsuario"] };
            grdUsuarios.DataSource = dtUsuarios.DefaultView;

            if (grdUsuarios.Columns["clave"] != null)
            {
                grdUsuarios.Columns["clave"].Visible = false;
            }
            if (grdUsuarios.Columns["idUsuario"] != null) grdUsuarios.Columns["idUsuario"].HeaderText = "ID";
            if (grdUsuarios.Columns["usuario"] != null) grdUsuarios.Columns["usuario"].HeaderText = "Usuario";
            if (grdUsuarios.Columns["nombre"] != null) grdUsuarios.Columns["nombre"].HeaderText = "Nombre";
            if (grdUsuarios.Columns["direccion"] != null) grdUsuarios.Columns["direccion"].HeaderText = "Dirección";
            if (grdUsuarios.Columns["telefono"] != null) grdUsuarios.Columns["telefono"].HeaderText = "Teléfono";

            if (dtUsuarios.Rows.Count == 0)
            {
                posicion = 0;
                limpiarControles();
                lblRegistros.Text = "0 de 0";
                return;
            }

            if (posicion >= dtUsuarios.Rows.Count)
            {
                posicion = dtUsuarios.Rows.Count - 1;
            }
            mostrarDatos();
        }

        private void mostrarDatos()
        {
            if (dtUsuarios.Rows.Count == 0)
            {
                return;
            }

            DataRow fila = dtUsuarios.Rows[posicion];
            lblIdUsuario.Text = fila["idUsuario"].ToString();
            txtUsuario.Text = fila["usuario"].ToString();
            txtClave.Clear();
            txtConfirmarClave.Clear();
            txtNombre.Text = fila["nombre"].ToString();
            txtDireccion.Text = fila["direccion"].ToString();
            txtTelefono.Text = fila["telefono"].ToString();
            lblRegistros.Text = (posicion + 1) + " de " + dtUsuarios.Rows.Count;
        }

        private void limpiarControles()
        {
            lblIdUsuario.Text = "";
            txtUsuario.Clear();
            txtClave.Clear();
            txtConfirmarClave.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            chkMostrarClave.Checked = false;
        }

        private void activarEdicion(bool estado)
        {
            txtUsuario.Enabled = estado;
            txtClave.Enabled = estado;
            txtConfirmarClave.Enabled = estado;
            txtNombre.Enabled = estado;
            txtDireccion.Enabled = estado;
            txtTelefono.Enabled = estado;
            grbNavegacion.Enabled = !estado;
            grdUsuarios.Enabled = !estado;
            btnAgregar.Enabled = !estado;
            btnModificar.Enabled = !estado && dtUsuarios.Rows.Count > 0;
            btnEliminar.Enabled = !estado && dtUsuarios.Rows.Count > 0;
            btnGuardar.Enabled = estado;
            btnCancelar.Enabled = estado;
            chkMostrarClave.Enabled = estado;
            lblModo.Text = estado ? (accion == "nuevo" ? "NUEVO USUARIO" : "EDITAR USUARIO") : "CONSULTA DE USUARIOS";
            lblAyudaClave.Text = accion == "nuevo"
                ? "Incluye letras y números. Confirma la clave antes de guardar."
                : "Deja ambos campos vacíos si no deseas cambiar la clave.";
        }

        private bool validarDatos()
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text;

            if (usuario.Length < 6 || usuario.Length > 16)
            {
                MessageBox.Show("El usuario debe tener entre 6 y 16 caracteres.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return false;
            }

            if ((accion == "nuevo" || clave.Length > 0 || txtConfirmarClave.Text.Length > 0)
                && clave != txtConfirmarClave.Text)
            {
                MessageBox.Show("La clave y su confirmacion no coinciden.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmarClave.Focus();
                return false;
            }

            if ((accion == "nuevo" || clave.Length > 0 || txtConfirmarClave.Text.Length > 0)
                && (!clave.Any(char.IsLetter) || !clave.Any(char.IsDigit)))
            {
                MessageBox.Show("La clave debe incluir letras y numeros.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Focus();
                return false;
            }

            if (clave.Length > 35 || txtNombre.Text.Trim() == "" || txtDireccion.Text.Trim() == "")
            {
                MessageBox.Show("Complete todos los campos y use una clave de maximo 35 caracteres.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtTelefono.Text.Length == 0 || txtTelefono.Text.Length > 9 || !txtTelefono.Text.All(char.IsDigit))
            {
                MessageBox.Show("El telefono debe contener solo numeros y un maximo de 9 digitos.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }

            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            accion = "nuevo";
            limpiarControles();
            activarEdicion(true);
            txtUsuario.Focus();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            accion = "modificar";
            activarEdicion(true);
            txtUsuario.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!validarDatos())
            {
                return;
            }

            string[] datos =
            {
                lblIdUsuario.Text,
                txtUsuario.Text.Trim(),
                txtClave.Text,
                txtNombre.Text.Trim(),
                txtDireccion.Text.Trim(),
                txtTelefono.Text.Trim()
            };

            string respuesta = objConexion.mantenimiento_usuarios_USSS129326(datos, accion);
            if (respuesta != "1")
            {
                MessageBox.Show(respuesta, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (accion == "nuevo") posicion = dtUsuarios.Rows.Count;
            obtenerDatos();
            activarEdicion(false);
            MessageBox.Show("Los datos del usuario se guardaron correctamente.", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            obtenerDatos();
            activarEdicion(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtUsuarios.Rows.Count == 0)
            {
                return;
            }

            if (MessageBox.Show("¿Desea eliminar al usuario " + txtUsuario.Text + "?", "Eliminar usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            string respuesta = objConexion.mantenimiento_usuarios_USSS129326(
                new string[] { lblIdUsuario.Text, "", "", "", "", "" }, "eliminar");

            if (respuesta != "1")
            {
                MessageBox.Show(respuesta, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            posicion = 0;
            obtenerDatos();
            activarEdicion(false);
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            if (dtUsuarios.Rows.Count == 0) return;
            posicion = 0;
            mostrarDatos();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (posicion > 0)
            {
                posicion--;
                mostrarDatos();
            }
            else
            {
                MessageBox.Show("Esta en el primer registro.");
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (posicion < dtUsuarios.Rows.Count - 1)
            {
                posicion++;
                mostrarDatos();
            }
            else
            {
                MessageBox.Show("Esta en el ultimo registro.");
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            if (dtUsuarios.Rows.Count == 0) return;
            posicion = dtUsuarios.Rows.Count - 1;
            mostrarDatos();
        }

        private void grdUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || grdUsuarios.Rows[e.RowIndex].Cells["idUsuario"].Value == null)
            {
                return;
            }

            int id = Convert.ToInt32(grdUsuarios.Rows[e.RowIndex].Cells["idUsuario"].Value);
            DataRow fila = dtUsuarios.Rows.Find(id);
            posicion = dtUsuarios.Rows.IndexOf(fila);
            mostrarDatos();
        }

        private void chkMostrarClave_CheckedChanged(object sender, EventArgs e)
        {
            txtClave.UseSystemPasswordChar = !chkMostrarClave.Checked;
            txtConfirmarClave.UseSystemPasswordChar = !chkMostrarClave.Checked;
        }
    }
}
