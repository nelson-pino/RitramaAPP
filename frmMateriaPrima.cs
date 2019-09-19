using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RitramaAPP.Clases;
using RitramaAPP.form;

namespace RitramaAPP
{
    public partial class FrmMateriaPrima : Form
    {
        public FrmMateriaPrima()
        {
            InitializeComponent();
        }
        const Double FACTOR_METROS_PULDADAS = 39.3701;
        const Double FACTOR_METROS_PIES = 3.28084;
        readonly RecepcionManager manager = new RecepcionManager();
        readonly BindingSource bs = new BindingSource();
        DataSet ds = new DataSet();
        int EditMode = 0;
        public RecepcionManager Manager => manager;
        private void FrmMateriaPrima_Load(object sender, EventArgs e)
        {
            ds = Manager.ds;
            bs.DataSource = ds;
            bs.DataMember = "dtrecepcion";
            txt_orden.DataBindings.Add("text",bs, "OrderPurchase");
            txt_part_number.DataBindings.Add("text",bs, "Part_Number");
            txt_width.DataBindings.Add("text", bs, "Width");
            txt_lenght.DataBindings.Add("text",bs, "Lenght");
            txt_roll_id.DataBindings.Add("text",bs, "Roll_Id");
            txt_id_supply.DataBindings.Add("text", bs, "Proveedor_Id");
            txt_ubic.DataBindings.Add("text", bs, "Ubicacion");
            txt_splice.DataBindings.Add("text", bs, "Splice");
            txt_core.DataBindings.Add("text",bs,"Core");
            txt_fecha_reg.DataBindings.Add("text", bs, "fecha_reg");
            txt_hora_reg.DataBindings.Add("text",bs,"hora_reg");
            txt_supply_name.DataBindings.Add("text",bs, "suplidor_des");
            txt_product_name.DataBindings.Add("text",bs,"product_name");
            txt_fecha_produccion.DataBindings.Add("text", bs, "fecha_pro");
            rad_masterRolls.DataBindings.Add("checked", bs, "master");
            rad_resmas.DataBindings.Add("checked", bs, "resma");
            rad_graphics.DataBindings.Add("checked",bs, "graphics");
            txt_num_embarque.DataBindings.Add("text", bs, "embarque");
            txt_numero_palet.DataBindings.Add("text", bs, "palet_num");
            txt_cant_palet.DataBindings.Add("text", bs, "palet_cant");
            txt_paginas.DataBindings.Add("text",bs,"palet_pag");
            CHK_ANULADO.DataBindings.Add("checked",bs,"anulado");
            ContadorRegistros();
        }
        private void Bot_sincro_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Esta seguro de sincronizar los datos desde colector de datos(S/N)?",
                     "Advertencia", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    TransferirDataMovil();

