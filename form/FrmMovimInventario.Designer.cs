namespace RitramaAPP.form
{
    partial class FrmMovimInventario
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
            this.product_tipo = new System.Windows.Forms.Label();
            this.product_name = new System.Windows.Forms.Label();
            this.product_id = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grid_entradas = new System.Windows.Forms.DataGridView();
            this.grid_salidas = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_entradas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_salidas)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.product_tipo);
            this.panel1.Controls.Add(this.product_name);
            this.panel1.Controls.Add(this.product_id);
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 67);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // product_tipo
            // 
            this.product_tipo.AutoSize = true;
            this.product_tipo.Location = new System.Drawing.Point(21, 37);
            this.product_tipo.Name = "product_tipo";
            this.product_tipo.Size = new System.Drawing.Size(99, 13);
            this.product_tipo.TabIndex = 2;
            this.product_tipo.Text = "TIPO_PRODUCTO";
            // 
            // product_name
            // 
            this.product_name.AutoSize = true;
            this.product_name.Location = new System.Drawing.Point(21, 24);
            this.product_name.Name = "product_name";
            this.product_name.Size = new System.Drawing.Size(121, 13);
            this.product_name.TabIndex = 1;
            this.product_name.Text = "NOMBRE_PRODUCTO";
            // 
            // product_id
            // 
            this.product_id.AutoSize = true;
            this.product_id.Location = new System.Drawing.Point(21, 9);
            this.product_id.Name = "product_id";
            this.product_id.Size = new System.Drawing.Size(72, 13);
            this.product_id.TabIndex = 0;
            this.product_id.Text = "PRODICT_ID";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.grid_salidas);
            this.tabPage1.Controls.Add(this.grid_entradas);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(805, 344);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Movimientos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grid_entradas
            // 
            this.grid_entradas.AllowUserToAddRows = false;
            this.grid_entradas.AllowUserToDeleteRows = false;
            this.grid_entradas.AllowUserToResizeRows = false;
            this.grid_entradas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grid_entradas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_entradas.Location = new System.Drawing.Point(6, 29);
            this.grid_entradas.Name = "grid_entradas";
            this.grid_entradas.ReadOnly = true;
            this.grid_entradas.RowHeadersWidth = 25;
            this.grid_entradas.Size = new System.Drawing.Size(793, 143);
            this.grid_entradas.TabIndex = 0;
            // 
            // grid_salidas
            // 
            this.grid_salidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_salidas.Location = new System.Drawing.Point(6, 195);
            this.grid_salidas.Name = "grid_salidas";
            this.grid_salidas.Size = new System.Drawing.Size(793, 141);
            this.grid_salidas.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(3, 73);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(813, 370);
            this.tabControl1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ENTRADAS :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "SALIDAS :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(703, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FrmMovimInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmMovimInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pantalla de movimiento de Inventarios";
            this.Load += new System.EventHandler(this.FrmMovimInventario_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_entradas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_salidas)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label product_name;
        private System.Windows.Forms.Label product_id;
        private System.Windows.Forms.Label product_tipo;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grid_salidas;
        private System.Windows.Forms.DataGridView grid_entradas;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button button1;
    }
}