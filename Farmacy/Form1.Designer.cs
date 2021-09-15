
namespace Farmacy
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.lblAppName = new System.Windows.Forms.Label();
            this.panelMenuOptions = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.panelSubmenu4 = new System.Windows.Forms.Panel();
            this.btnOpUsuarios = new System.Windows.Forms.Button();
            this.panelSubmenu3 = new System.Windows.Forms.Panel();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnOpVentas = new System.Windows.Forms.Button();
            this.panelSubmenu1 = new System.Windows.Forms.Panel();
            this.btnProdVendidos = new System.Windows.Forms.Button();
            this.btnCategorias = new System.Windows.Forms.Button();
            this.btnInventario = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnOpProductos = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelUser = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblReloj = new System.Windows.Forms.Label();
            this.buttonHideMenu = new System.Windows.Forms.Button();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnReporteVentas = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            this.panelMenuOptions.SuspendLayout();
            this.panelSubmenu3.SuspendLayout();
            this.panelSubmenu1.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.AutoScroll = true;
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(175)))), ((int)(((byte)(191)))));
            this.panelMenu.Controls.Add(this.lblAppName);
            this.panelMenu.Controls.Add(this.panelMenuOptions);
            this.panelMenu.Controls.Add(this.buttonHideMenu);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 605);
            this.panelMenu.TabIndex = 0;
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppName.Location = new System.Drawing.Point(3, 9);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(111, 27);
            this.lblAppName.TabIndex = 1;
            this.lblAppName.Text = "Farmacia";
            // 
            // panelMenuOptions
            // 
            this.panelMenuOptions.BackColor = System.Drawing.Color.Transparent;
            this.panelMenuOptions.Controls.Add(this.btnLogin);
            this.panelMenuOptions.Controls.Add(this.panelSubmenu4);
            this.panelMenuOptions.Controls.Add(this.btnOpUsuarios);
            this.panelMenuOptions.Controls.Add(this.panelSubmenu3);
            this.panelMenuOptions.Controls.Add(this.btnOpVentas);
            this.panelMenuOptions.Controls.Add(this.panelSubmenu1);
            this.panelMenuOptions.Controls.Add(this.btnOpProductos);
            this.panelMenuOptions.Controls.Add(this.panelLogo);
            this.panelMenuOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMenuOptions.Location = new System.Drawing.Point(0, 64);
            this.panelMenuOptions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelMenuOptions.Name = "panelMenuOptions";
            this.panelMenuOptions.Size = new System.Drawing.Size(200, 541);
            this.panelMenuOptions.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.AutoSize = true;
            this.btnLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(131)))), ((int)(((byte)(166)))));
            this.btnLogin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnLogin.Location = new System.Drawing.Point(0, 506);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(200, 35);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // panelSubmenu4
            // 
            this.panelSubmenu4.AutoSize = true;
            this.panelSubmenu4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelSubmenu4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelSubmenu4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubmenu4.Location = new System.Drawing.Point(0, 395);
            this.panelSubmenu4.Name = "panelSubmenu4";
            this.panelSubmenu4.Size = new System.Drawing.Size(200, 0);
            this.panelSubmenu4.TabIndex = 7;
            // 
            // btnOpUsuarios
            // 
            this.btnOpUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(131)))), ((int)(((byte)(166)))));
            this.btnOpUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOpUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpUsuarios.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpUsuarios.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnOpUsuarios.Location = new System.Drawing.Point(0, 349);
            this.btnOpUsuarios.Name = "btnOpUsuarios";
            this.btnOpUsuarios.Size = new System.Drawing.Size(200, 46);
            this.btnOpUsuarios.TabIndex = 6;
            this.btnOpUsuarios.Text = "Usuarios";
            this.btnOpUsuarios.UseVisualStyleBackColor = false;
            this.btnOpUsuarios.Click += new System.EventHandler(this.btnOpUsuarios_Click);
            // 
            // panelSubmenu3
            // 
            this.panelSubmenu3.AutoSize = true;
            this.panelSubmenu3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelSubmenu3.BackColor = System.Drawing.Color.Transparent;
            this.panelSubmenu3.Controls.Add(this.btnReporteVentas);
            this.panelSubmenu3.Controls.Add(this.btnVentas);
            this.panelSubmenu3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubmenu3.Location = new System.Drawing.Point(0, 293);
            this.panelSubmenu3.Name = "panelSubmenu3";
            this.panelSubmenu3.Size = new System.Drawing.Size(200, 56);
            this.panelSubmenu3.TabIndex = 5;
            // 
            // btnVentas
            // 
            this.btnVentas.AutoSize = true;
            this.btnVentas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.btnVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVentas.FlatAppearance.BorderSize = 0;
            this.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVentas.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentas.Location = new System.Drawing.Point(0, 0);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(200, 28);
            this.btnVentas.TabIndex = 2;
            this.btnVentas.Text = "Sistema de Ventas";
            this.btnVentas.UseVisualStyleBackColor = false;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnOpVentas
            // 
            this.btnOpVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(131)))), ((int)(((byte)(166)))));
            this.btnOpVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOpVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpVentas.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpVentas.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnOpVentas.Location = new System.Drawing.Point(0, 247);
            this.btnOpVentas.Name = "btnOpVentas";
            this.btnOpVentas.Size = new System.Drawing.Size(200, 46);
            this.btnOpVentas.TabIndex = 4;
            this.btnOpVentas.Text = "Ventas";
            this.btnOpVentas.UseVisualStyleBackColor = false;
            this.btnOpVentas.Click += new System.EventHandler(this.btnOpVentas_Click);
            // 
            // panelSubmenu1
            // 
            this.panelSubmenu1.AutoSize = true;
            this.panelSubmenu1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelSubmenu1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelSubmenu1.Controls.Add(this.btnProdVendidos);
            this.panelSubmenu1.Controls.Add(this.btnCategorias);
            this.panelSubmenu1.Controls.Add(this.btnInventario);
            this.panelSubmenu1.Controls.Add(this.btnProductos);
            this.panelSubmenu1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubmenu1.Location = new System.Drawing.Point(0, 135);
            this.panelSubmenu1.Name = "panelSubmenu1";
            this.panelSubmenu1.Size = new System.Drawing.Size(200, 112);
            this.panelSubmenu1.TabIndex = 2;
            // 
            // btnProdVendidos
            // 
            this.btnProdVendidos.AutoSize = true;
            this.btnProdVendidos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnProdVendidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.btnProdVendidos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProdVendidos.FlatAppearance.BorderSize = 0;
            this.btnProdVendidos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProdVendidos.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProdVendidos.Location = new System.Drawing.Point(0, 84);
            this.btnProdVendidos.Name = "btnProdVendidos";
            this.btnProdVendidos.Size = new System.Drawing.Size(200, 28);
            this.btnProdVendidos.TabIndex = 3;
            this.btnProdVendidos.Text = "Productos Vendidos";
            this.btnProdVendidos.UseVisualStyleBackColor = false;
            this.btnProdVendidos.Click += new System.EventHandler(this.btnProdVendidos_Click);
            // 
            // btnCategorias
            // 
            this.btnCategorias.AutoSize = true;
            this.btnCategorias.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCategorias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.btnCategorias.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCategorias.FlatAppearance.BorderSize = 0;
            this.btnCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCategorias.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategorias.Location = new System.Drawing.Point(0, 56);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Size = new System.Drawing.Size(200, 28);
            this.btnCategorias.TabIndex = 3;
            this.btnCategorias.Text = "Ver Categorías";
            this.btnCategorias.UseVisualStyleBackColor = false;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
            // 
            // btnInventario
            // 
            this.btnInventario.AutoSize = true;
            this.btnInventario.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnInventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.btnInventario.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInventario.FlatAppearance.BorderSize = 0;
            this.btnInventario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInventario.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventario.Location = new System.Drawing.Point(0, 28);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(200, 28);
            this.btnInventario.TabIndex = 2;
            this.btnInventario.Text = "Ver Inventario";
            this.btnInventario.UseVisualStyleBackColor = false;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.AutoSize = true;
            this.btnProductos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.btnProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProductos.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.Location = new System.Drawing.Point(0, 0);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(200, 28);
            this.btnProductos.TabIndex = 2;
            this.btnProductos.Text = "Ver Productos";
            this.btnProductos.UseVisualStyleBackColor = false;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnOpProductos
            // 
            this.btnOpProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(131)))), ((int)(((byte)(166)))));
            this.btnOpProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOpProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpProductos.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpProductos.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnOpProductos.Location = new System.Drawing.Point(0, 89);
            this.btnOpProductos.Name = "btnOpProductos";
            this.btnOpProductos.Size = new System.Drawing.Size(200, 46);
            this.btnOpProductos.TabIndex = 1;
            this.btnOpProductos.Text = "Productos";
            this.btnOpProductos.UseVisualStyleBackColor = false;
            this.btnOpProductos.Click += new System.EventHandler(this.buttonOpcion1_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.Transparent;
            this.panelLogo.Controls.Add(this.panelUser);
            this.panelLogo.Controls.Add(this.lblReloj);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(200, 89);
            this.panelLogo.TabIndex = 1;
            // 
            // panelUser
            // 
            this.panelUser.AutoSize = true;
            this.panelUser.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelUser.Controls.Add(this.label1);
            this.panelUser.Controls.Add(this.lblUser);
            this.panelUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUser.Location = new System.Drawing.Point(0, 42);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(200, 34);
            this.panelUser.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(2, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome ";
            // 
            // lblUser
            // 
            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUser.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.Black;
            this.lblUser.Location = new System.Drawing.Point(76, 10);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(118, 24);
            this.lblUser.TabIndex = 0;
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReloj
            // 
            this.lblReloj.BackColor = System.Drawing.Color.Transparent;
            this.lblReloj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblReloj.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblReloj.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblReloj.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReloj.ForeColor = System.Drawing.Color.Black;
            this.lblReloj.Location = new System.Drawing.Point(0, 0);
            this.lblReloj.Name = "lblReloj";
            this.lblReloj.Size = new System.Drawing.Size(200, 42);
            this.lblReloj.TabIndex = 0;
            this.lblReloj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonHideMenu
            // 
            this.buttonHideMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(175)))), ((int)(((byte)(191)))));
            this.buttonHideMenu.FlatAppearance.BorderSize = 0;
            this.buttonHideMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHideMenu.Image = ((System.Drawing.Image)(resources.GetObject("buttonHideMenu.Image")));
            this.buttonHideMenu.Location = new System.Drawing.Point(145, 0);
            this.buttonHideMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonHideMenu.Name = "buttonHideMenu";
            this.buttonHideMenu.Size = new System.Drawing.Size(55, 49);
            this.buttonHideMenu.TabIndex = 2;
            this.buttonHideMenu.UseVisualStyleBackColor = false;
            this.buttonHideMenu.Click += new System.EventHandler(this.buttonHideMenu_Click);
            // 
            // panelChildForm
            // 
            this.panelChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(242)))));
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelChildForm.Location = new System.Drawing.Point(200, 0);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(855, 605);
            this.panelChildForm.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnReporteVentas
            // 
            this.btnReporteVentas.AutoSize = true;
            this.btnReporteVentas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReporteVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.btnReporteVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReporteVentas.FlatAppearance.BorderSize = 0;
            this.btnReporteVentas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReporteVentas.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteVentas.Location = new System.Drawing.Point(0, 28);
            this.btnReporteVentas.Name = "btnReporteVentas";
            this.btnReporteVentas.Size = new System.Drawing.Size(200, 28);
            this.btnReporteVentas.TabIndex = 3;
            this.btnReporteVentas.Text = "Reporte de Ventas";
            this.btnReporteVentas.UseVisualStyleBackColor = false;
            this.btnReporteVentas.Click += new System.EventHandler(this.btnReporteVentas_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 605);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelChildForm);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Farmacia";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panelMenuOptions.ResumeLayout(false);
            this.panelMenuOptions.PerformLayout();
            this.panelSubmenu3.ResumeLayout(false);
            this.panelSubmenu3.PerformLayout();
            this.panelSubmenu1.ResumeLayout(false);
            this.panelSubmenu1.PerformLayout();
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelUser.ResumeLayout(false);
            this.panelUser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button buttonHideMenu;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Panel panelMenuOptions;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnOpProductos;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Panel panelSubmenu1;
        private System.Windows.Forms.Button btnCategorias;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnOpVentas;
        private System.Windows.Forms.Panel panelSubmenu3;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Panel panelSubmenu4;
        private System.Windows.Forms.Button btnOpUsuarios;
        private System.Windows.Forms.Button btnProdVendidos;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel panelUser;
        private System.Windows.Forms.Label lblReloj;
        private System.Windows.Forms.Button btnReporteVentas;
    }
}