                    break;
                case DialogResult.No:
                    break;
            }
            ContadorRegistros();
        }
        private void TransferirDataMovil()
        {
            RecepcionManager manager = new RecepcionManager();
            List<ClassRecepcion> lista = new List<ClassRecepcion>();
            lista = manager.DownloadDataMateriaPrimaTxtMovil();

       



            //foreach (ClassRecepcion item in lista)
            //{
            //    DataRow dr = itemsincro.NewRow();
            //    dr["OrderPurchase"] = item.Orden;
            //    //dr["fecha_reg"] = item.fecha_reg;
            //    //dr["hora_reg"] = item.Hora_reg;
            //    dr["Part_Number"] = item.Part_Number;
            //    dr["Width"] = item.Width;
            //    dr["Lenght"] = item.Lenght;
            //    //dr["Proveedor_Id"] = item.Supply_Id;
            //    dr["Roll_Id"] = item.Roll_ID;
            //    //dr["Ubicacion"] = item.Ubicacion;
            //    //dr["Splice"] = item.Splice;
            //    //dr["Core"] = item.Core;
            //    itemsincro.Rows.Add(dr);
            //}
            frmSincroRecepciones sincro = new frmSincroRecepciones();
            sincro.lista = lista;
            sincro.dtsupply = ds.Tables["dtprovider"];
            sincro.ShowDialog();
        }
        private void Bot_siguiente_Click(object sender, EventArgs e)
        {
            bs.Position += 1;
            ContadorRegistros();
        }
        private void Bot_anterior_Click(object sender, EventArgs e)
        {
            bs.Position -= 1;
            ContadorRegistros();
        }
        private void Bot_primero_Click(object sender, EventArgs e)
        {
            bs.Position = 0;
            ContadorRegistros();
        }
        private void Bot_ultimo_Click(object sender, EventArgs e)
        {
            bs.Position = bs.Count - 1;
            ContadorRegistros();
        }
        private void ContadorRegistros()
        {
            LABEL_CONTADOR_REGISTRO.Text = (bs.Position + 1) + " de " + (bs.Count.ToString()) + " Registros";
        }

        private void Bot_nuevo_Click(object sender, EventArgs e)
        {
            OpcionesMenu(1);
            OpcionesForms(0);
            DataRow dr = ds.Tables["dtrecepcion"].NewRow();
            dr["fecha_reg"] = DateTime.Today;
            dr["hora_reg"] = DateTime.Now;
            dr["anulado"] = false;
            dr["core"] = 0;
            dr["splice"] = 0;
            dr["width"] = 0;
            dr["lenght"] = 0;
            dr["master"] = false;
            dr["resma"] = false;
            dr["graphics"] = false;
            dr["palet_num"] = "";
            dr["palet_cant"] = 0;
            dr["palet_pag"] = 0;
            ds.Tables["dtrecepcion"].Rows.Add(dr);
            bs.MoveLast();
            EditMode = 1;
            rad_resmas.Checked = false;
            rad_graphics.Checked = false;
            rad_masterRolls.Checked = false;
        }

        private void Bot_grabar_Click(object sender, EventArgs e)
        {
            if (EditMode == 1) GrabarNuevoRegistro();
            if (EditMode == 2) GrabarUpdateRegistro();
        }
        private void GrabarNuevoRegistro()
        {
            //Actualizo la Interfaz Grafica.
            DataRowView FilaActual;
            FilaActual = (DataRowView)bs.Current;
            FilaActual["OrderPurchase"] = txt_orden.Text;
            FilaActual["master"] = rad_masterRolls.Checked;
            FilaActual["resma"] = rad_resmas.Checked;
            FilaActual["Graphics"] = rad_graphics.Checked;
            FilaActual["palet_num"] = txt_numero_palet.Text;
            FilaActual["palet_cant"] = txt_cant_palet.Text;
            FilaActual["palet_PAG"] = txt_paginas.Text;
            bs.EndEdit();
            //Crear el Objeto producto.
            ClassRecepcion recepcion = new ClassRecepcion();
            RecepcionManager recepcionManager = new RecepcionManager();
            recepcion.Orden = txt_orden.Text;
            recepcion.Fecha_reg = Convert.ToDateTime(txt_fecha_reg.Text);
            recepcion.Hora_reg = txt_hora_reg.Text;
            recepcion.Part_Number = txt_part_number.Text;
            recepcion.ProductName = txt_product_name.Text;
            recepcion.Supply_Id = txt_id_supply.Text;
            recepcion.SupplyName = txt_supply_name.Text;
            recepcion.Width = Convert.ToDecimal(txt_width.Text);
            recepcion.Lenght = Convert.ToDecimal(txt_lenght.Text);
            recepcion.Roll_ID = txt_roll_id.Text;
            recepcion.Ubicacion = txt_ubic.Text;
            recepcion.Splice = Convert.ToInt16(txt_splice.Text);
            recepcion.Core = Convert.ToDecimal(txt_core.Text);
            recepcion.Anulado = false;
            recepcion.fecha_produccion = Convert.ToDateTime(txt_fecha_produccion.Text);
            recepcion.master = rad_masterRolls.Checked;
            recepcion.Resma = rad_resmas.Checked;
            recepcion.Graphics = rad_graphics.Checked;
            recepcion.Embarque = txt_num_embarque.Text;
            recepcion.Palet_number = txt_numero_palet.Text;
            recepcion.palet_cant = Convert.ToInt32(txt_cant_palet.Text);
            recepcion.Palet_paginas = Convert.ToInt32(txt_paginas.Text);
            // Validar la entidad documento recepcion.
            if (recepcion.Orden == string.Empty)
            {
                MessageBox.Show("Introduzca el numero de orden.");
                return;
            }
            if (recepcion.Roll_ID == string.Empty)
            {
                MessageBox.Show("Introduzca el roll ID.");
                return;
            }
            if (recepcion.Supply_Id == string.Empty)
            {
                MessageBox.Show("Introduzca el ID del proveedor.");
                return;
            }
            if (recepcion.Part_Number == string.Empty)
            {
                MessageBox.Show("Introduzca el part number.");
                return;
            }
            if (rad_masterRolls.Checked == false && 
                rad_graphics.Checked == false && 
                rad_resmas.Checked == false)
            {
                MessageBox.Show("debe suministrar el tipo de producto...");
                return;
            }
            if (rad_masterRolls.Checked)
            {
                if (recepcion.Width <= 0)
                {
                    MessageBox.Show("debe suministrar un valor valido para width del master rolls...");
                    return;
                }
                if (recepcion.Lenght <= 0)
                {
                    MessageBox.Show("debe suministrar un valor valido para lenght del master rolls...");
                    return;
                }
            }
            if (rad_resmas.Checked || rad_graphics.Checked)
            {
                if (recepcion.Palet_number == "")
                {
                    MessageBox.Show("debe suministrar un valor valido para palet number...");
                    return;
                }
                if (recepcion.palet_cant <= 0)
                {
                    MessageBox.Show("debe suministrar un valor valido para cantidad en el palet...");
                    return;
                }
            }
            recepcionManager.Add(recepcion);
            OpcionesMenu(0);
            OpcionesForms(1);
            ContadorRegistros();
            EditMode = 0;
        }
        private void GrabarUpdateRegistro()
        {
            ClassRecepcion recepcion = new ClassRecepcion
            {
                Orden = txt_orden.Text,
                fecha_produccion = Convert.ToDateTime(txt_fecha_produccion.Text),
                Embarque = txt_num_embarque.Text,
                Roll_ID = txt_roll_id.Text,
                Ubicacion = txt_ubic.Text,
                Anulado = CHK_ANULADO.Checked,
                Supply_Id = txt_id_supply.Text,
                Width = Convert.ToDecimal(txt_width.Text),
                Lenght = Convert.ToDecimal(txt_lenght.Text),
                Splice = Convert.ToInt32(txt_splice.Text),
                Core = Convert.ToDecimal(txt_core.Text)
            };
            manager.Update(recepcion);
            OpcionesMenu(0);
            OpcionesForms(1);
            EditMode = 0;
        }
        private void OpcionesMenu(int state)
        {
            switch (state)
            {
                case 0:
                    // MODO READ
                    bot_primero.Enabled = true;
                    bot_siguiente.Enabled = true;
                    bot_anterior.Enabled = true;
                    bot_ultimo.Enabled = true;
                    bot_nuevo.Enabled = true;
                    bot_grabar.Enabled = false;
                    bot_cancelar.Enabled = false;
                    bot_modificar.Enabled = true;
                    bot_buscar.Enabled = true;
                    bot_sincro.Enabled = true;
                    break;
                case 1:
                    //MODO ADD OPEN
                    bot_primero.Enabled = false;
                    bot_siguiente.Enabled = false;
                    bot_anterior.Enabled = false;
                    bot_ultimo.Enabled = false;
                    bot_nuevo.Enabled = false;
                    bot_grabar.Enabled = true;
                    bot_cancelar.Enabled = true;
                    bot_modificar.Enabled = false;
                    bot_buscar.Enabled = false;
                    bot_sincro.Enabled = false;
                    break;
            }
        }
        private void OpcionesForms(int state)
        {
            switch (state)
            {
                case 0:
                    // NEW-OPEN
                    bot_search_product.Enabled = true;
                    bot_search_provider.Enabled = true;
                    bot_convert.Enabled = true;
                    txt_orden.ReadOnly = false;
                    txt_part_number.ReadOnly = false;
                    txt_id_supply.ReadOnly = false;
                    txt_roll_id.ReadOnly = false;
                    txt_ubic.ReadOnly = false;
                    txt_num_embarque.ReadOnly = false;
                    txt_fecha_produccion.Enabled = true;
                    rad_masterRolls.Enabled = true;
                    rad_resmas.Enabled = true;
                    rad_graphics.Enabled = true;
                    CHK_ANULADO.DataBindings.Clear();
                    rad_masterRolls.DataBindings.Clear();
                    rad_resmas.DataBindings.Clear();
                    rad_graphics.DataBindings.Clear();
                    break;
                case 1:
                    //SAVE-ADD
                    txt_orden.ReadOnly = true;
                    txt_part_number.ReadOnly = true;
                    txt_id_supply.ReadOnly = true;
                    txt_roll_id.ReadOnly = true;
                    txt_ubic.ReadOnly = true;
                    txt_fecha_produccion.Enabled = false;
                    txt_num_embarque.ReadOnly = true;
                    bot_search_product.Enabled = false;
                    bot_search_provider.Enabled = false;
                    bot_convert.Enabled = false;
                    rad_masterRolls.Enabled = false;
                    rad_resmas.Enabled = false;
                    rad_graphics.Enabled = false;
                    if (EditMode == 1)
                    {
                        rad_masterRolls.DataBindings.Add("checked", bs, "master");
                        rad_resmas.DataBindings.Add("checked", bs, "resma");
                        rad_graphics.DataBindings.Add("checked", bs, "graphics");
                        CHK_ANULADO.DataBindings.Add("checked", bs, "anulado");
                    }
                    txt_numero_palet.ReadOnly = true;
                    txt_cant_palet.ReadOnly = true;
                    txt_paginas.ReadOnly = true;
                    txt_width.ReadOnly = true;
                    txt_lenght.ReadOnly = true;
                    txt_splice.ReadOnly = true;
                    txt_core.ReadOnly = true;
                    CHK_ANULADO.Enabled = false;
                    break;
                case 2:
                    //MODO UPDATE-OPEN
                    txt_fecha_produccion.Enabled = true;
                    txt_num_embarque.ReadOnly = false;
                    txt_roll_id.ReadOnly = false;
                    txt_ubic.ReadOnly = false;
                    txt_id_supply.ReadOnly = false;
                    bot_search_provider.Enabled = true;
                    bot_search_product.Enabled = true;
                    txt_part_number.ReadOnly = false;
                    CHK_ANULADO.Enabled = true;
                    if (rad_masterRolls.Checked)
                    {
                        txt_width.ReadOnly = false;
                        txt_lenght.ReadOnly = false;
                        txt_splice.ReadOnly = false;
                        txt_core.ReadOnly = false;
                    }
                    break;
                case 3:
                    break;
            }
        }

        private void Bot_search_provider_Click(object sender, EventArgs e)
        {
            SeleccionProveedores BrowseProviders = new SeleccionProveedores
            {
                dtsupply = ds.Tables["dtprovider"]
            };
            BrowseProviders.ShowDialog();
            txt_id_supply.Text = BrowseProviders.GetProviderID;
            txt_supply_name.Text = BrowseProviders.GetProviderName;
            //int itemFound = bs.Find("Proveedor_ID", BrowseProviders.itemSelected);
            //bs.Position = itemFound;
            chk_master_mts.Checked = manager.VericarMasterollMetros(BrowseProviders.GetProviderID);
        }
        private void Bot_search_product_Click(object sender, EventArgs e)
        {
            SeleccionProductos BrowseProducts = new SeleccionProductos
            {
                dtproducto = ds.Tables["dtproducto"]
            };
            BrowseProducts.ShowDialog();
            txt_part_number.Text = BrowseProducts.GetProductId;
            txt_product_name.Text = BrowseProducts.GetProductName;
            int tipo = manager.VerifarProductType(BrowseProducts.GetProductId);
            if (tipo == 1)
            {
                rad_masterRolls.Checked = true;
            }
            else if (tipo == 2)
            {
                rad_resmas.Checked = true;
            }
            else if (tipo == 3)
            {
                rad_graphics.Checked = true;
            }
        }
        private void Txt_orden_Validating(object sender, CancelEventArgs e)
        {
            if (manager.OrderExiste(txt_orden.Text) && EditMode == 1)
            {
                MessageBox.Show("La Orden Purchase : " + txt_orden.Text + " ya existe.");
                txt_orden.Text = "";
            }
        }
        private void Rad_resma_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_resmas.Checked)
            {
                txt_numero_palet.ReadOnly = false;
                txt_cant_palet.ReadOnly = false;
                txt_paginas.ReadOnly = false;
            }
            else
            {
                txt_numero_palet.ReadOnly = true;
                txt_cant_palet.ReadOnly = true;
                txt_paginas.ReadOnly = true;
            }
        }
        private void Rad_masterRolls_CheckedChanged(object sender, EventArgs e)
        {
            if (EditMode == 1 || EditMode == 2)
            {
                if (rad_masterRolls.Checked)
                {
                    txt_width.ReadOnly = false;
                    txt_lenght.ReadOnly = false;
                    txt_core.ReadOnly = false;
                    txt_splice.ReadOnly = false;
                }
                else
                {
                    txt_width.ReadOnly = true;
                    txt_lenght.ReadOnly = true;
                    txt_core.ReadOnly = true;
                    txt_splice.ReadOnly = true;
                }
            }
        }
        private void Rad_graphics_CheckedChanged(object sender, EventArgs e)
        {
            if (EditMode == 1 || EditMode == 2)
            {
                if (rad_graphics.Checked)
                {
                    txt_numero_palet.ReadOnly = false;
                    txt_cant_palet.ReadOnly = false;
                }
                else
                {
                    txt_numero_palet.ReadOnly = true;
                    txt_cant_palet.ReadOnly = true;
                }
            }
        }
        private void Rad_resmas_CheckedChanged(object sender, EventArgs e)
        {
            if (EditMode == 1 || EditMode == 2)
            {
                if (rad_resmas.Checked)
                {
                    txt_numero_palet.ReadOnly = false;
                    txt_cant_palet.ReadOnly = false;
                    txt_paginas.ReadOnly = false;
                }
                else
                {
                    txt_numero_palet.ReadOnly = true;
                    txt_cant_palet.ReadOnly = true;
                    txt_paginas.ReadOnly = true;
                }
            }
        }

        private void Bot_convert_Click(object sender, EventArgs e)
        {
            if (chk_master_mts.Checked && rad_masterRolls.Checked 
                && Convert.ToDouble(txt_width.Text) > 0 
                && Convert.ToDouble(txt_lenght.Text) > 0)
            {
                DialogResult dr = MessageBox.Show("Esta seguro de convertir los valores de width y lenght a pulgadas-pies(S/N)?",
                      "Mood Test", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:
                        double value_width = Math.Round((Convert.ToDouble(txt_width.Text) * FACTOR_METROS_PULDADAS),2,MidpointRounding.ToEven);
                        double value_lengh = Math.Round((Convert.ToDouble(txt_lenght.Text) * FACTOR_METROS_PIES),2,MidpointRounding.ToEven);
                        txt_width.Text = Convert.ToString(value_width);
                        txt_lenght.Text = Convert.ToString(value_lengh);
                        bot_convert.Enabled = false;
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }

        private void Bot_cancelar_Click(object sender, EventArgs e)
        {
            if (EditMode == 1)
            {
                //borro la factura alcual.
                DataRowView FilaActual;
                FilaActual = (DataRowView)bs.Current;
                FilaActual.Row.Delete();
                bs.EndEdit();
                bs.Position = bs.Count;
                ContadorRegistros();
                //activo la funciones del menu
                OpcionesMenu(0);
                OpcionesForms(1);
                EditMode = 0;
            }
            if (EditMode == 2)
            {
                OpcionesMenu(0);
                OpcionesForms(0);
                EditMode = 0;
            }
        }

        private void Bot_buscar_Click(object sender, EventArgs e)
        {
            SeleccionMateriaPrima frmbuscarOrden = new SeleccionMateriaPrima
            {
                dtrecepcion = ds.Tables["dtrecepcion"]
            };
            frmbuscarOrden.ShowDialog();
            int itemFound = bs.Find("OrderPurchase", frmbuscarOrden.GetOrderbyID);
            bs.Position = itemFound;
        }

        private void Bot_modificar_Click(object sender, EventArgs e)
        {
            OpcionesMenu(1);
            OpcionesForms(2);
            EditMode = 2;
        }
    }
}
