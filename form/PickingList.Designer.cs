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
            this.components = new System.ComponentModel.Container();
            this.tab_productos = new System.Windows.Forms.TabControl();
            this.tab_uniqueCode = new System.Windows.Forms.TabPage();
            this.grid_itemRC = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grid_productos = new System.Windows.Forms.DataGridView();
            this.bot_leer = new System.Windows.Forms.Button();
            this.bot_transferir = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bot_borrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_uniqueCode = new System.Windows.Forms.TextBox();
            this.REGISTROS_TOTALES = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tab_productos.SuspendLayout();
            this.tab_uniqueCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_itemRC)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_productos)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            // grid_itemRC
            // 
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
            // bot_leer
            // 
            this.bot_leer.Location = new System.Drawing.Point(424, 12);
            this.bot_leer.Name = "bot_leer";
            this.bot_leer.Size = new System.Drawing.Size(134, 23);
            this.bot_leer.TabIndex = 1;
            this.bot_leer.Text = "Leer Data";
            this.bot_leer.UseVisualStyleBackColor = true;
            this.bot_leer.Click += new System.EventHandler(this.Bot_leer_Click);
            // 
            // bot_transferir
            // 
            this.bot_transferir.Location = new System.Drawing.Point(424, 41);
            this.bot_transferir.Name = "bot_transferir";
            this.bot_transferir.Size = new System.Drawing.Size(134, 23);
            this.bot_transferir.TabIndex = 2;
            this.bot_transferir.Text = "Transferir Conduce";
            this.bot_transferir.UseVisualStyleBackColor = true;
            this.bot_transferir.Click += new System.EventHandler(this.Bot_transferir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bot_borrar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_uniqueCode);
            this.groupBox1.Controls.Add(this.REGISTROS_TOTALES);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informacion del Picking List Despacho";
            // 
            // bot_borrar
            // 
            this.bot_borrar.Location = new System.Drawing.Point(305, 71);
            this.bot_borrar.Name = "bot_borrar";
            this.bot_borrar.Size = new System.Drawing.Size(75, 23);
            this.bot_borrar.TabIndex = 4;
            this.bot_borrar.Text = "Borrar";
            this.bot_borrar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Unique Code :";
            // 
            // txt_uniqueCode
            // 
            this.txt_uniqueCode.Location = new System.Drawing.Point(91, 71);
            this.txt_uniqueCode.Name = "txt_uniqueCode";
            this.txt_uniqueCode.Size = new System.Drawing.Size(100, 20);
            this.txt_uniqueCode.TabIndex = 1;
            this.txt_uniqueCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_uniqueCode_KeyDown);
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
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
            ((System.ComponentModel.ISupportInitialize)(this.grid_itemRC)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_productos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_uniqueCode;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button bot_borrar;
    }
}