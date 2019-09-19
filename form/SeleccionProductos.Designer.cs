namespace RitramaAPP.form
{
    partial class SeleccionProductos
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
            this.grid_productos = new System.Windows.Forms.DataGridView();
            this.txt_buscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rad_producto = new System.Windows.Forms.RadioButton();
            this.rad_codigo = new System.Windows.Forms.RadioButton();
            this.lbl_contador_registros = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid_productos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid_productos
            // 
            this.grid_productos.AllowUserToAddRows = false;
            this.grid_productos.AllowUserToDeleteRows = false;
            this.grid_productos.AllowUserToResizeRows = false;
            this.grid_productos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grid_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_productos.Location = new System.Drawing.Point(16, 88);
            this.grid_productos.Name = "grid_productos";
            this.grid_productos.ReadOnly = true;
            this.grid_productos.RowHeadersWidth = 35;
            this.grid_productos.RowTemplate.Height = 24;
            this.grid_productos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grid_productos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_productos.Size = new System.Drawing.Size(492, 399);
            this.grid_productos.TabIndex = 1;
            this.grid_productos.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Grid_productos_CellMouseDoubleClick);
            // 
            // txt_buscar
            // 
            this.txt_buscar.Location = new System.Drawing.Point(12, 60);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(492, 22);
            this.txt_buscar.TabIndex = 0;
            this.txt_buscar.TextChanged += new System.EventHandler(this.Txt_buscar_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "busqueda por:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rad_producto);
            this.groupBox1.Controls.Add(this.rad_codigo);
            this.groupBox1.Location = new System.Drawing.Point(304, 493);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 95);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar por:";
            // 
            // rad_producto
            // 
            this.rad_producto.AutoSize = true;
            this.rad_producto.Checked = true;
            this.rad_producto.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad_producto.Location = new System.Drawing.Point(29, 55);
            this.rad_producto.Name = "rad_producto";
            this.rad_producto.Size = new System.Drawing.Size(131, 21);
            this.rad_producto.TabIndex = 1;
            this.rad_producto.TabStop = true;
            this.rad_producto.Text = "Product Name";
            this.rad_producto.UseVisualStyleBackColor = true;
            // 
            // rad_codigo
            // 
            this.rad_codigo.AutoSize = true;
            this.rad_codigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad_codigo.Location = new System.Drawing.Point(29, 28);
            this.rad_codigo.Name = "rad_codigo";
            this.rad_codigo.Size = new System.Drawing.Size(79, 21);
            this.rad_codigo.TabIndex = 0;
            this.rad_codigo.Text = "Codigo";
            this.rad_codigo.UseVisualStyleBackColor = true;
            // 
            // lbl_contador_registros
            // 
            this.lbl_contador_registros.AutoSize = true;
            this.lbl_contador_registros.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_contador_registros.Location = new System.Drawing.Point(44, 521);
            this.lbl_contador_registros.Name = "lbl_contador_registros";
            this.lbl_contador_registros.Size = new System.Drawing.Size(123, 17);
            this.lbl_contador_registros.TabIndex = 2;
            this.lbl_contador_registros.Text = "0 de 0 registros";
            // 
            // SeleccionProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 618);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_contador_registros);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_buscar);
            this.Controls.Add(this.grid_productos);
            this.Name = "SeleccionProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busqueda de productos:";
            this.Load += new System.EventHandler(this.SeleccionProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_productos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grid_productos;
        private System.Windows.Forms.TextBox txt_buscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rad_producto;
        private System.Windows.Forms.RadioButton rad_codigo;
        private System.Windows.Forms.Label lbl_contador_registros;
    }
}