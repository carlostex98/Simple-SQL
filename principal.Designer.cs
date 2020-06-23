namespace proyecto1
{
    partial class principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.editor = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejecutarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarTablasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verTokensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verErroresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verAstToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verTablasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tecnicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.logChanges = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fileN = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // editor
            // 
            this.editor.Location = new System.Drawing.Point(12, 58);
            this.editor.Name = "editor";
            this.editor.Size = new System.Drawing.Size(862, 304);
            this.editor.TabIndex = 0;
            this.editor.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(749, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Compilar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.herramientasToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(889, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.guardarComoToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.guardarComoToolStripMenuItem.Text = "Guardar como";
            this.guardarComoToolStripMenuItem.Click += new System.EventHandler(this.guardarComoToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ejecutarToolStripMenuItem,
            this.cargarTablasToolStripMenuItem,
            this.verTokensToolStripMenuItem,
            this.verErroresToolStripMenuItem,
            this.verAstToolStripMenuItem,
            this.verTablasToolStripMenuItem});
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // ejecutarToolStripMenuItem
            // 
            this.ejecutarToolStripMenuItem.Name = "ejecutarToolStripMenuItem";
            this.ejecutarToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.ejecutarToolStripMenuItem.Text = "Ejecutar";
            // 
            // cargarTablasToolStripMenuItem
            // 
            this.cargarTablasToolStripMenuItem.Name = "cargarTablasToolStripMenuItem";
            this.cargarTablasToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.cargarTablasToolStripMenuItem.Text = "Cargar tablas";
            this.cargarTablasToolStripMenuItem.Click += new System.EventHandler(this.cargarTablasToolStripMenuItem_Click);
            // 
            // verTokensToolStripMenuItem
            // 
            this.verTokensToolStripMenuItem.Name = "verTokensToolStripMenuItem";
            this.verTokensToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.verTokensToolStripMenuItem.Text = "Ver tokens";
            // 
            // verErroresToolStripMenuItem
            // 
            this.verErroresToolStripMenuItem.Name = "verErroresToolStripMenuItem";
            this.verErroresToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.verErroresToolStripMenuItem.Text = "Ver errores";
            // 
            // verAstToolStripMenuItem
            // 
            this.verAstToolStripMenuItem.Name = "verAstToolStripMenuItem";
            this.verAstToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.verAstToolStripMenuItem.Text = "Ver ast";
            // 
            // verTablasToolStripMenuItem
            // 
            this.verTablasToolStripMenuItem.Name = "verTablasToolStripMenuItem";
            this.verTablasToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.verTablasToolStripMenuItem.Text = "Ver tablas";
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualesToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // manualesToolStripMenuItem
            // 
            this.manualesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tecnicoToolStripMenuItem,
            this.usuarioToolStripMenuItem});
            this.manualesToolStripMenuItem.Name = "manualesToolStripMenuItem";
            this.manualesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.manualesToolStripMenuItem.Text = "Manuales";
            // 
            // tecnicoToolStripMenuItem
            // 
            this.tecnicoToolStripMenuItem.Name = "tecnicoToolStripMenuItem";
            this.tecnicoToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.tecnicoToolStripMenuItem.Text = "Tecnico";
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.usuarioToolStripMenuItem.Text = "Usuario";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 392);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Log de cambios";
            // 
            // logChanges
            // 
            this.logChanges.BackColor = System.Drawing.SystemColors.InfoText;
            this.logChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logChanges.ForeColor = System.Drawing.Color.Lime;
            this.logChanges.Location = new System.Drawing.Point(12, 408);
            this.logChanges.Name = "logChanges";
            this.logChanges.Size = new System.Drawing.Size(862, 122);
            this.logChanges.TabIndex = 5;
            this.logChanges.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Archivo en vista: ";
            // 
            // fileN
            // 
            this.fileN.AutoSize = true;
            this.fileN.Location = new System.Drawing.Point(107, 39);
            this.fileN.Name = "fileN";
            this.fileN.Size = new System.Drawing.Size(35, 13);
            this.fileN.TabIndex = 7;
            this.fileN.Text = "label3";
            // 
            // principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 547);
            this.Controls.Add(this.fileN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.logChanges);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.editor);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "principal";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox editor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejecutarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarTablasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verTokensToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verErroresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verAstToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tecnicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox logChanges;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label fileN;
        private System.Windows.Forms.ToolStripMenuItem verTablasToolStripMenuItem;
    }
}

