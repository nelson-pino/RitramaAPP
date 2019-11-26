namespace RitramaAPP.form
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
            this.GRID_IMPORT = new System.Windows.Forms.DataGridView();
            this.bot_import_data = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TXT_PATH = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.GRID_IMPORT)).BeginInit();
            this.SuspendLayout();
            // 
            // GRID_IMPORT
            // 
            this.GRID_IMPORT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GRID_IMPORT.Location = new System.Drawing.Point(12, 41);
            this.GRID_IMPORT.Name = "GRID_IMPORT";
            this.GRID_IMPORT.Size = new System.Drawing.Size(776, 397);
            this.GRID_IMPORT.TabIndex = 0;
            // 
            // bot_import_data
            // 
            this.bot_import_data.Location = new System.Drawing.Point(12, 12);
            this.bot_import_data.Name = "bot_import_data";
            this.bot_import_data.Size = new System.Drawing.Size(124, 23);
            this.bot_import_data.TabIndex = 1;
            this.bot_import_data.Text = "Importar";
            this.bot_import_data.UseVisualStyleBackColor = true;
            this.bot_import_data.Click += new System.EventHandler(this.bot_import_data_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre de la Hoja:";
            // 
            // TXT_PATH
            // 
            this.TXT_PATH.Location = new System.Drawing.Point(246, 14);
            this.TXT_PATH.Name = "TXT_PATH";
            this.TXT_PATH.Size = new System.Drawing.Size(220, 20);
            this.TXT_PATH.TabIndex = 3;
            // 
            // FrmImportExcelMP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TXT_PATH);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bot_import_data);
            this.Controls.Add(this.GRID_IMPORT);
            this.Name = "FrmImportExcelMP";
            this.Text = "Importar data de recepciones de materia prima desde hoja de excel";
            this.Load += new System.EventHandler(this.FrmImportExcelMP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GRID_IMPORT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GRID_IMPORT;
        private System.Windows.Forms.Button bot_import_data;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TXT_PATH;
    }
}