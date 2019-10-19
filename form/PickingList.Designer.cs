namespace RitramaAPP.form
{
    partial class PickingList
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
            this.tab_productos = new System.Windows.Forms.TabControl();
            this.tab_uniqueCode = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.bot_leer = new System.Windows.Forms.Button();
            this.bot_transferir = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grid_itemRC = new System.Windows.Forms.DataGridView();
            this.grid_productos = new System.Windows.Forms.DataGridView();
            this.REGISTROS_TOTALES = new System.Windows.Forms.Label();
            this.tab_productos.SuspendLayout();
            this.tab_uniqueCode.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_itemRC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_productos)).BeginInit();
            this.SuspendLayout();
            // 
            // tab_productos
            // 
            this.tab_productos.Controls.Add(this.tab_uniqueCode);
            this.tab_productos.Controls.Add(this.tabPage2);
            this.tab_productos.Location = new System.Drawing.Point(12, 120);
            this.tab_productos.Name = "tab_productos";
            this.tab_productos.SelectedIndex = 0;
            this.tab_productos.Size = new System.Drawing.Size(550, 318);
            this.tab_productos.TabIndex = 0;
            // 
            // tab_uniqueCode
            // 
            this.tab_uniqueCode.Controls.Add(this.grid_itemRC);
            this.tab_uniqueCode.Location = new System.Drawing.Point(4, 22);
            this.tab_uniqueCode.Name = "tab_uniqueCode";
            this.tab_uniqueCode.Padding = new System.Windows.Forms.Padding(3);
            this.tab_uniqueCode.Size = new System.Drawing.Size(542, 292);
            this.tab_uniqueCode.TabIndex = 0;
            this.tab_uniqueCode.Text = "Unique Code:";
            this.tab_uniqueCode.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grid_productos);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(542, 292);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Productos:";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // bot_leer
            // 
            this.bot_leer.Location = new System.Drawing.Point(424, 12);
            this.bot_leer.Name = "bot_leer";
            this.bot_leer.Size = new System.Drawing.Size(134, 23);
            this.bot_leer.TabIndex = 1;
            this.bot_leer.Text = "Leer Data";
            this.bot_leer.UseVisualStyleBackColor = true;
            this.bot_leer.Click += new System.EventHandler(this.bot_leer_Click);
            // 
            // bot_transferir
            // 
            this.bot_transferir.Location = new System.Drawing.Point(424, 41);
            this.bot_transferir.Name = "bot_transferir";
            this.bot_transferir.Size = new System.Drawing.Size(134, 23);
            this.bot_transferir.TabIndex = 2;
            this.bot_transferir.Text = "Transferir Conduce";
            this.bot_transferir.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.REGISTROS_TOTALES);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informacion del Picking List Despacho";
            // 
            // grid_itemRC
            // 
            this.grid_itemRC.AllowUserToAddRows = false;
            this.grid_itemRC.AllowUserToDeleteRows = false;
            this.grid_itemRC.AllowUserToResizeColumns = false;
            this.grid_itemRC.AllowUserToResizeRows = false;
            this.grid_itemRC.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grid_itemRC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_itemRC.Location = new System.Drawing.Point(6, 6);
            this.grid_itemRC.Name = "grid_itemRC";
            this.grid_itemRC.ReadOnly = true;
            this.grid_itemRC.RowHeadersWidth = 25;
            this.grid_itemRC.Size = new System.Drawing.Size(530, 280);
            this.grid_itemRC.TabIndex = 0;
            // 
            // grid_productos
            // 
            this.grid_productos.AllowUserToAddRows = false;
            this.grid_productos.AllowUserToDeleteRows = false;
            this.grid_productos.AllowUserToResizeRows = false;
            this.grid_productos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grid_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_productos.Location = new System.Drawing.Point(3, 6);
            this.grid_productos.Name = "grid_productos";
            this.grid_productos.ReadOnly = true;
            this.grid_productos.RowHeadersWidth = 25;
            this.grid_productos.Size = new System.Drawing.Size(533, 280);
            this.grid_productos.TabIndex = 0;
            // 
            // REGISTROS_TOTALES
            // 
            this.REGISTROS_TOTALES.AutoSize = true;
            this.REGISTROS_TOTALES.Location = new System.Drawing.Point(26, 38);
            this.REGISTROS_TOTALES.Name = "REGISTROS_TOTALES";
            this.REGISTROS_TOTALES.Size = new System.Drawing.Size(79, 13);
            this.REGISTROS_TOTALES.TabIndex = 0;
            this.REGISTROS_TOTALES.Text = "Total : Registro";
            // 
            // PickingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bot_transferir);
            this.Controls.Add(this.bot_leer);
            this.Controls.Add(this.tab_productos);
            this.Name = "PickingList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PickingList";
            this.Load += new System.EventHandler(this.PickingList_Load);
            this.tab_productos.ResumeLayout(false);
            this.tab_uniqueCode.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_itemRC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_productos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_productos;
        private System.Windows.Forms.TabPage tab_uniqueCode;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button bot_leer;
        private System.Windows.Forms.Button bot_transferir;
        private System.Windows.Forms.DataGridView grid_itemRC;
        private System.Windows.Forms.DataGridView grid_productos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label REGISTROS_TOTALES;
    }
}