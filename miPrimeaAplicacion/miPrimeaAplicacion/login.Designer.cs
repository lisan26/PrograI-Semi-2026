using System.Drawing;
using System.Windows.Forms;

namespace miPrimeaAplicacion
{
    partial class login
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlMarca;
        private Panel pnlAcento;
        private Panel pnlAcceso;
        private Label lblInsignia;
        private Label lblMarca;
        private Label lblDescripcion;
        private Label lblFrase;
        private Label lblBienvenida;
        private Label lblInstruccion;
        private Label lblUsuario;
        private Label lblClave;
        private Label lblPie;
        private TextBox txtUsuario;
        private TextBox txtClave;
        private CheckBox chkMostrarClave;
        private Button btnIngresar;
        private Button btnSalir;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlMarca = new System.Windows.Forms.Panel();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblFrase = new System.Windows.Forms.Label();
            this.pnlAcento = new System.Windows.Forms.Panel();
            this.pnlAcceso = new System.Windows.Forms.Panel();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.lblInstruccion = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.chkMostrarClave = new System.Windows.Forms.CheckBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblPie = new System.Windows.Forms.Label();
            this.lblInsignia = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlMarca.SuspendLayout();
            this.pnlAcceso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMarca
            // 
            this.pnlMarca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(49)))), ((int)(((byte)(91)))));
            this.pnlMarca.Controls.Add(this.pictureBox1);
            this.pnlMarca.Controls.Add(this.lblInsignia);
            this.pnlMarca.Controls.Add(this.lblMarca);
            this.pnlMarca.Controls.Add(this.lblDescripcion);
            this.pnlMarca.Controls.Add(this.lblFrase);
            this.pnlMarca.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMarca.Location = new System.Drawing.Point(0, 0);
            this.pnlMarca.Name = "pnlMarca";
            this.pnlMarca.Size = new System.Drawing.Size(295, 458);
            this.pnlMarca.TabIndex = 2;
            // 
            // lblMarca
            // 
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Bold);
            this.lblMarca.ForeColor = System.Drawing.Color.White;
            this.lblMarca.Location = new System.Drawing.Point(27, 143);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(248, 42);
            this.lblMarca.TabIndex = 1;
            this.lblMarca.Text = "Académica";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.lblDescripcion.Location = new System.Drawing.Point(30, 194);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(237, 70);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "Gestión de alumnos, materias, períodos y usuarios.";
            // 
            // lblFrase
            // 
            this.lblFrase.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFrase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(195)))), ((int)(((byte)(233)))));
            this.lblFrase.Location = new System.Drawing.Point(30, 412);
            this.lblFrase.Name = "lblFrase";
            this.lblFrase.Size = new System.Drawing.Size(235, 22);
            this.lblFrase.TabIndex = 3;
            this.lblFrase.Text = "Gestión académica";
            // 
            // pnlAcento
            // 
            this.pnlAcento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.pnlAcento.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAcento.Location = new System.Drawing.Point(295, 0);
            this.pnlAcento.Name = "pnlAcento";
            this.pnlAcento.Size = new System.Drawing.Size(485, 7);
            this.pnlAcento.TabIndex = 1;
            // 
            // pnlAcceso
            // 
            this.pnlAcceso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.pnlAcceso.Controls.Add(this.lblBienvenida);
            this.pnlAcceso.Controls.Add(this.lblInstruccion);
            this.pnlAcceso.Controls.Add(this.lblUsuario);
            this.pnlAcceso.Controls.Add(this.txtUsuario);
            this.pnlAcceso.Controls.Add(this.lblClave);
            this.pnlAcceso.Controls.Add(this.txtClave);
            this.pnlAcceso.Controls.Add(this.chkMostrarClave);
            this.pnlAcceso.Controls.Add(this.btnIngresar);
            this.pnlAcceso.Controls.Add(this.btnSalir);
            this.pnlAcceso.Controls.Add(this.lblPie);
            this.pnlAcceso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAcceso.Location = new System.Drawing.Point(295, 7);
            this.pnlAcceso.Name = "pnlAcceso";
            this.pnlAcceso.Size = new System.Drawing.Size(485, 451);
            this.pnlAcceso.TabIndex = 0;
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblBienvenida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(49)))), ((int)(((byte)(91)))));
            this.lblBienvenida.Location = new System.Drawing.Point(46, 55);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(390, 46);
            this.lblBienvenida.TabIndex = 0;
            this.lblBienvenida.Text = "Iniciar sesión";
            // 
            // lblInstruccion
            // 
            this.lblInstruccion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInstruccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(110)))), ((int)(((byte)(138)))));
            this.lblInstruccion.Location = new System.Drawing.Point(49, 104);
            this.lblInstruccion.Name = "lblInstruccion";
            this.lblInstruccion.Size = new System.Drawing.Size(382, 28);
            this.lblInstruccion.TabIndex = 1;
            this.lblInstruccion.Text = "Ingresa con tu usuario y clave.";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(100)))));
            this.lblUsuario.Location = new System.Drawing.Point(49, 159);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(49, 15);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.White;
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtUsuario.Location = new System.Drawing.Point(52, 184);
            this.txtUsuario.MaxLength = 16;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(380, 29);
            this.txtUsuario.TabIndex = 0;
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblClave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(100)))));
            this.lblClave.Location = new System.Drawing.Point(49, 234);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(37, 15);
            this.lblClave.TabIndex = 3;
            this.lblClave.Text = "Clave";
            // 
            // txtClave
            // 
            this.txtClave.BackColor = System.Drawing.Color.White;
            this.txtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClave.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtClave.Location = new System.Drawing.Point(52, 259);
            this.txtClave.MaxLength = 35;
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(380, 29);
            this.txtClave.TabIndex = 1;
            this.txtClave.UseSystemPasswordChar = true;
            // 
            // chkMostrarClave
            // 
            this.chkMostrarClave.AutoSize = true;
            this.chkMostrarClave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(110)))), ((int)(((byte)(138)))));
            this.chkMostrarClave.Location = new System.Drawing.Point(52, 299);
            this.chkMostrarClave.Name = "chkMostrarClave";
            this.chkMostrarClave.Size = new System.Drawing.Size(97, 19);
            this.chkMostrarClave.TabIndex = 2;
            this.chkMostrarClave.Text = "Mostrar clave";
            this.chkMostrarClave.CheckedChanged += new System.EventHandler(this.chkMostrarClave_CheckedChanged);
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(100)))), ((int)(((byte)(183)))));
            this.btnIngresar.Enabled = false;
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.Location = new System.Drawing.Point(52, 344);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(242, 42);
            this.btnIngresar.TabIndex = 3;
            this.btnIngresar.Text = "Entrar";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(238)))), ((int)(((byte)(251)))));
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(100)))));
            this.btnSalir.Location = new System.Drawing.Point(305, 344);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(127, 42);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblPie
            // 
            this.lblPie.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(133)))), ((int)(((byte)(157)))));
            this.lblPie.Location = new System.Drawing.Point(52, 412);
            this.lblPie.Name = "lblPie";
            this.lblPie.Size = new System.Drawing.Size(380, 20);
            this.lblPie.TabIndex = 5;
            this.lblPie.Text = "Solo los usuarios registrados pueden acceder.";
            // 
            // lblInsignia
            // 
            this.lblInsignia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.lblInsignia.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblInsignia.ForeColor = System.Drawing.Color.White;
            this.lblInsignia.Location = new System.Drawing.Point(29, 53);
            this.lblInsignia.Name = "lblInsignia";
            this.lblInsignia.Size = new System.Drawing.Size(58, 58);
            this.lblInsignia.TabIndex = 0;
            this.lblInsignia.Text = "A";
            this.lblInsignia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.pictureBox1.Image = global::miPrimeaAplicacion.Properties.Resources._2599288;
            this.pictureBox1.Location = new System.Drawing.Point(26, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // login
            // 
            this.AcceptButton = this.btnIngresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(780, 458);
            this.Controls.Add(this.pnlAcceso);
            this.Controls.Add(this.pnlAcento);
            this.Controls.Add(this.pnlMarca);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar sesión";
            this.Load += new System.EventHandler(this.login_Load);
            this.pnlMarca.ResumeLayout(false);
            this.pnlAcceso.ResumeLayout(false);
            this.pnlAcceso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private PictureBox pictureBox1;
    }
}
