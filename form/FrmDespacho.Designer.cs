﻿namespace RitramaAPP.form
{
    partial class FrmDespacho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDespacho));
            this.NumeroDespachoLabel = new System.Windows.Forms.Label();
            this.txt_numero_despacho = new System.Windows.Forms.TextBox();
            this.txt_fecha_despacho = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_customer_id = new System.Windows.Forms.TextBox();
            this.CustomerIDLabel = new System.Windows.Forms.Label();
            this.txt_customer_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_customer_direc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_contact_person = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_vendor_id = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bot_vendor_search = new System.Windows.Forms.Button();
            this.txt_vendor_name = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_transport_name = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.bot_transport_search = new System.Windows.Forms.Button();
            this.txt_transport_id = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.bot_chofer_search = new System.Windows.Forms.Button();
            this.txt_chofer_id = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_chofer_name = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.BOT_CAMION = new System.Windows.Forms.Button();
            this.txt_placas = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_camion = new System.Windows.Forms.TextBox();
            this.grid_items = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BOT_PRIMERO = new System.Windows.Forms.ToolStripButton();
            this.BOT_ANTERIOR = new System.Windows.Forms.ToolStripButton();
            this.BOT_SIGUIENTE = new System.Windows.Forms.ToolStripButton();
            this.BOT_ULTIMO = new System.Windows.Forms.ToolStripButton();
            this.bot_nuevo = new System.Windows.Forms.ToolStripButton();
            this.BOT_CANCELAR = new System.Windows.Forms.ToolStripButton();
            this.BOT_SAVE = new System.Windows.Forms.ToolStripButton();
            this.bot_modificar = new System.Windows.Forms.ToolStripButton();
            this.BOT_BUSCAR = new System.Windows.Forms.ToolStripButton();
            this.BOT_IMPRIMIR = new System.Windows.Forms.ToolStripButton();
            this.bot_sincro = new System.Windows.Forms.ToolStripButton();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_tipo_embalaje = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_otrabajo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_ocompra = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_subtotal = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_monto_itbis = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txt_total_despacho = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txt_porc_itbis = new System.Windows.Forms.TextBox();
            this.bot_buscar_clientes = new System.Windows.Forms.Button();
            this.bot_agregar_renglon = new System.Windows.Forms.Button();
            this.bot_eliminar_renglon = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grid_UniqueCode = new System.Windows.Forms.DataGridView();
            this.BOT_DESPACHOS_RC = new System.Windows.Forms.Button();
            this.BOT_DETALLE_RC = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid_items)).BeginInit();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_UniqueCode)).BeginInit();
            this.SuspendLayout();
            // 
            // NumeroDespachoLabel
            // 
            this.NumeroDespachoLabel.AutoSize = true;
            this.NumeroDespachoLabel.Location = new System.Drawing.Point(22, 89);
            this.NumeroDespachoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NumeroDespachoLabel.Name = "NumeroDespachoLabel";
            this.NumeroDespachoLabel.Size = new System.Drawing.Size(99, 13);
            this.NumeroDespachoLabel.TabIndex = 0;
            this.NumeroDespachoLabel.Text = "Numero Despacho:";
            // 
            // txt_numero_despacho
            // 
            this.txt_numero_despacho.Location = new System.Drawing.Point(24, 105);
            this.txt_numero_despacho.Margin = new System.Windows.Forms.Padding(2);
            this.txt_numero_despacho.Name = "txt_numero_despacho";
            this.txt_numero_despacho.ReadOnly = true;
            this.txt_numero_despacho.Size = new System.Drawing.Size(96, 20);
            this.txt_numero_despacho.TabIndex = 1;
            // 
            // txt_fecha_despacho
            // 
            this.txt_fecha_despacho.Enabled = false;
            this.txt_fecha_despacho.Location = new System.Drawing.Point(124, 105);
            this.txt_fecha_despacho.Margin = new System.Windows.Forms.Padding(2);
            this.txt_fecha_despacho.Name = "txt_fecha_despacho";
            this.txt_fecha_despacho.Size = new System.Drawing.Size(186, 20);
            this.txt_fecha_despacho.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fecha :";
            // 
            // txt_customer_id
            // 
            this.txt_customer_id.Location = new System.Drawing.Point(351, 105);
            this.txt_customer_id.Margin = new System.Windows.Forms.Padding(2);
            this.txt_customer_id.Name = "txt_customer_id";
            this.txt_customer_id.ReadOnly = true;
            this.txt_customer_id.Size = new System.Drawing.Size(61, 20);
            this.txt_customer_id.TabIndex = 5;
            // 
            // CustomerIDLabel
            // 
            this.CustomerIDLabel.AutoSize = true;
            this.CustomerIDLabel.Location = new System.Drawing.Point(348, 89);
            this.CustomerIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CustomerIDLabel.Name = "CustomerIDLabel";
            this.CustomerIDLabel.Size = new System.Drawing.Size(66, 13);
            this.CustomerIDLabel.TabIndex = 4;
            this.CustomerIDLabel.Text = "Customer Id:";
            // 
            // txt_customer_name
            // 
            this.txt_customer_name.Location = new System.Drawing.Point(416, 105);
            this.txt_customer_name.Margin = new System.Windows.Forms.Padding(2);
            this.txt_customer_name.Name = "txt_customer_name";
            this.txt_customer_name.ReadOnly = true;
            this.txt_customer_name.Size = new System.Drawing.Size(245, 20);
            this.txt_customer_name.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(414, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Customer Name:";
            // 
            // txt_customer_direc
            // 
            this.txt_customer_direc.Location = new System.Drawing.Point(24, 150);
            this.txt_customer_direc.Margin = new System.Windows.Forms.Padding(2);
            this.txt_customer_direc.Name = "txt_customer_direc";
            this.txt_customer_direc.ReadOnly = true;
            this.txt_customer_direc.Size = new System.Drawing.Size(251, 20);
            this.txt_customer_direc.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 134);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Direccion Cliente:";
            // 
            // txt_contact_person
            // 
            this.txt_contact_person.Location = new System.Drawing.Point(278, 150);
            this.txt_contact_person.Margin = new System.Windows.Forms.Padding(2);
            this.txt_contact_person.Name = "txt_contact_person";
            this.txt_contact_person.ReadOnly = true;
            this.txt_contact_person.Size = new System.Drawing.Size(383, 20);
            this.txt_contact_person.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 134);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Entregar a :";
            // 
            // txt_vendor_id
            // 
            this.txt_vendor_id.Location = new System.Drawing.Point(24, 197);
            this.txt_vendor_id.Margin = new System.Windows.Forms.Padding(2);
            this.txt_vendor_id.Name = "txt_vendor_id";
            this.txt_vendor_id.ReadOnly = true;
            this.txt_vendor_id.Size = new System.Drawing.Size(78, 20);
            this.txt_vendor_id.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 180);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Vendedor Id.";
            // 
            // bot_vendor_search
            // 
            this.bot_vendor_search.Enabled = false;
            this.bot_vendor_search.Location = new System.Drawing.Point(105, 196);
            this.bot_vendor_search.Margin = new System.Windows.Forms.Padding(2);
            this.bot_vendor_search.Name = "bot_vendor_search";
            this.bot_vendor_search.Size = new System.Drawing.Size(29, 19);
            this.bot_vendor_search.TabIndex = 16;
            this.bot_vendor_search.Text = "...";
            this.bot_vendor_search.UseVisualStyleBackColor = true;
            this.bot_vendor_search.Click += new System.EventHandler(this.Bot_vendor_search_Click);
            // 
            // txt_vendor_name
            // 
            this.txt_vendor_name.Location = new System.Drawing.Point(139, 196);
            this.txt_vendor_name.Margin = new System.Windows.Forms.Padding(2);
            this.txt_vendor_name.Name = "txt_vendor_name";
            this.txt_vendor_name.ReadOnly = true;
            this.txt_vendor_name.Size = new System.Drawing.Size(174, 20);
            this.txt_vendor_name.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(136, 180);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Nombre del Vendedor.";
            // 
            // txt_transport_name
            // 
            this.txt_transport_name.Location = new System.Drawing.Point(430, 195);
            this.txt_transport_name.Margin = new System.Windows.Forms.Padding(2);
            this.txt_transport_name.Name = "txt_transport_name";
            this.txt_transport_name.ReadOnly = true;
            this.txt_transport_name.Size = new System.Drawing.Size(192, 20);
            this.txt_transport_name.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(428, 180);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Transportista";
            // 
            // bot_transport_search
            // 
            this.bot_transport_search.Enabled = false;
            this.bot_transport_search.Location = new System.Drawing.Point(397, 195);
            this.bot_transport_search.Margin = new System.Windows.Forms.Padding(2);
            this.bot_transport_search.Name = "bot_transport_search";
            this.bot_transport_search.Size = new System.Drawing.Size(29, 19);
            this.bot_transport_search.TabIndex = 23;
            this.bot_transport_search.Text = "...";
            this.bot_transport_search.UseVisualStyleBackColor = true;
            this.bot_transport_search.Click += new System.EventHandler(this.Bot_transport_search_Click);
            // 
            // txt_transport_id
            // 
            this.txt_transport_id.Location = new System.Drawing.Point(316, 196);
            this.txt_transport_id.Margin = new System.Windows.Forms.Padding(2);
            this.txt_transport_id.Name = "txt_transport_id";
            this.txt_transport_id.ReadOnly = true;
            this.txt_transport_id.Size = new System.Drawing.Size(78, 20);
            this.txt_transport_id.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(314, 180);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Transporte Id.";
            // 
            // bot_chofer_search
            // 
            this.bot_chofer_search.Enabled = false;
            this.bot_chofer_search.Location = new System.Drawing.Point(105, 244);
            this.bot_chofer_search.Margin = new System.Windows.Forms.Padding(2);
            this.bot_chofer_search.Name = "bot_chofer_search";
            this.bot_chofer_search.Size = new System.Drawing.Size(29, 19);
            this.bot_chofer_search.TabIndex = 28;
            this.bot_chofer_search.Text = "...";
            this.bot_chofer_search.UseVisualStyleBackColor = true;
            this.bot_chofer_search.Click += new System.EventHandler(this.Bot_chofer_search_Click);
            // 
            // txt_chofer_id
            // 
            this.txt_chofer_id.Location = new System.Drawing.Point(24, 245);
            this.txt_chofer_id.Margin = new System.Windows.Forms.Padding(2);
            this.txt_chofer_id.Name = "txt_chofer_id";
            this.txt_chofer_id.ReadOnly = true;
            this.txt_chofer_id.Size = new System.Drawing.Size(78, 20);
            this.txt_chofer_id.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 228);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Chofer Id.";
            // 
            // txt_chofer_name
            // 
            this.txt_chofer_name.Location = new System.Drawing.Point(139, 244);
            this.txt_chofer_name.Margin = new System.Windows.Forms.Padding(2);
            this.txt_chofer_name.Name = "txt_chofer_name";
            this.txt_chofer_name.ReadOnly = true;
            this.txt_chofer_name.Size = new System.Drawing.Size(192, 20);
            this.txt_chofer_name.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(136, 228);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Nombre del Chofer";
            // 
            // BOT_CAMION
            // 
            this.BOT_CAMION.Enabled = false;
            this.BOT_CAMION.Location = new System.Drawing.Point(416, 243);
            this.BOT_CAMION.Margin = new System.Windows.Forms.Padding(2);
            this.BOT_CAMION.Name = "BOT_CAMION";
            this.BOT_CAMION.Size = new System.Drawing.Size(29, 19);
            this.BOT_CAMION.TabIndex = 31;
            this.BOT_CAMION.Text = "...";
            this.BOT_CAMION.UseVisualStyleBackColor = true;
            this.BOT_CAMION.Click += new System.EventHandler(this.BOT_CAMION_Click);
            // 
            // txt_placas
            // 
            this.txt_placas.Location = new System.Drawing.Point(334, 244);
            this.txt_placas.Margin = new System.Windows.Forms.Padding(2);
            this.txt_placas.Name = "txt_placas";
            this.txt_placas.ReadOnly = true;
            this.txt_placas.Size = new System.Drawing.Size(78, 20);
            this.txt_placas.TabIndex = 30;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(332, 228);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "Placas ";
            // 
            // txt_camion
            // 
            this.txt_camion.Location = new System.Drawing.Point(449, 245);
            this.txt_camion.Margin = new System.Windows.Forms.Padding(2);
            this.txt_camion.Name = "txt_camion";
            this.txt_camion.ReadOnly = true;
            this.txt_camion.Size = new System.Drawing.Size(174, 20);
            this.txt_camion.TabIndex = 32;
            // 
            // grid_items
            // 
            this.grid_items.AllowUserToAddRows = false;
            this.grid_items.AllowUserToDeleteRows = false;
            this.grid_items.AllowUserToResizeRows = false;
            this.grid_items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_items.Enabled = false;
            this.grid_items.Location = new System.Drawing.Point(5, 5);
            this.grid_items.Margin = new System.Windows.Forms.Padding(2);
            this.grid_items.Name = "grid_items";
            this.grid_items.ReadOnly = true;
            this.grid_items.RowHeadersWidth = 25;
            this.grid_items.RowTemplate.Height = 24;
            this.grid_items.Size = new System.Drawing.Size(823, 196);
            this.grid_items.TabIndex = 33;
            this.grid_items.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_items_CellContentClick);
            this.grid_items.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_items_CellEndEdit);
            this.grid_items.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Grid_items_KeyUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.label20);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(923, 54);
            this.panel1.TabIndex = 34;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(325, 9);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(185, 31);
            this.label20.TabIndex = 0;
            this.label20.Text = "DESPACHOS";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BOT_PRIMERO,
            this.BOT_ANTERIOR,
            this.BOT_SIGUIENTE,
            this.BOT_ULTIMO,
            this.bot_nuevo,
            this.BOT_CANCELAR,
            this.BOT_SAVE,
            this.bot_modificar,
            this.BOT_BUSCAR,
            this.BOT_IMPRIMIR,
            this.bot_sincro});
            this.toolStrip1.Location = new System.Drawing.Point(0, 54);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(923, 27);
            this.toolStrip1.TabIndex = 35;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BOT_PRIMERO
            // 
            this.BOT_PRIMERO.Image = ((System.Drawing.Image)(resources.GetObject("BOT_PRIMERO.Image")));
            this.BOT_PRIMERO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_PRIMERO.Name = "BOT_PRIMERO";
            this.BOT_PRIMERO.Size = new System.Drawing.Size(73, 24);
            this.BOT_PRIMERO.Text = "Primero";
            this.BOT_PRIMERO.Click += new System.EventHandler(this.BOT_PRIMERO_Click);
            // 
            // BOT_ANTERIOR
            // 
            this.BOT_ANTERIOR.Image = ((System.Drawing.Image)(resources.GetObject("BOT_ANTERIOR.Image")));
            this.BOT_ANTERIOR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_ANTERIOR.Name = "BOT_ANTERIOR";
            this.BOT_ANTERIOR.Size = new System.Drawing.Size(74, 24);
            this.BOT_ANTERIOR.Text = "Anterior";
            this.BOT_ANTERIOR.Click += new System.EventHandler(this.BOT_ANTERIOR_Click);
            // 
            // BOT_SIGUIENTE
            // 
            this.BOT_SIGUIENTE.Image = ((System.Drawing.Image)(resources.GetObject("BOT_SIGUIENTE.Image")));
            this.BOT_SIGUIENTE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_SIGUIENTE.Name = "BOT_SIGUIENTE";
            this.BOT_SIGUIENTE.Size = new System.Drawing.Size(80, 24);
            this.BOT_SIGUIENTE.Text = "Siguiente";
            this.BOT_SIGUIENTE.Click += new System.EventHandler(this.BOT_SIGUIENTE_Click);
            // 
            // BOT_ULTIMO
            // 
            this.BOT_ULTIMO.Image = ((System.Drawing.Image)(resources.GetObject("BOT_ULTIMO.Image")));
            this.BOT_ULTIMO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_ULTIMO.Name = "BOT_ULTIMO";
            this.BOT_ULTIMO.Size = new System.Drawing.Size(67, 24);
            this.BOT_ULTIMO.Text = "Ultimo";
            this.BOT_ULTIMO.Click += new System.EventHandler(this.BOT_ULTIMO_Click);
            // 
            // bot_nuevo
            // 
            this.bot_nuevo.Image = ((System.Drawing.Image)(resources.GetObject("bot_nuevo.Image")));
            this.bot_nuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bot_nuevo.Name = "bot_nuevo";
            this.bot_nuevo.Size = new System.Drawing.Size(66, 24);
            this.bot_nuevo.Text = "Nuevo";
            this.bot_nuevo.Click += new System.EventHandler(this.Bot_nuevo_Click);
            // 
            // BOT_CANCELAR
            // 
            this.BOT_CANCELAR.Enabled = false;
            this.BOT_CANCELAR.Image = ((System.Drawing.Image)(resources.GetObject("BOT_CANCELAR.Image")));
            this.BOT_CANCELAR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_CANCELAR.Name = "BOT_CANCELAR";
            this.BOT_CANCELAR.Size = new System.Drawing.Size(77, 24);
            this.BOT_CANCELAR.Text = "Cancelar";
            this.BOT_CANCELAR.Click += new System.EventHandler(this.BOT_CANCELAR_Click);
            // 
            // BOT_SAVE
            // 
            this.BOT_SAVE.Enabled = false;
            this.BOT_SAVE.Image = ((System.Drawing.Image)(resources.GetObject("BOT_SAVE.Image")));
            this.BOT_SAVE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_SAVE.Name = "BOT_SAVE";
            this.BOT_SAVE.Size = new System.Drawing.Size(55, 24);
            this.BOT_SAVE.Text = "Save";
            this.BOT_SAVE.Click += new System.EventHandler(this.BOT_SAVE_Click);
            // 
            // bot_modificar
            // 
            this.bot_modificar.AutoSize = false;
            this.bot_modificar.Image = ((System.Drawing.Image)(resources.GetObject("bot_modificar.Image")));
            this.bot_modificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bot_modificar.Name = "bot_modificar";
            this.bot_modificar.Size = new System.Drawing.Size(80, 24);
            this.bot_modificar.Text = "Modif";
            this.bot_modificar.Click += new System.EventHandler(this.Bot_modificar_Click);
            // 
            // BOT_BUSCAR
            // 
            this.BOT_BUSCAR.Image = ((System.Drawing.Image)(resources.GetObject("BOT_BUSCAR.Image")));
            this.BOT_BUSCAR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_BUSCAR.Name = "BOT_BUSCAR";
            this.BOT_BUSCAR.Size = new System.Drawing.Size(66, 24);
            this.BOT_BUSCAR.Text = "Buscar";
            // 
            // BOT_IMPRIMIR
            // 
            this.BOT_IMPRIMIR.Image = ((System.Drawing.Image)(resources.GetObject("BOT_IMPRIMIR.Image")));
            this.BOT_IMPRIMIR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_IMPRIMIR.Name = "BOT_IMPRIMIR";
            this.BOT_IMPRIMIR.Size = new System.Drawing.Size(77, 24);
            this.BOT_IMPRIMIR.Text = "Imprimir";
            this.BOT_IMPRIMIR.Click += new System.EventHandler(this.BOT_IMPRIMIR_Click);
            // 
            // bot_sincro
            // 
            this.bot_sincro.AutoSize = false;
            this.bot_sincro.Enabled = false;
            this.bot_sincro.Image = ((System.Drawing.Image)(resources.GetObject("bot_sincro.Image")));
            this.bot_sincro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bot_sincro.Name = "bot_sincro";
            this.bot_sincro.Size = new System.Drawing.Size(80, 24);
            this.bot_sincro.Text = "Sincro";
            this.bot_sincro.Click += new System.EventHandler(this.Bot_sincro_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(447, 228);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "Camion";
            // 
            // txt_tipo_embalaje
            // 
            this.txt_tipo_embalaje.Location = new System.Drawing.Point(24, 531);
            this.txt_tipo_embalaje.Margin = new System.Windows.Forms.Padding(2);
            this.txt_tipo_embalaje.Name = "txt_tipo_embalaje";
            this.txt_tipo_embalaje.ReadOnly = true;
            this.txt_tipo_embalaje.Size = new System.Drawing.Size(209, 20);
            this.txt_tipo_embalaje.TabIndex = 38;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(22, 514);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 13);
            this.label14.TabIndex = 37;
            this.label14.Text = "Tipo de Embalaje";
            // 
            // txt_otrabajo
            // 
            this.txt_otrabajo.Location = new System.Drawing.Point(24, 574);
            this.txt_otrabajo.Margin = new System.Windows.Forms.Padding(2);
            this.txt_otrabajo.Name = "txt_otrabajo";
            this.txt_otrabajo.ReadOnly = true;
            this.txt_otrabajo.Size = new System.Drawing.Size(90, 20);
            this.txt_otrabajo.TabIndex = 40;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(22, 558);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(90, 13);
            this.label15.TabIndex = 39;
            this.label15.Text = "Orden de Trabajo";
            // 
            // txt_ocompra
            // 
            this.txt_ocompra.Location = new System.Drawing.Point(117, 574);
            this.txt_ocompra.Margin = new System.Windows.Forms.Padding(2);
            this.txt_ocompra.Name = "txt_ocompra";
            this.txt_ocompra.ReadOnly = true;
            this.txt_ocompra.Size = new System.Drawing.Size(116, 20);
            this.txt_ocompra.TabIndex = 42;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(115, 558);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 13);
            this.label16.TabIndex = 41;
            this.label16.Text = "Orden Compra";
            // 
            // txt_subtotal
            // 
            this.txt_subtotal.Location = new System.Drawing.Point(668, 514);
            this.txt_subtotal.Margin = new System.Windows.Forms.Padding(2);
            this.txt_subtotal.Name = "txt_subtotal";
            this.txt_subtotal.ReadOnly = true;
            this.txt_subtotal.Size = new System.Drawing.Size(182, 20);
            this.txt_subtotal.TabIndex = 44;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(599, 514);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 13);
            this.label17.TabIndex = 43;
            this.label17.Text = "Sub-Total";
            // 
            // txt_monto_itbis
            // 
            this.txt_monto_itbis.Location = new System.Drawing.Point(668, 536);
            this.txt_monto_itbis.Margin = new System.Windows.Forms.Padding(2);
            this.txt_monto_itbis.Name = "txt_monto_itbis";
            this.txt_monto_itbis.ReadOnly = true;
            this.txt_monto_itbis.Size = new System.Drawing.Size(182, 20);
            this.txt_monto_itbis.TabIndex = 46;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(564, 539);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(31, 13);
            this.label18.TabIndex = 45;
            this.label18.Text = "Itbis";
            // 
            // txt_total_despacho
            // 
            this.txt_total_despacho.Location = new System.Drawing.Point(668, 559);
            this.txt_total_despacho.Margin = new System.Windows.Forms.Padding(2);
            this.txt_total_despacho.Name = "txt_total_despacho";
            this.txt_total_despacho.ReadOnly = true;
            this.txt_total_despacho.Size = new System.Drawing.Size(182, 20);
            this.txt_total_despacho.TabIndex = 48;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(622, 562);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(44, 13);
            this.label19.TabIndex = 47;
            this.label19.Text = "Total :";
            // 
            // txt_porc_itbis
            // 
            this.txt_porc_itbis.Location = new System.Drawing.Point(602, 536);
            this.txt_porc_itbis.Margin = new System.Windows.Forms.Padding(2);
            this.txt_porc_itbis.Name = "txt_porc_itbis";
            this.txt_porc_itbis.ReadOnly = true;
            this.txt_porc_itbis.Size = new System.Drawing.Size(57, 20);
            this.txt_porc_itbis.TabIndex = 49;
            // 
            // bot_buscar_clientes
            // 
            this.bot_buscar_clientes.Enabled = false;
            this.bot_buscar_clientes.Location = new System.Drawing.Point(317, 105);
            this.bot_buscar_clientes.Margin = new System.Windows.Forms.Padding(2);
            this.bot_buscar_clientes.Name = "bot_buscar_clientes";
            this.bot_buscar_clientes.Size = new System.Drawing.Size(29, 19);
            this.bot_buscar_clientes.TabIndex = 52;
            this.bot_buscar_clientes.Text = "...";
            this.bot_buscar_clientes.UseVisualStyleBackColor = true;
            this.bot_buscar_clientes.Click += new System.EventHandler(this.Bot_buscar_clientes_Click);
            // 
            // bot_agregar_renglon
            // 
            this.bot_agregar_renglon.Enabled = false;
            this.bot_agregar_renglon.Location = new System.Drawing.Point(850, 292);
            this.bot_agregar_renglon.Name = "bot_agregar_renglon";
            this.bot_agregar_renglon.Size = new System.Drawing.Size(66, 23);
            this.bot_agregar_renglon.TabIndex = 53;
            this.bot_agregar_renglon.Text = "Agregar";
            this.bot_agregar_renglon.UseVisualStyleBackColor = true;
            this.bot_agregar_renglon.Click += new System.EventHandler(this.Agregar_renglon_Click);
            // 
            // bot_eliminar_renglon
            // 
            this.bot_eliminar_renglon.Enabled = false;
            this.bot_eliminar_renglon.Location = new System.Drawing.Point(850, 321);
            this.bot_eliminar_renglon.Name = "bot_eliminar_renglon";
            this.bot_eliminar_renglon.Size = new System.Drawing.Size(66, 23);
            this.bot_eliminar_renglon.TabIndex = 54;
            this.bot_eliminar_renglon.Text = "Eliminar";
            this.bot_eliminar_renglon.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 270);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(838, 231);
            this.tabControl1.TabIndex = 55;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grid_items);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(830, 205);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Renglones";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grid_UniqueCode);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(830, 205);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detalle RC";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grid_UniqueCode
            // 
            this.grid_UniqueCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_UniqueCode.Location = new System.Drawing.Point(6, 6);
            this.grid_UniqueCode.Name = "grid_UniqueCode";
            this.grid_UniqueCode.Size = new System.Drawing.Size(679, 193);
            this.grid_UniqueCode.TabIndex = 0;
            // 
            // BOT_DESPACHOS_RC
            // 
            this.BOT_DESPACHOS_RC.Enabled = false;
            this.BOT_DESPACHOS_RC.Location = new System.Drawing.Point(851, 350);
            this.BOT_DESPACHOS_RC.Name = "BOT_DESPACHOS_RC";
            this.BOT_DESPACHOS_RC.Size = new System.Drawing.Size(66, 23);
            this.BOT_DESPACHOS_RC.TabIndex = 56;
            this.BOT_DESPACHOS_RC.Text = "Desp. RC";
            this.BOT_DESPACHOS_RC.UseVisualStyleBackColor = true;
            // 
            // BOT_DETALLE_RC
            // 
            this.BOT_DETALLE_RC.Location = new System.Drawing.Point(850, 379);
            this.BOT_DETALLE_RC.Name = "BOT_DETALLE_RC";
            this.BOT_DETALLE_RC.Size = new System.Drawing.Size(66, 23);
            this.BOT_DETALLE_RC.TabIndex = 57;
            this.BOT_DETALLE_RC.Text = "Detalle RC";
            this.BOT_DETALLE_RC.UseVisualStyleBackColor = true;
            // 
            // FrmDespacho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(923, 614);
            this.Controls.Add(this.BOT_DETALLE_RC);
            this.Controls.Add(this.BOT_DESPACHOS_RC);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.bot_eliminar_renglon);
            this.Controls.Add(this.bot_agregar_renglon);
            this.Controls.Add(this.bot_buscar_clientes);
            this.Controls.Add(this.txt_porc_itbis);
            this.Controls.Add(this.txt_total_despacho);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txt_monto_itbis);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txt_subtotal);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txt_ocompra);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txt_otrabajo);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txt_tipo_embalaje);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_camion);
            this.Controls.Add(this.BOT_CAMION);
            this.Controls.Add(this.txt_placas);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.bot_chofer_search);
            this.Controls.Add(this.txt_chofer_id);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_chofer_name);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.bot_transport_search);
            this.Controls.Add(this.txt_transport_id);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_transport_name);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_vendor_name);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.bot_vendor_search);
            this.Controls.Add(this.txt_vendor_id);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_contact_person);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_customer_direc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_customer_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_customer_id);
            this.Controls.Add(this.CustomerIDLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_fecha_despacho);
            this.Controls.Add(this.txt_numero_despacho);
            this.Controls.Add(this.NumeroDespachoLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmDespacho";
            this.Text = "FrmDespacho";
            this.Load += new System.EventHandler(this.FrmDespacho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_items)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_UniqueCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NumeroDespachoLabel;
        private System.Windows.Forms.TextBox txt_numero_despacho;
        private System.Windows.Forms.DateTimePicker txt_fecha_despacho;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_customer_id;
        private System.Windows.Forms.Label CustomerIDLabel;
        private System.Windows.Forms.TextBox txt_customer_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_customer_direc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_contact_person;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_vendor_id;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bot_vendor_search;
        private System.Windows.Forms.TextBox txt_vendor_name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_transport_name;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button bot_transport_search;
        private System.Windows.Forms.TextBox txt_transport_id;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button bot_chofer_search;
        private System.Windows.Forms.TextBox txt_chofer_id;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_chofer_name;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button BOT_CAMION;
        private System.Windows.Forms.TextBox txt_placas;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_camion;
        private System.Windows.Forms.DataGridView grid_items;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ToolStripButton BOT_IMPRIMIR;
        private System.Windows.Forms.TextBox txt_tipo_embalaje;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt_otrabajo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_ocompra;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_subtotal;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txt_monto_itbis;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txt_total_despacho;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txt_porc_itbis;
        private System.Windows.Forms.ToolStripButton BOT_PRIMERO;
        private System.Windows.Forms.ToolStripButton BOT_ANTERIOR;
        private System.Windows.Forms.ToolStripButton BOT_SIGUIENTE;
        private System.Windows.Forms.ToolStripButton BOT_ULTIMO;
        private System.Windows.Forms.ToolStripButton bot_nuevo;
        private System.Windows.Forms.ToolStripButton BOT_CANCELAR;
        private System.Windows.Forms.ToolStripButton BOT_SAVE;
        private System.Windows.Forms.ToolStripButton bot_modificar;
        private System.Windows.Forms.ToolStripButton BOT_BUSCAR;
        private System.Windows.Forms.ToolStripButton bot_sincro;
        private System.Windows.Forms.Button bot_buscar_clientes;
        private System.Windows.Forms.Button bot_agregar_renglon;
        private System.Windows.Forms.Button bot_eliminar_renglon;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView grid_UniqueCode;
        private System.Windows.Forms.Button BOT_DESPACHOS_RC;
        private System.Windows.Forms.Button BOT_DETALLE_RC;
    }
}