﻿namespace RitramaAPP.form
{
    partial class FrmImportExcelMP
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
            this.GRID_IMPORT = new System.Windows.Forms.DataGridView();
            this.bot_select_file = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TXT_PATH_FILENAME = new System.Windows.Forms.TextBox();
            this.bot_borrar_data = new System.Windows.Forms.Button();
            this.TXT_NOMBRE_HOJA = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TXT_ROWS = new System.Windows.Forms.TextBox();
            this.BOT_LOAD_DATA = new System.Windows.Forms.Button();
            this.TXT_BUSCAR = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RA_ROLLID = new System.Windows.Forms.RadioButton();
            this.RA_PRODUCTNAME = new System.Windows.Forms.RadioButton();
            this.RA_CODIGO = new System.Windows.Forms.RadioButton();
            this.ROWS_FOUND = new System.Windows.Forms.Label();
            this.TXT_LOG_PROCESS = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.bot_validar = new System.Windows.Forms.Button();
            this.BOT_SEND_DATA = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RA_PACKING = new System.Windows.Forms.RadioButton();
            this.RA_RESMAS = new System.Windows.Forms.RadioButton();
            this.RA_GRAPHICS = new System.Windows.Forms.RadioButton();
            this.RA_CORTADOS = new System.Windows.Forms.RadioButton();
            this.RA_MASTERS = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.GRID_IMPORT)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GRID_IMPORT
            // 
            this.GRID_IMPORT.AllowUserToAddRows = false;
            this.GRID_IMPORT.AllowUserToDeleteRows = false;
            this.GRID_IMPORT.AllowUserToResizeRows = false;
            this.GRID_IMPORT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GRID_IMPORT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GRID_IMPORT.Location = new System.Drawing.Point(12, 88);
            this.GRID_IMPORT.Name = "GRID_IMPORT";
            this.GRID_IMPORT.ReadOnly = true;
            this.GRID_IMPORT.RowHeadersWidth = 25;
            this.GRID_IMPORT.Size = new System.Drawing.Size(776, 365);
            this.GRID_IMPORT.TabIndex = 0;
            this.GRID_IMPORT.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GRID_IMPORT_CellContentClick);
            // 
            // bot_select_file
            // 
            this.bot_select_file.Location = new System.Drawing.Point(441, 4);
            this.bot_select_file.Name = "bot_select_file";
            this.bot_select_file.Size = new System.Drawing.Size(87, 23);
            this.bot_select_file.TabIndex = 1;
            this.bot_select_file.Text = "Selecccionar";
            this.bot_select_file.UseVisualStyleBackColor = true;
            this.bot_select_file.Click += new System.EventHandler(this.Bot_import_data_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ruta del Archivo :";
            // 
            // TXT_PATH_FILENAME
            // 
            this.TXT_PATH_FILENAME.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_PATH_FILENAME.Location = new System.Drawing.Point(113, 6);
            this.TXT_PATH_FILENAME.Name = "TXT_PATH_FILENAME";
            this.TXT_PATH_FILENAME.Size = new System.Drawing.Size(322, 20);
            this.TXT_PATH_FILENAME.TabIndex = 3;
            // 
            // bot_borrar_data
            // 
            this.bot_borrar_data.Location = new System.Drawing.Point(794, 117);
            this.bot_borrar_data.Name = "bot_borrar_data";
            this.bot_borrar_data.Size = new System.Drawing.Size(96, 23);
            this.bot_borrar_data.TabIndex = 6;
            this.bot_borrar_data.Text = "Borrar Data";
            this.bot_borrar_data.UseVisualStyleBackColor = true;
            this.bot_borrar_data.Click += new System.EventHandler(this.bot_borrar_data_Click);
            // 
            // TXT_NOMBRE_HOJA
            // 
            this.TXT_NOMBRE_HOJA.Location = new System.Drawing.Point(113, 32);
            this.TXT_NOMBRE_HOJA.Name = "TXT_NOMBRE_HOJA";
            this.TXT_NOMBRE_HOJA.Size = new System.Drawing.Size(322, 20);
            this.TXT_NOMBRE_HOJA.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nombre de la Hoja :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(537, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Numero de Filas :";
            // 
            // TXT_ROWS
            // 
            this.TXT_ROWS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_ROWS.Location = new System.Drawing.Point(632, 4);
            this.TXT_ROWS.Name = "TXT_ROWS";
            this.TXT_ROWS.ReadOnly = true;
            this.TXT_ROWS.Size = new System.Drawing.Size(89, 20);
            this.TXT_ROWS.TabIndex = 10;
            // 
            // BOT_LOAD_DATA
            // 
            this.BOT_LOAD_DATA.Location = new System.Drawing.Point(441, 31);
            this.BOT_LOAD_DATA.Name = "BOT_LOAD_DATA";
            this.BOT_LOAD_DATA.Size = new System.Drawing.Size(87, 23);
            this.BOT_LOAD_DATA.TabIndex = 11;
            this.BOT_LOAD_DATA.Text = "Cargar";
            this.BOT_LOAD_DATA.UseVisualStyleBackColor = true;
            this.BOT_LOAD_DATA.Click += new System.EventHandler(this.BOT_LOAD_DATA_Click);
            // 
            // TXT_BUSCAR
            // 
            this.TXT_BUSCAR.Location = new System.Drawing.Point(113, 58);
            this.TXT_BUSCAR.Name = "TXT_BUSCAR";
            this.TXT_BUSCAR.Size = new System.Drawing.Size(322, 20);
            this.TXT_BUSCAR.TabIndex = 12;
            this.TXT_BUSCAR.TextChanged += new System.EventHandler(this.TXT_BUSCAR_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Buscar Por :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RA_ROLLID);
            this.groupBox1.Controls.Add(this.RA_PRODUCTNAME);
            this.groupBox1.Controls.Add(this.RA_CODIGO);
            this.groupBox1.Location = new System.Drawing.Point(13, 460);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Busquedas";
            // 
            // RA_ROLLID
            // 
            this.RA_ROLLID.AutoSize = true;
            this.RA_ROLLID.Location = new System.Drawing.Point(7, 50);
            this.RA_ROLLID.Name = "RA_ROLLID";
            this.RA_ROLLID.Size = new System.Drawing.Size(55, 17);
            this.RA_ROLLID.TabIndex = 2;
            this.RA_ROLLID.TabStop = true;
            this.RA_ROLLID.Text = "Roll Id";
            this.RA_ROLLID.UseVisualStyleBackColor = true;
            // 
            // RA_PRODUCTNAME
            // 
            this.RA_PRODUCTNAME.AutoSize = true;
            this.RA_PRODUCTNAME.Location = new System.Drawing.Point(7, 35);
            this.RA_PRODUCTNAME.Name = "RA_PRODUCTNAME";
            this.RA_PRODUCTNAME.Size = new System.Drawing.Size(144, 17);
            this.RA_PRODUCTNAME.TabIndex = 1;
            this.RA_PRODUCTNAME.TabStop = true;
            this.RA_PRODUCTNAME.Text = "Descripcion del Producto";
            this.RA_PRODUCTNAME.UseVisualStyleBackColor = true;
            // 
            // RA_CODIGO
            // 
            this.RA_CODIGO.AutoSize = true;
            this.RA_CODIGO.Checked = true;
            this.RA_CODIGO.Location = new System.Drawing.Point(7, 20);
            this.RA_CODIGO.Name = "RA_CODIGO";
            this.RA_CODIGO.Size = new System.Drawing.Size(58, 17);
            this.RA_CODIGO.TabIndex = 0;
            this.RA_CODIGO.TabStop = true;
            this.RA_CODIGO.Text = "Codigo";
            this.RA_CODIGO.UseVisualStyleBackColor = true;
            // 
            // ROWS_FOUND
            // 
            this.ROWS_FOUND.AutoSize = true;
            this.ROWS_FOUND.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ROWS_FOUND.Location = new System.Drawing.Point(727, 7);
            this.ROWS_FOUND.Name = "ROWS_FOUND";
            this.ROWS_FOUND.Size = new System.Drawing.Size(88, 13);
            this.ROWS_FOUND.TabIndex = 15;
            this.ROWS_FOUND.Text = "0 encontrados";
            // 
            // TXT_LOG_PROCESS
            // 
            this.TXT_LOG_PROCESS.Location = new System.Drawing.Point(219, 479);
            this.TXT_LOG_PROCESS.Multiline = true;
            this.TXT_LOG_PROCESS.Name = "TXT_LOG_PROCESS";
            this.TXT_LOG_PROCESS.Size = new System.Drawing.Size(260, 81);
            this.TXT_LOG_PROCESS.TabIndex = 16;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(219, 460);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Informacion de  Procesos";
            // 
            // bot_validar
            // 
            this.bot_validar.Location = new System.Drawing.Point(794, 146);
            this.bot_validar.Name = "bot_validar";
            this.bot_validar.Size = new System.Drawing.Size(96, 23);
            this.bot_validar.TabIndex = 19;
            this.bot_validar.Text = "Depurar Data";
            this.bot_validar.UseVisualStyleBackColor = true;
            this.bot_validar.Click += new System.EventHandler(this.bot_convertir_Click);
            // 
            // BOT_SEND_DATA
            // 
            this.BOT_SEND_DATA.Location = new System.Drawing.Point(794, 88);
            this.BOT_SEND_DATA.Name = "BOT_SEND_DATA";
            this.BOT_SEND_DATA.Size = new System.Drawing.Size(96, 23);
            this.BOT_SEND_DATA.TabIndex = 20;
            this.BOT_SEND_DATA.Text = "Enviar Data";
            this.BOT_SEND_DATA.UseVisualStyleBackColor = true;
            this.BOT_SEND_DATA.Click += new System.EventHandler(this.BOT_SEND_DATA_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RA_PACKING);
            this.groupBox2.Controls.Add(this.RA_RESMAS);
            this.groupBox2.Controls.Add(this.RA_GRAPHICS);
            this.groupBox2.Controls.Add(this.RA_CORTADOS);
            this.groupBox2.Controls.Add(this.RA_MASTERS);
            this.groupBox2.Location = new System.Drawing.Point(493, 460);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo de proceso";
            // 
            // RA_PACKING
            // 
            this.RA_PACKING.AutoSize = true;
            this.RA_PACKING.Location = new System.Drawing.Point(7, 80);
            this.RA_PACKING.Name = "RA_PACKING";
            this.RA_PACKING.Size = new System.Drawing.Size(141, 17);
            this.RA_PACKING.TabIndex = 4;
            this.RA_PACKING.TabStop = true;
            this.RA_PACKING.Text = "Documento Packing List";
            this.RA_PACKING.UseVisualStyleBackColor = true;
            // 
            // RA_RESMAS
            // 
            this.RA_RESMAS.AutoSize = true;
            this.RA_RESMAS.Location = new System.Drawing.Point(7, 65);
            this.RA_RESMAS.Name = "RA_RESMAS";
            this.RA_RESMAS.Size = new System.Drawing.Size(93, 17);
            this.RA_RESMAS.TabIndex = 3;
            this.RA_RESMAS.TabStop = true;
            this.RA_RESMAS.Text = "Inicial Resmas";
            this.RA_RESMAS.UseVisualStyleBackColor = true;
            // 
            // RA_GRAPHICS
            // 
            this.RA_GRAPHICS.AutoSize = true;
            this.RA_GRAPHICS.Location = new System.Drawing.Point(7, 50);
            this.RA_GRAPHICS.Name = "RA_GRAPHICS";
            this.RA_GRAPHICS.Size = new System.Drawing.Size(97, 17);
            this.RA_GRAPHICS.TabIndex = 2;
            this.RA_GRAPHICS.TabStop = true;
            this.RA_GRAPHICS.Text = "Inicial Graphics";
            this.RA_GRAPHICS.UseVisualStyleBackColor = true;
            // 
            // RA_CORTADOS
            // 
            this.RA_CORTADOS.AutoSize = true;
            this.RA_CORTADOS.Location = new System.Drawing.Point(7, 35);
            this.RA_CORTADOS.Name = "RA_CORTADOS";
            this.RA_CORTADOS.Size = new System.Drawing.Size(129, 17);
            this.RA_CORTADOS.TabIndex = 1;
            this.RA_CORTADOS.TabStop = true;
            this.RA_CORTADOS.Text = "Inicial Rollos Cortados";
            this.RA_CORTADOS.UseVisualStyleBackColor = true;
            // 
            // RA_MASTERS
            // 
            this.RA_MASTERS.AutoSize = true;
            this.RA_MASTERS.Checked = true;
            this.RA_MASTERS.Location = new System.Drawing.Point(7, 20);
            this.RA_MASTERS.Name = "RA_MASTERS";
            this.RA_MASTERS.Size = new System.Drawing.Size(113, 17);
            this.RA_MASTERS.TabIndex = 0;
            this.RA_MASTERS.TabStop = true;
            this.RA_MASTERS.Text = "Inicial Rolls Master";
            this.RA_MASTERS.UseVisualStyleBackColor = true;
            // 
            // FrmImportExcelMP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 563);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.BOT_SEND_DATA);
            this.Controls.Add(this.bot_validar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TXT_LOG_PROCESS);
            this.Controls.Add(this.ROWS_FOUND);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TXT_BUSCAR);
            this.Controls.Add(this.BOT_LOAD_DATA);
            this.Controls.Add(this.TXT_ROWS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TXT_NOMBRE_HOJA);
            this.Controls.Add(this.bot_borrar_data);
            this.Controls.Add(this.TXT_PATH_FILENAME);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bot_select_file);
            this.Controls.Add(this.GRID_IMPORT);
            this.Name = "FrmImportExcelMP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar data desde EXCEL";
            this.Load += new System.EventHandler(this.FrmImportExcelMP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GRID_IMPORT)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GRID_IMPORT;
        private System.Windows.Forms.Button bot_select_file;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TXT_PATH_FILENAME;
        private System.Windows.Forms.Button bot_borrar_data;
        private System.Windows.Forms.TextBox TXT_NOMBRE_HOJA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TXT_ROWS;
        private System.Windows.Forms.Button BOT_LOAD_DATA;
        private System.Windows.Forms.TextBox TXT_BUSCAR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RA_ROLLID;
        private System.Windows.Forms.RadioButton RA_PRODUCTNAME;
        private System.Windows.Forms.RadioButton RA_CODIGO;
        private System.Windows.Forms.Label ROWS_FOUND;
        private System.Windows.Forms.TextBox TXT_LOG_PROCESS;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bot_validar;
        private System.Windows.Forms.Button BOT_SEND_DATA;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RA_PACKING;
        private System.Windows.Forms.RadioButton RA_RESMAS;
        private System.Windows.Forms.RadioButton RA_GRAPHICS;
        private System.Windows.Forms.RadioButton RA_CORTADOS;
        private System.Windows.Forms.RadioButton RA_MASTERS;
    }
}