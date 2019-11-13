namespace RitramaAPP
{
    partial class FrmOrdenCorte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOrdenCorte));
            this.txt_numero_oc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contador = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bot_primero = new System.Windows.Forms.ToolStripButton();
            this.bot_anterior = new System.Windows.Forms.ToolStripButton();
            this.bot_siguiente = new System.Windows.Forms.ToolStripButton();
            this.bot_ultimo = new System.Windows.Forms.ToolStripButton();
            this.BOT_NUEVO = new System.Windows.Forms.ToolStripButton();
            this.BOT_CANCELAR = new System.Windows.Forms.ToolStripButton();
            this.BOT_SAVE = new System.Windows.Forms.ToolStripButton();
            this.bot_modificar = new System.Windows.Forms.ToolStripButton();
            this.BOT_BUSCAR = new System.Windows.Forms.ToolStripButton();
            this.BOT_EXCEL_EXPORT = new System.Windows.Forms.ToolStripButton();
            this.txt_fecha_orden = new System.Windows.Forms.DateTimePicker();
            this.grid_rollos = new System.Windows.Forms.DataGridView();
            this.txt_fecha_producc = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_rollid_1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_width1_rollid = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_lenght1_rollid = new System.Windows.Forms.TextBox();
            this.txt_lenght2_rollid = new System.Windows.Forms.TextBox();
            this.txt_width2_rollid = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_rollid_2 = new System.Windows.Forms.TextBox();
            this.bot_buscar_rollid1 = new System.Windows.Forms.Button();
            this.bot_buscar_rollid2 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_product_id = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_product_name = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_cant_cortado = new System.Windows.Forms.TextBox();
            this.txt_width_cortado = new System.Windows.Forms.TextBox();
            this.txt_lenght_cortado = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_msi_cortado = new System.Windows.Forms.TextBox();
            this.bot_generar_rollos_cortados = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chk_process = new System.Windows.Forms.CheckBox();
            this.btn_eliminar_renglon = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_rollos)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_numero_oc
            // 
            this.txt_numero_oc.Location = new System.Drawing.Point(9, 119);
            this.txt_numero_oc.Margin = new System.Windows.Forms.Padding(2);
            this.txt_numero_oc.Name = "txt_numero_oc";
            this.txt_numero_oc.ReadOnly = true;
            this.txt_numero_oc.Size = new System.Drawing.Size(114, 20);
            this.txt_numero_oc.TabIndex = 0;
            this.txt_numero_oc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_numero_oc_KeyPress);
            this.txt_numero_oc.Validating += new System.ComponentModel.CancelEventHandler(this.Txt_numero_oc_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 101);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Numero OC:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 101);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha OC:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(214, 19);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(216, 25);
            this.label15.TabIndex = 0;
            this.label15.Text = "ORDENES DE CORTE";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.contador);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(833, 65);
            this.panel1.TabIndex = 35;
            // 
            // contador
            // 
            this.contador.AutoSize = true;
            this.contador.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contador.Location = new System.Drawing.Point(533, 31);
            this.contador.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.contador.Name = "contador";
            this.contador.Size = new System.Drawing.Size(81, 13);
            this.contador.TabIndex = 53;
            this.contador.Text = "Documentos:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bot_primero,
            this.bot_anterior,
            this.bot_siguiente,
            this.bot_ultimo,
            this.BOT_NUEVO,
            this.BOT_CANCELAR,
            this.BOT_SAVE,
            this.bot_modificar,
            this.BOT_BUSCAR,
            this.BOT_EXCEL_EXPORT});
            this.toolStrip1.Location = new System.Drawing.Point(0, 65);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(833, 27);
            this.toolStrip1.TabIndex = 45;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bot_primero
            // 
            this.bot_primero.AutoSize = false;
            this.bot_primero.Image = ((System.Drawing.Image)(resources.GetObject("bot_primero.Image")));
            this.bot_primero.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bot_primero.Name = "bot_primero";
            this.bot_primero.Size = new System.Drawing.Size(80, 24);
            this.bot_primero.Text = "Primero";
            this.bot_primero.Click += new System.EventHandler(this.Bot_primero_Click);
            // 
            // bot_anterior
            // 
            this.bot_anterior.AutoSize = false;
            this.bot_anterior.Image = ((System.Drawing.Image)(resources.GetObject("bot_anterior.Image")));
            this.bot_anterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bot_anterior.Name = "bot_anterior";
            this.bot_anterior.Size = new System.Drawing.Size(80, 24);
            this.bot_anterior.Text = "Anterior";
            this.bot_anterior.Click += new System.EventHandler(this.Bot_anterior_Click);
            // 
            // bot_siguiente
            // 
            this.bot_siguiente.AutoSize = false;
            this.bot_siguiente.Image = ((System.Drawing.Image)(resources.GetObject("bot_siguiente.Image")));
            this.bot_siguiente.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bot_siguiente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bot_siguiente.Name = "bot_siguiente";
            this.bot_siguiente.Size = new System.Drawing.Size(80, 24);
            this.bot_siguiente.Text = "Siguien";
            this.bot_siguiente.Click += new System.EventHandler(this.Bot_siguiente_Click);
            // 
            // bot_ultimo
            // 
            this.bot_ultimo.Image = ((System.Drawing.Image)(resources.GetObject("bot_ultimo.Image")));
            this.bot_ultimo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bot_ultimo.Name = "bot_ultimo";
            this.bot_ultimo.Size = new System.Drawing.Size(67, 24);
            this.bot_ultimo.Text = "Ultimo";
            this.bot_ultimo.Click += new System.EventHandler(this.Bot_ultimo_Click);
            // 
            // BOT_NUEVO
            // 
            this.BOT_NUEVO.Image = ((System.Drawing.Image)(resources.GetObject("BOT_NUEVO.Image")));
            this.BOT_NUEVO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_NUEVO.Name = "BOT_NUEVO";
            this.BOT_NUEVO.Size = new System.Drawing.Size(66, 24);
            this.BOT_NUEVO.Text = "Nuevo";
            this.BOT_NUEVO.Click += new System.EventHandler(this.BOT_NUEVO_Click);
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
            this.BOT_BUSCAR.Click += new System.EventHandler(this.BOT_BUSCAR_Click);
            // 
            // BOT_EXCEL_EXPORT
            // 
            this.BOT_EXCEL_EXPORT.Image = ((System.Drawing.Image)(resources.GetObject("BOT_EXCEL_EXPORT.Image")));
            this.BOT_EXCEL_EXPORT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_EXCEL_EXPORT.Name = "BOT_EXCEL_EXPORT";
            this.BOT_EXCEL_EXPORT.Size = new System.Drawing.Size(78, 24);
            this.BOT_EXCEL_EXPORT.Text = "Etiquetar";
            this.BOT_EXCEL_EXPORT.Click += new System.EventHandler(this.BOT_EXCEL_EXPORT_Click);
            // 
            // txt_fecha_orden
            // 
            this.txt_fecha_orden.Enabled = false;
            this.txt_fecha_orden.Location = new System.Drawing.Point(127, 120);
            this.txt_fecha_orden.Margin = new System.Windows.Forms.Padding(2);
            this.txt_fecha_orden.Name = "txt_fecha_orden";
            this.txt_fecha_orden.Size = new System.Drawing.Size(205, 20);
            this.txt_fecha_orden.TabIndex = 1;
            // 
            // grid_rollos
            // 
            this.grid_rollos.AllowUserToAddRows = false;
            this.grid_rollos.AllowUserToDeleteRows = false;
            this.grid_rollos.AllowUserToResizeRows = false;
            this.grid_rollos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grid_rollos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_rollos.Location = new System.Drawing.Point(9, 346);
            this.grid_rollos.Margin = new System.Windows.Forms.Padding(2);
            this.grid_rollos.MultiSelect = false;
            this.grid_rollos.Name = "grid_rollos";
            this.grid_rollos.RowHeadersWidth = 25;
            this.grid_rollos.RowTemplate.Height = 24;
            this.grid_rollos.Size = new System.Drawing.Size(814, 281);
            this.grid_rollos.TabIndex = 17;
            this.grid_rollos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_rollos_CellEndEdit);
            // 
            // txt_fecha_producc
            // 
            this.txt_fecha_producc.Enabled = false;
            this.txt_fecha_producc.Location = new System.Drawing.Point(336, 120);
            this.txt_fecha_producc.Margin = new System.Windows.Forms.Padding(2);
            this.txt_fecha_producc.Name = "txt_fecha_producc";
            this.txt_fecha_producc.Size = new System.Drawing.Size(205, 20);
            this.txt_fecha_producc.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 104);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Fecha Producion:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 149);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 61;
            this.label4.Text = "Roll Id 1:";
            // 
            // txt_rollid_1
            // 
            this.txt_rollid_1.Location = new System.Drawing.Point(9, 168);
            this.txt_rollid_1.Margin = new System.Windows.Forms.Padding(2);
            this.txt_rollid_1.Name = "txt_rollid_1";
            this.txt_rollid_1.ReadOnly = true;
            this.txt_rollid_1.Size = new System.Drawing.Size(128, 20);
            this.txt_rollid_1.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 146);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 63;
            this.label5.Text = "Width [INCH] :";
            // 
            // txt_width1_rollid
            // 
            this.txt_width1_rollid.Location = new System.Drawing.Point(189, 165);
            this.txt_width1_rollid.Margin = new System.Windows.Forms.Padding(2);
            this.txt_width1_rollid.Name = "txt_width1_rollid";
            this.txt_width1_rollid.ReadOnly = true;
            this.txt_width1_rollid.Size = new System.Drawing.Size(104, 20);
            this.txt_width1_rollid.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(297, 146);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 65;
            this.label7.Text = "Lenght [PIES]";
            // 
            // txt_lenght1_rollid
            // 
            this.txt_lenght1_rollid.Location = new System.Drawing.Point(297, 165);
            this.txt_lenght1_rollid.Margin = new System.Windows.Forms.Padding(2);
            this.txt_lenght1_rollid.Name = "txt_lenght1_rollid";
            this.txt_lenght1_rollid.ReadOnly = true;
            this.txt_lenght1_rollid.Size = new System.Drawing.Size(104, 20);
            this.txt_lenght1_rollid.TabIndex = 5;
            // 
            // txt_lenght2_rollid
            // 
            this.txt_lenght2_rollid.Location = new System.Drawing.Point(297, 211);
            this.txt_lenght2_rollid.Margin = new System.Windows.Forms.Padding(2);
            this.txt_lenght2_rollid.Name = "txt_lenght2_rollid";
            this.txt_lenght2_rollid.ReadOnly = true;
            this.txt_lenght2_rollid.Size = new System.Drawing.Size(104, 20);
            this.txt_lenght2_rollid.TabIndex = 8;
            // 
            // txt_width2_rollid
            // 
            this.txt_width2_rollid.Location = new System.Drawing.Point(189, 211);
            this.txt_width2_rollid.Margin = new System.Windows.Forms.Padding(2);
            this.txt_width2_rollid.Name = "txt_width2_rollid";
            this.txt_width2_rollid.ReadOnly = true;
            this.txt_width2_rollid.Size = new System.Drawing.Size(104, 20);
            this.txt_width2_rollid.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 195);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 67;
            this.label10.Text = "Roll Id 2:";
            // 
            // txt_rollid_2
            // 
            this.txt_rollid_2.Location = new System.Drawing.Point(9, 214);
            this.txt_rollid_2.Margin = new System.Windows.Forms.Padding(2);
            this.txt_rollid_2.Name = "txt_rollid_2";
            this.txt_rollid_2.ReadOnly = true;
            this.txt_rollid_2.Size = new System.Drawing.Size(128, 20);
            this.txt_rollid_2.TabIndex = 6;
            // 
            // bot_buscar_rollid1
            // 
            this.bot_buscar_rollid1.Enabled = false;
            this.bot_buscar_rollid1.Location = new System.Drawing.Point(149, 165);
            this.bot_buscar_rollid1.Name = "bot_buscar_rollid1";
            this.bot_buscar_rollid1.Size = new System.Drawing.Size(35, 23);
            this.bot_buscar_rollid1.TabIndex = 72;
            this.bot_buscar_rollid1.Text = "...";
            this.bot_buscar_rollid1.UseVisualStyleBackColor = true;
            this.bot_buscar_rollid1.Click += new System.EventHandler(this.Bot_buscar_rollid1_Click);
            // 
            // bot_buscar_rollid2
            // 
            this.bot_buscar_rollid2.Enabled = false;
            this.bot_buscar_rollid2.Location = new System.Drawing.Point(149, 211);
            this.bot_buscar_rollid2.Name = "bot_buscar_rollid2";
            this.bot_buscar_rollid2.Size = new System.Drawing.Size(35, 23);
            this.bot_buscar_rollid2.TabIndex = 73;
            this.bot_buscar_rollid2.Text = "...";
            this.bot_buscar_rollid2.UseVisualStyleBackColor = true;
            this.bot_buscar_rollid2.Click += new System.EventHandler(this.Bot_buscar_rollid2_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 241);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 75;
            this.label11.Text = "Product Id. :";
            // 
            // txt_product_id
            // 
            this.txt_product_id.Location = new System.Drawing.Point(11, 260);
            this.txt_product_id.Margin = new System.Windows.Forms.Padding(2);
            this.txt_product_id.Name = "txt_product_id";
            this.txt_product_id.ReadOnly = true;
            this.txt_product_id.Size = new System.Drawing.Size(128, 20);
            this.txt_product_id.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(149, 241);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 13);
            this.label12.TabIndex = 77;
            this.label12.Text = "Product Name:";
            // 
            // txt_product_name
            // 
            this.txt_product_name.Location = new System.Drawing.Point(149, 260);
            this.txt_product_name.Margin = new System.Windows.Forms.Padding(2);
            this.txt_product_name.Name = "txt_product_name";
            this.txt_product_name.ReadOnly = true;
            this.txt_product_name.Size = new System.Drawing.Size(405, 20);
            this.txt_product_name.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 287);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 79;
            this.label6.Text = "Cantidad a Producir  :";
            // 
            // txt_cant_cortado
            // 
            this.txt_cant_cortado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cant_cortado.Location = new System.Drawing.Point(14, 306);
            this.txt_cant_cortado.Margin = new System.Windows.Forms.Padding(2);
            this.txt_cant_cortado.Name = "txt_cant_cortado";
            this.txt_cant_cortado.ReadOnly = true;
            this.txt_cant_cortado.Size = new System.Drawing.Size(128, 20);
            this.txt_cant_cortado.TabIndex = 12;
            this.txt_cant_cortado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_cant_cortado_KeyPress);
            this.txt_cant_cortado.Validating += new System.ComponentModel.CancelEventHandler(this.Txt_cant_cortado_Validating);
            // 
            // txt_width_cortado
            // 
            this.txt_width_cortado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_width_cortado.Location = new System.Drawing.Point(152, 306);
            this.txt_width_cortado.Margin = new System.Windows.Forms.Padding(2);
            this.txt_width_cortado.Name = "txt_width_cortado";
            this.txt_width_cortado.ReadOnly = true;
            this.txt_width_cortado.Size = new System.Drawing.Size(128, 20);
            this.txt_width_cortado.TabIndex = 13;
            this.txt_width_cortado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_width_cortado_KeyPress);
            this.txt_width_cortado.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Txt_width_cortado_KeyUp);
            // 
            // txt_lenght_cortado
            // 
            this.txt_lenght_cortado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_lenght_cortado.Location = new System.Drawing.Point(284, 306);
            this.txt_lenght_cortado.Margin = new System.Windows.Forms.Padding(2);
            this.txt_lenght_cortado.Name = "txt_lenght_cortado";
            this.txt_lenght_cortado.ReadOnly = true;
            this.txt_lenght_cortado.Size = new System.Drawing.Size(128, 20);
            this.txt_lenght_cortado.TabIndex = 14;
            this.txt_lenght_cortado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_lenght_cortado_KeyPress);
            this.txt_lenght_cortado.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Txt_lenght_cortado_KeyUp);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(416, 287);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(32, 13);
            this.label16.TabIndex = 85;
            this.label16.Text = "MSI :";
            // 
            // txt_msi_cortado
            // 
            this.txt_msi_cortado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_msi_cortado.Location = new System.Drawing.Point(416, 306);
            this.txt_msi_cortado.Margin = new System.Windows.Forms.Padding(2);
            this.txt_msi_cortado.Name = "txt_msi_cortado";
            this.txt_msi_cortado.ReadOnly = true;
            this.txt_msi_cortado.Size = new System.Drawing.Size(138, 20);
            this.txt_msi_cortado.TabIndex = 15;
            // 
            // bot_generar_rollos_cortados
            // 
            this.bot_generar_rollos_cortados.Enabled = false;
            this.bot_generar_rollos_cortados.Location = new System.Drawing.Point(419, 165);
            this.bot_generar_rollos_cortados.Name = "bot_generar_rollos_cortados";
            this.bot_generar_rollos_cortados.Size = new System.Drawing.Size(135, 66);
            this.bot_generar_rollos_cortados.TabIndex = 9;
            this.bot_generar_rollos_cortados.Text = "Generar Rollos";
            this.bot_generar_rollos_cortados.UseVisualStyleBackColor = true;
            this.bot_generar_rollos_cortados.Click += new System.EventHandler(this.Bot_generar_rollos_cortados_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(654, 122);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(123, 17);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Documento Anulado";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // chk_process
            // 
            this.chk_process.AutoSize = true;
            this.chk_process.Enabled = false;
            this.chk_process.Location = new System.Drawing.Point(654, 142);
            this.chk_process.Name = "chk_process";
            this.chk_process.Size = new System.Drawing.Size(77, 17);
            this.chk_process.TabIndex = 88;
            this.chk_process.Text = "Procesado";
            this.chk_process.UseVisualStyleBackColor = true;
            // 
            // btn_eliminar_renglon
            // 
            this.btn_eliminar_renglon.Location = new System.Drawing.Point(735, 318);
            this.btn_eliminar_renglon.Name = "btn_eliminar_renglon";
            this.btn_eliminar_renglon.Size = new System.Drawing.Size(88, 23);
            this.btn_eliminar_renglon.TabIndex = 89;
            this.btn_eliminar_renglon.Text = "- Fila";
            this.btn_eliminar_renglon.UseVisualStyleBackColor = true;
            this.btn_eliminar_renglon.Click += new System.EventHandler(this.Btn_eliminar_renglon_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(189, 192);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 90;
            this.label8.Text = "Width [INCH] :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(297, 192);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 91;
            this.label9.Text = "Lenght [PIES]";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(151, 291);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 13);
            this.label13.TabIndex = 92;
            this.label13.Text = "Width [INCH] :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(281, 291);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 13);
            this.label14.TabIndex = 93;
            this.label14.Text = "Lenght [PIES]";
            // 
            // FrmOrdenCorte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(833, 673);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btn_eliminar_renglon);
            this.Controls.Add(this.chk_process);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.bot_generar_rollos_cortados);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txt_msi_cortado);
            this.Controls.Add(this.txt_lenght_cortado);
            this.Controls.Add(this.txt_width_cortado);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_cant_cortado);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txt_product_name);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_product_id);
            this.Controls.Add(this.bot_buscar_rollid2);
            this.Controls.Add(this.bot_buscar_rollid1);
            this.Controls.Add(this.txt_lenght2_rollid);
            this.Controls.Add(this.txt_width2_rollid);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_rollid_2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_lenght1_rollid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_width1_rollid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_rollid_1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_fecha_producc);
            this.Controls.Add(this.grid_rollos);
            this.Controls.Add(this.txt_fecha_orden);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_numero_oc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmOrdenCorte";
            this.Text = "FrmOrdenCorte";
            this.Load += new System.EventHandler(this.FrmOrdenCorte_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_rollos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_numero_oc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bot_primero;
        private System.Windows.Forms.ToolStripButton bot_anterior;
        private System.Windows.Forms.ToolStripButton bot_siguiente;
        private System.Windows.Forms.ToolStripButton BOT_EXCEL_EXPORT;
        private System.Windows.Forms.ToolStripButton bot_ultimo;
        private System.Windows.Forms.ToolStripButton BOT_NUEVO;
        private System.Windows.Forms.ToolStripButton BOT_CANCELAR;
        private System.Windows.Forms.ToolStripButton BOT_SAVE;
        private System.Windows.Forms.DateTimePicker txt_fecha_orden;
        private System.Windows.Forms.DataGridView grid_rollos;
        private System.Windows.Forms.Label contador;
        private System.Windows.Forms.ToolStripButton BOT_BUSCAR;
        private System.Windows.Forms.DateTimePicker txt_fecha_producc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_rollid_1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_width1_rollid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_lenght1_rollid;
        private System.Windows.Forms.TextBox txt_lenght2_rollid;
        private System.Windows.Forms.TextBox txt_width2_rollid;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_rollid_2;
        private System.Windows.Forms.Button bot_buscar_rollid1;
        private System.Windows.Forms.Button bot_buscar_rollid2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_product_id;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_product_name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_cant_cortado;
        private System.Windows.Forms.TextBox txt_width_cortado;
        private System.Windows.Forms.TextBox txt_lenght_cortado;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_msi_cortado;
        private System.Windows.Forms.Button bot_generar_rollos_cortados;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox chk_process;
        private System.Windows.Forms.ToolStripButton bot_modificar;
        private System.Windows.Forms.Button btn_eliminar_renglon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
    }
}