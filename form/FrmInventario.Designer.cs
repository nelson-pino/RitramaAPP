namespace RitramaAPP
{
    partial class FrmInventario
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CONTADOR_REGISTROS = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bot_borrar = new System.Windows.Forms.Button();
            this.bot_editar = new System.Windows.Forms.Button();
            this.bot_incluir = new System.Windows.Forms.Button();
            this.bot_sincro = new System.Windows.Forms.Button();
            this.txt_buscar = new System.Windows.Forms.TextBox();
            this.grid_iniciales = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.bot_buscar_ini = new System.Windows.Forms.Button();
            this.RAD_TIPO = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_iniciales)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label15);
            this.panel1.Location = new System.Drawing.Point(9, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 98);
            this.panel1.TabIndex = 36;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(242, 35);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(278, 25);
            this.label15.TabIndex = 0;
            this.label15.Text = "MODULO DE INVENTARIO";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(9, 113);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(846, 795);
            this.tabControl1.TabIndex = 37;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.bot_buscar_ini);
            this.tabPage1.Controls.Add(this.CONTADOR_REGISTROS);
            this.tabPage1.Controls.Add(this.checkBox3);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.bot_borrar);
            this.tabPage1.Controls.Add(this.bot_editar);
            this.tabPage1.Controls.Add(this.bot_incluir);
            this.tabPage1.Controls.Add(this.bot_sincro);
            this.tabPage1.Controls.Add(this.txt_buscar);
            this.tabPage1.Controls.Add(this.grid_iniciales);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(838, 769);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Toma Fisica";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.TabPage1_Click);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(46, 372);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(191, 17);
            this.checkBox3.TabIndex = 9;
            this.checkBox3.Text = "Si el producto existe sobreescribirlo";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RAD_TIPO);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(718, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(113, 129);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Busqueda:";
            // 
            // CONTADOR_REGISTROS
            // 
            this.CONTADOR_REGISTROS.AutoSize = true;
            this.CONTADOR_REGISTROS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CONTADOR_REGISTROS.Location = new System.Drawing.Point(545, 347);
            this.CONTADOR_REGISTROS.Name = "CONTADOR_REGISTROS";
            this.CONTADOR_REGISTROS.Size = new System.Drawing.Size(125, 13);
            this.CONTADOR_REGISTROS.TabIndex = 8;
            this.CONTADOR_REGISTROS.Text = "Numero de Registros";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(6, 58);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(109, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Nombre Producto";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 35);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(75, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Product Id";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Introduzca la palabra clave para buscar productos";
            // 
            // bot_borrar
            // 
            this.bot_borrar.Location = new System.Drawing.Point(721, 161);
            this.bot_borrar.Name = "bot_borrar";
            this.bot_borrar.Size = new System.Drawing.Size(105, 23);
            this.bot_borrar.TabIndex = 5;
            this.bot_borrar.Text = "Borrar Fila";
            this.bot_borrar.UseVisualStyleBackColor = true;
            // 
            // bot_editar
            // 
            this.bot_editar.Location = new System.Drawing.Point(721, 132);
            this.bot_editar.Name = "bot_editar";
            this.bot_editar.Size = new System.Drawing.Size(105, 23);
            this.bot_editar.TabIndex = 4;
            this.bot_editar.Text = "Editar";
            this.bot_editar.UseVisualStyleBackColor = true;
            // 
            // bot_incluir
            // 
            this.bot_incluir.Location = new System.Drawing.Point(721, 103);
            this.bot_incluir.Name = "bot_incluir";
            this.bot_incluir.Size = new System.Drawing.Size(105, 23);
            this.bot_incluir.TabIndex = 3;
            this.bot_incluir.Text = "Incluir";
            this.bot_incluir.UseVisualStyleBackColor = true;
            // 
            // bot_sincro
            // 
            this.bot_sincro.Location = new System.Drawing.Point(721, 74);
            this.bot_sincro.Name = "bot_sincro";
            this.bot_sincro.Size = new System.Drawing.Size(105, 23);
            this.bot_sincro.TabIndex = 2;
            this.bot_sincro.Text = "Cargar Data";
            this.bot_sincro.UseVisualStyleBackColor = true;
            this.bot_sincro.Click += new System.EventHandler(this.Bot_sincro_Click);
            // 
            // txt_buscar
            // 
            this.txt_buscar.Location = new System.Drawing.Point(7, 49);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(595, 20);
            this.txt_buscar.TabIndex = 1;
            // 
            // grid_iniciales
            // 
            this.grid_iniciales.AllowUserToResizeRows = false;
            this.grid_iniciales.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grid_iniciales.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.grid_iniciales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_iniciales.Location = new System.Drawing.Point(5, 75);
            this.grid_iniciales.MultiSelect = false;
            this.grid_iniciales.Name = "grid_iniciales";
            this.grid_iniciales.ReadOnly = true;
            this.grid_iniciales.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.grid_iniciales.RowHeadersWidth = 24;
            this.grid_iniciales.Size = new System.Drawing.Size(708, 254);
            this.grid_iniciales.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(838, 769);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Consulta de Inventario";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // bot_buscar_ini
            // 
            this.bot_buscar_ini.Location = new System.Drawing.Point(608, 46);
            this.bot_buscar_ini.Name = "bot_buscar_ini";
            this.bot_buscar_ini.Size = new System.Drawing.Size(105, 23);
            this.bot_buscar_ini.TabIndex = 10;
            this.bot_buscar_ini.Text = "Buscar";
            this.bot_buscar_ini.UseVisualStyleBackColor = true;
            // 
            // RAD_TIPO
            // 
            this.RAD_TIPO.AutoSize = true;
            this.RAD_TIPO.Location = new System.Drawing.Point(6, 81);
            this.RAD_TIPO.Name = "RAD_TIPO";
            this.RAD_TIPO.Size = new System.Drawing.Size(47, 17);
            this.RAD_TIPO.TabIndex = 2;
            this.RAD_TIPO.Text = "Tipo";
            this.RAD_TIPO.UseVisualStyleBackColor = true;
            // 
            // FrmInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 920);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmInventario";
            this.Text = "FrmInventario";
            this.Load += new System.EventHandler(this.FrmInventario_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_iniciales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txt_buscar;
        private System.Windows.Forms.DataGridView grid_iniciales;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bot_borrar;
        private System.Windows.Forms.Button bot_editar;
        private System.Windows.Forms.Button bot_incluir;
        private System.Windows.Forms.Button bot_sincro;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label CONTADOR_REGISTROS;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Button bot_buscar_ini;
        private System.Windows.Forms.CheckBox RAD_TIPO;
    }
}