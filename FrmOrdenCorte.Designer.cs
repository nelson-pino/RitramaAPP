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
            this.grid_items = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contador = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_numero_pedido = new System.Windows.Forms.TextBox();
            this.BOT_BUSCAR_CUSTOMERS = new System.Windows.Forms.Button();
            this.txt_id_customer = new System.Windows.Forms.Label();
            this.txt_customer_id = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_customer_name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_roll_id = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bot_primero = new System.Windows.Forms.ToolStripButton();
            this.bot_anterior = new System.Windows.Forms.ToolStripButton();
            this.bot_siguiente = new System.Windows.Forms.ToolStripButton();
            this.bot_ultimo = new System.Windows.Forms.ToolStripButton();
            this.BOT_NUEVO = new System.Windows.Forms.ToolStripButton();
            this.BOT_CANCELAR = new System.Windows.Forms.ToolStripButton();
            this.BOT_SAVE = new System.Windows.Forms.ToolStripButton();
            this.BOT_BUSCAR = new System.Windows.Forms.ToolStripButton();
            this.BOT_EXCEL_EXPORT = new System.Windows.Forms.ToolStripButton();
            this.bot_search_pedido = new System.Windows.Forms.Button();
            this.txt_total_roll = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bot_add_items = new System.Windows.Forms.Button();
            this.bot_delete_items = new System.Windows.Forms.Button();
            this.txt_fecha_orden = new System.Windows.Forms.DateTimePicker();
            this.grid_rollos = new System.Windows.Forms.DataGridView();
            this.list_roll_id = new System.Windows.Forms.ListBox();
            this.BOT_ROLLID_ADD = new System.Windows.Forms.Button();
            this.bot_delete_roll_id = new System.Windows.Forms.Button();
            this.BOT_UPDATE_ROLLID = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid_items)).BeginInit();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_rollos)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_numero_oc
            // 
            this.txt_numero_oc.Location = new System.Drawing.Point(12, 151);
            this.txt_numero_oc.Name = "txt_numero_oc";
            this.txt_numero_oc.ReadOnly = true;
            this.txt_numero_oc.Size = new System.Drawing.Size(100, 22);
            this.txt_numero_oc.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Numero OC:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha OC:";
            // 
            // grid_items
            // 
            this.grid_items.AllowUserToAddRows = false;
            this.grid_items.AllowUserToDeleteRows = false;
            this.grid_items.AllowUserToResizeRows = false;
            this.grid_items.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grid_items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_items.Location = new System.Drawing.Point(12, 236);
            this.grid_items.Name = "grid_items";
            this.grid_items.ReadOnly = true;
            this.grid_items.RowHeadersWidth = 30;
            this.grid_items.RowTemplate.Height = 24;
            this.grid_items.Size = new System.Drawing.Size(783, 154);
            this.grid_items.TabIndex = 5;
            this.grid_items.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_items_CellClick);
            this.grid_items.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_items_CellContentClick);
            this.grid_items.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_items_CellEndEdit);
            this.grid_items.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Grid_items_KeyUp);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(285, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(273, 29);
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
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(867, 80);
            this.panel1.TabIndex = 35;
            // 
            // contador
            // 
            this.contador.AutoSize = true;
            this.contador.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contador.Location = new System.Drawing.Point(753, 47);
            this.contador.Name = "contador";
            this.contador.Size = new System.Drawing.Size(102, 17);
            this.contador.TabIndex = 53;
            this.contador.Text = "Documentos:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(393, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 37;
            this.label3.Text = "Pedido:";
            // 
            // txt_numero_pedido
            // 
            this.txt_numero_pedido.Location = new System.Drawing.Point(396, 151);
            this.txt_numero_pedido.Name = "txt_numero_pedido";
            this.txt_numero_pedido.ReadOnly = true;
            this.txt_numero_pedido.Size = new System.Drawing.Size(100, 22);
            this.txt_numero_pedido.TabIndex = 36;
            // 
            // BOT_BUSCAR_CUSTOMERS
            // 
            this.BOT_BUSCAR_CUSTOMERS.Location = new System.Drawing.Point(118, 203);
            this.BOT_BUSCAR_CUSTOMERS.Name = "BOT_BUSCAR_CUSTOMERS";
            this.BOT_BUSCAR_CUSTOMERS.Size = new System.Drawing.Size(37, 27);
            this.BOT_BUSCAR_CUSTOMERS.TabIndex = 38;
            this.BOT_BUSCAR_CUSTOMERS.Text = "...";
            this.BOT_BUSCAR_CUSTOMERS.UseVisualStyleBackColor = true;
            this.BOT_BUSCAR_CUSTOMERS.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txt_id_customer
            // 
            this.txt_id_customer.AutoSize = true;
            this.txt_id_customer.Location = new System.Drawing.Point(9, 188);
            this.txt_id_customer.Name = "txt_id_customer";
            this.txt_id_customer.Size = new System.Drawing.Size(87, 17);
            this.txt_id_customer.TabIndex = 40;
            this.txt_id_customer.Text = "Customer Id.";
            // 
            // txt_customer_id
            // 
            this.txt_customer_id.Location = new System.Drawing.Point(12, 208);
            this.txt_customer_id.Name = "txt_customer_id";
            this.txt_customer_id.ReadOnly = true;
            this.txt_customer_id.Size = new System.Drawing.Size(100, 22);
            this.txt_customer_id.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 17);
            this.label4.TabIndex = 42;
            this.label4.Text = "Customer Name:";
            // 
            // txt_customer_name
            // 
            this.txt_customer_name.Location = new System.Drawing.Point(161, 208);
            this.txt_customer_name.Name = "txt_customer_name";
            this.txt_customer_name.ReadOnly = true;
            this.txt_customer_name.Size = new System.Drawing.Size(381, 22);
            this.txt_customer_name.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(572, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 44;
            this.label5.Text = "ROLL ID.";
            // 
            // txt_roll_id
            // 
            this.txt_roll_id.Location = new System.Drawing.Point(652, 118);
            this.txt_roll_id.Name = "txt_roll_id";
            this.txt_roll_id.Size = new System.Drawing.Size(143, 22);
            this.txt_roll_id.TabIndex = 43;
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
            this.BOT_BUSCAR,
            this.BOT_EXCEL_EXPORT});
            this.toolStrip1.Location = new System.Drawing.Point(0, 80);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(867, 27);
            this.toolStrip1.TabIndex = 45;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolStrip1_ItemClicked);
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
            this.bot_ultimo.Size = new System.Drawing.Size(78, 24);
            this.bot_ultimo.Text = "Ultimo";
            this.bot_ultimo.Click += new System.EventHandler(this.Bot_ultimo_Click);
            // 
            // BOT_NUEVO
            // 
            this.BOT_NUEVO.Image = ((System.Drawing.Image)(resources.GetObject("BOT_NUEVO.Image")));
            this.BOT_NUEVO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_NUEVO.Name = "BOT_NUEVO";
            this.BOT_NUEVO.Size = new System.Drawing.Size(76, 24);
            this.BOT_NUEVO.Text = "Nuevo";
            this.BOT_NUEVO.Click += new System.EventHandler(this.BOT_NUEVO_Click);
            // 
            // BOT_CANCELAR
            // 
            this.BOT_CANCELAR.Image = ((System.Drawing.Image)(resources.GetObject("BOT_CANCELAR.Image")));
            this.BOT_CANCELAR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_CANCELAR.Name = "BOT_CANCELAR";
            this.BOT_CANCELAR.Size = new System.Drawing.Size(90, 24);
            this.BOT_CANCELAR.Text = "Cancelar";
            // 
            // BOT_SAVE
            // 
            this.BOT_SAVE.Image = ((System.Drawing.Image)(resources.GetObject("BOT_SAVE.Image")));
            this.BOT_SAVE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_SAVE.Name = "BOT_SAVE";
            this.BOT_SAVE.Size = new System.Drawing.Size(64, 24);
            this.BOT_SAVE.Text = "Save";
            this.BOT_SAVE.Click += new System.EventHandler(this.BOT_SAVE_Click);
            // 
            // BOT_BUSCAR
            // 
            this.BOT_BUSCAR.Image = ((System.Drawing.Image)(resources.GetObject("BOT_BUSCAR.Image")));
            this.BOT_BUSCAR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_BUSCAR.Name = "BOT_BUSCAR";
            this.BOT_BUSCAR.Size = new System.Drawing.Size(76, 24);
            this.BOT_BUSCAR.Text = "Buscar";
            this.BOT_BUSCAR.Click += new System.EventHandler(this.BOT_BUSCAR_Click);
            // 
            // BOT_EXCEL_EXPORT
            // 
            this.BOT_EXCEL_EXPORT.Image = ((System.Drawing.Image)(resources.GetObject("BOT_EXCEL_EXPORT.Image")));
            this.BOT_EXCEL_EXPORT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_EXCEL_EXPORT.Name = "BOT_EXCEL_EXPORT";
            this.BOT_EXCEL_EXPORT.Size = new System.Drawing.Size(67, 24);
            this.BOT_EXCEL_EXPORT.Text = "Excel";
            this.BOT_EXCEL_EXPORT.Click += new System.EventHandler(this.BOT_EXCEL_EXPORT_Click);
            // 
            // bot_search_pedido
            // 
            this.bot_search_pedido.Location = new System.Drawing.Point(502, 146);
            this.bot_search_pedido.Name = "bot_search_pedido";
            this.bot_search_pedido.Size = new System.Drawing.Size(40, 27);
            this.bot_search_pedido.TabIndex = 46;
            this.bot_search_pedido.Text = "...";
            this.bot_search_pedido.UseVisualStyleBackColor = true;
            // 
            // txt_total_roll
            // 
            this.txt_total_roll.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_total_roll.Location = new System.Drawing.Point(695, 396);
            this.txt_total_roll.Name = "txt_total_roll";
            this.txt_total_roll.ReadOnly = true;
            this.txt_total_roll.Size = new System.Drawing.Size(100, 22);
            this.txt_total_roll.TabIndex = 47;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(602, 399);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 17);
            this.label6.TabIndex = 48;
            this.label6.Text = "Total Rollos:";
            // 
            // bot_add_items
            // 
            this.bot_add_items.Image = ((System.Drawing.Image)(resources.GetObject("bot_add_items.Image")));
            this.bot_add_items.Location = new System.Drawing.Point(801, 236);
            this.bot_add_items.Name = "bot_add_items";
            this.bot_add_items.Size = new System.Drawing.Size(37, 23);
            this.bot_add_items.TabIndex = 49;
            this.bot_add_items.UseVisualStyleBackColor = true;
            this.bot_add_items.Click += new System.EventHandler(this.Bot_add_items_Click);
            // 
            // bot_delete_items
            // 
            this.bot_delete_items.Image = ((System.Drawing.Image)(resources.GetObject("bot_delete_items.Image")));
            this.bot_delete_items.Location = new System.Drawing.Point(801, 265);
            this.bot_delete_items.Name = "bot_delete_items";
            this.bot_delete_items.Size = new System.Drawing.Size(37, 23);
            this.bot_delete_items.TabIndex = 50;
            this.bot_delete_items.UseVisualStyleBackColor = true;
            // 
            // txt_fecha_orden
            // 
            this.txt_fecha_orden.Enabled = false;
            this.txt_fecha_orden.Location = new System.Drawing.Point(118, 151);
            this.txt_fecha_orden.Name = "txt_fecha_orden";
            this.txt_fecha_orden.Size = new System.Drawing.Size(272, 22);
            this.txt_fecha_orden.TabIndex = 51;
            // 
            // grid_rollos
            // 
            this.grid_rollos.AllowUserToAddRows = false;
            this.grid_rollos.AllowUserToDeleteRows = false;
            this.grid_rollos.AllowUserToResizeRows = false;
            this.grid_rollos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grid_rollos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_rollos.Location = new System.Drawing.Point(12, 426);
            this.grid_rollos.Name = "grid_rollos";
            this.grid_rollos.ReadOnly = true;
            this.grid_rollos.RowHeadersWidth = 30;
            this.grid_rollos.RowTemplate.Height = 24;
            this.grid_rollos.Size = new System.Drawing.Size(783, 196);
            this.grid_rollos.TabIndex = 52;
            // 
            // list_roll_id
            // 
            this.list_roll_id.FormattingEnabled = true;
            this.list_roll_id.ItemHeight = 16;
            this.list_roll_id.Location = new System.Drawing.Point(652, 146);
            this.list_roll_id.Name = "list_roll_id";
            this.list_roll_id.Size = new System.Drawing.Size(143, 84);
            this.list_roll_id.TabIndex = 54;
            // 
            // BOT_ROLLID_ADD
            // 
            this.BOT_ROLLID_ADD.Image = ((System.Drawing.Image)(resources.GetObject("BOT_ROLLID_ADD.Image")));
            this.BOT_ROLLID_ADD.Location = new System.Drawing.Point(801, 146);
            this.BOT_ROLLID_ADD.Name = "BOT_ROLLID_ADD";
            this.BOT_ROLLID_ADD.Size = new System.Drawing.Size(34, 26);
            this.BOT_ROLLID_ADD.TabIndex = 55;
            this.BOT_ROLLID_ADD.UseVisualStyleBackColor = true;
            this.BOT_ROLLID_ADD.Click += new System.EventHandler(this.BOT_ROLLID_ADD_Click);
            // 
            // bot_delete_roll_id
            // 
            this.bot_delete_roll_id.Image = ((System.Drawing.Image)(resources.GetObject("bot_delete_roll_id.Image")));
            this.bot_delete_roll_id.Location = new System.Drawing.Point(801, 175);
            this.bot_delete_roll_id.Name = "bot_delete_roll_id";
            this.bot_delete_roll_id.Size = new System.Drawing.Size(34, 26);
            this.bot_delete_roll_id.TabIndex = 56;
            this.bot_delete_roll_id.UseVisualStyleBackColor = true;
            this.bot_delete_roll_id.Click += new System.EventHandler(this.Bot_delete_roll_id_Click);
            // 
            // BOT_UPDATE_ROLLID
            // 
            this.BOT_UPDATE_ROLLID.Image = ((System.Drawing.Image)(resources.GetObject("BOT_UPDATE_ROLLID.Image")));
            this.BOT_UPDATE_ROLLID.Location = new System.Drawing.Point(804, 426);
            this.BOT_UPDATE_ROLLID.Name = "BOT_UPDATE_ROLLID";
            this.BOT_UPDATE_ROLLID.Size = new System.Drawing.Size(34, 26);
            this.BOT_UPDATE_ROLLID.TabIndex = 57;
            this.BOT_UPDATE_ROLLID.UseVisualStyleBackColor = true;
            this.BOT_UPDATE_ROLLID.Click += new System.EventHandler(this.BOT_UPDATE_ROLLID_Click);
            // 
            // FrmOrdenCorte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(867, 639);
            this.Controls.Add(this.BOT_UPDATE_ROLLID);
            this.Controls.Add(this.bot_delete_roll_id);
            this.Controls.Add(this.BOT_ROLLID_ADD);
            this.Controls.Add(this.list_roll_id);
            this.Controls.Add(this.grid_rollos);
            this.Controls.Add(this.txt_fecha_orden);
            this.Controls.Add(this.bot_delete_items);
            this.Controls.Add(this.bot_add_items);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_total_roll);
            this.Controls.Add(this.bot_search_pedido);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_roll_id);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_customer_name);
            this.Controls.Add(this.txt_id_customer);
            this.Controls.Add(this.txt_customer_id);
            this.Controls.Add(this.BOT_BUSCAR_CUSTOMERS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_numero_pedido);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grid_items);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_numero_oc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmOrdenCorte";
            this.Text = "FrmOrdenCorte";
            this.Load += new System.EventHandler(this.FrmOrdenCorte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_items)).EndInit();
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
        private System.Windows.Forms.DataGridView grid_items;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_numero_pedido;
        private System.Windows.Forms.Button BOT_BUSCAR_CUSTOMERS;
        private System.Windows.Forms.Label txt_id_customer;
        private System.Windows.Forms.TextBox txt_customer_id;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_customer_name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_roll_id;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bot_primero;
        private System.Windows.Forms.ToolStripButton bot_anterior;
        private System.Windows.Forms.ToolStripButton bot_siguiente;
        private System.Windows.Forms.ToolStripButton BOT_EXCEL_EXPORT;
        private System.Windows.Forms.Button bot_search_pedido;
        private System.Windows.Forms.TextBox txt_total_roll;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripButton bot_ultimo;
        private System.Windows.Forms.ToolStripButton BOT_NUEVO;
        private System.Windows.Forms.ToolStripButton BOT_CANCELAR;
        private System.Windows.Forms.ToolStripButton BOT_SAVE;
        private System.Windows.Forms.Button bot_add_items;
        private System.Windows.Forms.Button bot_delete_items;
        private System.Windows.Forms.DateTimePicker txt_fecha_orden;
        private System.Windows.Forms.DataGridView grid_rollos;
        private System.Windows.Forms.Label contador;
        private System.Windows.Forms.ToolStripButton BOT_BUSCAR;
        private System.Windows.Forms.ListBox list_roll_id;
        private System.Windows.Forms.Button BOT_ROLLID_ADD;
        private System.Windows.Forms.Button bot_delete_roll_id;
        private System.Windows.Forms.Button BOT_UPDATE_ROLLID;
    }
}