using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RitramaAPP.Clases
{
    public class OrdenCorteManager
    {
        readonly Conexion Micomm = new Conexion();
        public DataSet ds = new DataSet();
        readonly SqlDataAdapter dacustomer = new SqlDataAdapter();
        readonly SqlDataAdapter daordenes = new SqlDataAdapter();
        readonly SqlDataAdapter darenglones = new SqlDataAdapter();
        readonly SqlDataAdapter daproducts = new SqlDataAdapter();
        readonly SqlDataAdapter darolls = new SqlDataAdapter();
        readonly SqlDataAdapter darollid = new SqlDataAdapter();
        readonly DataTable dtordenes = new DataTable();
        readonly DataTable dtrenglones = new DataTable();
        readonly DataTable dtproducts = new DataTable();
        readonly DataTable dtrolls = new DataTable();
        readonly DataTable dtrollid = new DataTable();
        readonly string db = "RITRAMA";
        readonly string sql1 = "SELECT numero,fecha,pedido,customer_id,roll_id,total_rollos,anulada,status FROM orden_corte";
        readonly string sql2 = "SELECT reng_num,numero,product_id,cantidad,unidad,width,large,msi FROM  detalle_oc";
        readonly string sql3 = "SELECT Customer_ID,Customer_Name,Customer_Category,Customer_Dir,Customer_Email,Anulado  FROM customer";
        readonly string sql4 = "SELECT Product_ID,Product_Name,Product_Descrip,Product_Ref,Codebar,Existencia,Category_ID,Tipo_MP,Tipo_PT,anulado,existencia_final,tipo_otros FROM producto";
        readonly string sql5 = "SELECT product_id,roll_number,unique_code,splice,width,large,product_name,roll_id,msi,code_perso FROM rolls_details WHERE numero=@p1 and product_id=@p2";
        readonly string sql6 = "INSERT orden_corte (numero,fecha,pedido,customer_id,roll_id,total_rollos,anulada,status) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8) ";
        readonly string sql7 = "INSERT detalle_oc (reng_num,numero,product_id,cantidad,unidad,width,large,msi) VALUES (@r1,@r2,@r3,@r4,@r5,@r6,@r7,@r8)";
        readonly string sql8 = "INSERT rolls_details (fecha,numero,roll_number,product_id,product_name,roll_id,width,large,msi,splice,code_perso,unique_code) VALUES (@r1,@r2,@r3,@r4,@r5,@r6,@r7,@r8,@r9,@r10,@r11,@r12)";
        readonly string sql9 = "SELECT numero,roll_id FROM roll_id";
        readonly string sql10 = "INSERT INTO roll_id (numero,roll_id) VALUES (@P1,@p2)";
        readonly string sql11 = "DELETE roll_id WHERE (numero=@p1 AND roll_id=@p2)";
        readonly string sql12 = "UPDATE rolls_details SET roll_id=@p3 WHERE (numero=@p1 AND product_id=@p2)";

        public OrdenCorteManager()
        {
            CargarCustomers();
            CargarProducts();
            CargarOrdenes();
            CargarRollIdTable();
            RelacionesDS();
        }
        public Boolean UpdateDetailRollsNumberRollid(string numero,string product_id,string roll_id)
        {
            try
            {
                Micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = Micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = sql12

                };
                dacustomer.SelectCommand = comando;
                SqlParameter p1 = new SqlParameter("@p1", numero);
                SqlParameter p2 = new SqlParameter("@p2", product_id);
                SqlParameter p3 = new SqlParameter("@p3", roll_id);
                comando.Parameters.Add(@p1);
                comando.Parameters.Add(@p2);
                comando.Parameters.Add(@p3);
                comando.ExecuteNonQuery();
                comando.Dispose();
                Micomm.Desconectar();
                MessageBox.Show("Guardado con Exito");
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("error al grabar el numero id . error code:" + ex);
                return false;
            }
        }
        public bool DeleteNumberRollIdtoTable(string orden, string roll_id)
        {
            try
            {
                Micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = Micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = sql11

                };
                dacustomer.SelectCommand = comando;
                SqlParameter p1 = new SqlParameter("@p1", orden);
                SqlParameter p2 = new SqlParameter("@p2", roll_id);
                comando.Parameters.Add(@p1);
                comando.Parameters.Add(@p2);
                comando.ExecuteNonQuery();
                comando.Dispose();
                Micomm.Desconectar();
                MessageBox.Show("Guardado con Exito");
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("error al borrar el numero id . error code:" + ex);
                return false;
            }
        }
        public Boolean AddNumberRollIdtoTable(string orden,string roll_id)
        {
            try
            {
                Micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = Micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = sql10

                };
                dacustomer.SelectCommand = comando;
                SqlParameter p1 = new SqlParameter("@p1",orden);
                SqlParameter p2 = new SqlParameter("@p2", roll_id);
                comando.Parameters.Add(@p1);
                comando.Parameters.Add(@p2);
                comando.ExecuteNonQuery();
                comando.Dispose();
                Micomm.Desconectar();
                MessageBox.Show("Guardado con Exito");
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("error al grabar el numero id . error code:" + ex);
                return false;
            }
        }
        public Boolean CargarRollIdTable()
        {
            try
            {
                Micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = Micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = sql9

                };
                comando.ExecuteNonQuery();
                darollid.SelectCommand = comando;
                darollid.Fill(ds, "dtrollid");
                comando.Dispose();
                Micomm.Desconectar();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al cargar la lista de los roll id. error code:" + ex);
                return false;
            }
        }
        public Boolean SaveDataDetailsRolls(List<Roll_Details> rollos)
        {
            SqlTransaction transac = null;
            try
            {
                using (Micomm.cnn)
                {
                    Micomm.Conectar(db);
                    transac = Micomm.cnn.BeginTransaction();
                    SqlCommand comando = new SqlCommand
                    {
                        Transaction = transac,
                        CommandType = CommandType.Text,
                        CommandText = sql8,
                        Connection = Micomm.cnn
                    };
                    SqlParameter r1 = new SqlParameter
                    {
                        ParameterName = "@r1"
                    };
                    SqlParameter r2 = new SqlParameter
                    {
                        ParameterName = "@r2"
                    };
                    SqlParameter r3 = new SqlParameter
                    {
                        ParameterName = "@r3"
                    };
                    SqlParameter r4 = new SqlParameter
                    {
                        ParameterName = "@r4"
                    };
                    SqlParameter r5 = new SqlParameter
                    {
                        ParameterName = "@r5"
                    };
                    SqlParameter r6 = new SqlParameter
                    {
                        ParameterName = "@r6"
                    };
                    SqlParameter r7 = new SqlParameter
                    {
                        ParameterName = "@r7"
                    };
                    SqlParameter r8 = new SqlParameter
                    {
                        ParameterName = "@r8"
                    };
                    SqlParameter r9 = new SqlParameter
                    {
                        ParameterName = "@r9"
                    };
                    SqlParameter r10 = new SqlParameter
                    {
                        ParameterName = "@r10"
                    };
                    SqlParameter r11 = new SqlParameter
                    {
                        ParameterName = "@r11"
                    };
                    SqlParameter r12 = new SqlParameter
                    {
                        ParameterName = "@r12"
                    };
                    comando.Parameters.Add(r1);
                    comando.Parameters.Add(r2);
                    comando.Parameters.Add(r3);
                    comando.Parameters.Add(r4);
                    comando.Parameters.Add(r5);
                    comando.Parameters.Add(r6);
                    comando.Parameters.Add(r7);
                    comando.Parameters.Add(r8);
                    comando.Parameters.Add(r9);
                    comando.Parameters.Add(r10);
                    comando.Parameters.Add(r11);
                    comando.Parameters.Add(r12);
                    foreach (Roll_Details item in rollos)
                    {
                        r1.Value = item.Fecha;
                        r2.Value = item.Numero_Orden;
                        r3.Value = item.Roll_number;
                        r4.Value = item.Product_id;
                        r5.Value = item.Product_name;
                        r6.Value = item.Roll_id;
                        r7.Value = item.Width;
                        r8.Value = item.Large;
                        r9.Value = item.Msi;
                        r10.Value = item.Splice;
                        r11.Value = item.Code_Person;
                        r12.Value = item.Code_Unique;
                        comando.ExecuteNonQuery();
                    }
                    //Ejecucion del Commit
                    transac.Commit();
                    MessageBox.Show("Se guardaron los datos correctamente de la orden de corte.");
                    return true;
                }
            }
            catch (SqlException ex)
            {
                transac.Rollback();
                MessageBox.Show("Error al grabar el detalle de los rollos cortados...error->code: " + ex);
                return false;
            }
        }
        public Boolean ToSave(Orden orden)
        {
            SqlTransaction transac = null;
            try
            {
                using (Micomm.cnn)
                {
                    //sql del encabezado de la orden de corte.
                    Micomm.Conectar(db);
                    transac = Micomm.cnn.BeginTransaction();
                    SqlCommand comando = new SqlCommand
                    {
                        Transaction = transac,
                        CommandType = CommandType.Text,
                        CommandText = sql6,
                        Connection = Micomm.cnn
                    };
                    // aqui va todos los datos del encabezado de la orden de corte.
                    SqlParameter p1 = new SqlParameter("@p1", orden.Numero);
                    SqlParameter p2 = new SqlParameter("@p2", orden.Fecha);
                    SqlParameter p3 = new SqlParameter("@p3", orden.Pedido);
                    SqlParameter p4 = new SqlParameter("@p4", orden.Customer_id);
                    SqlParameter p5 = new SqlParameter("@p5", orden.Roll_id);
                    SqlParameter p6 = new SqlParameter("@p6", orden.Total_rolls);
                    SqlParameter p7 = new SqlParameter("@p7", orden.anulada);
                    SqlParameter p8 = new SqlParameter("@p8", orden.status);
                    comando.Parameters.Add(p1);
                    comando.Parameters.Add(p2);
                    comando.Parameters.Add(p3);
                    comando.Parameters.Add(p4);
                    comando.Parameters.Add(p5);
                    comando.Parameters.Add(p6);
                    comando.Parameters.Add(p7);
                    comando.Parameters.Add(p8);
                    comando.ExecuteNonQuery();
                    //sql del detalle de factura.
                    SqlCommand comando1 = new SqlCommand
                    {
                        Transaction = transac,
                        CommandType = CommandType.Text,
                        CommandText = sql7,
                        Connection = Micomm.cnn
                    };
                    SqlParameter r1 = new SqlParameter
                    {
                        ParameterName = "@r1"
                    };
                    SqlParameter r2 = new SqlParameter
                    {
                        ParameterName = "@r2"
                    };
                    SqlParameter r3 = new SqlParameter
                    {
                        ParameterName = "@r3"
                    };
                    SqlParameter r4 = new SqlParameter
                    {
                        ParameterName = "@r4"
                    };
                    SqlParameter r5 = new SqlParameter
                    {
                        ParameterName = "@r5"
                    };
                    SqlParameter r6 = new SqlParameter
                    {
                        ParameterName = "@r6"
                    };
                    SqlParameter r7 = new SqlParameter
                    {
                        ParameterName = "@r7"
                    };
                    SqlParameter r8 = new SqlParameter
                    {
                        ParameterName = "@r8"
                    };
                    comando1.Parameters.Add(r1);
                    comando1.Parameters.Add(r2);
                    comando1.Parameters.Add(r3);
                    comando1.Parameters.Add(r4);
                    comando1.Parameters.Add(r5);
                    comando1.Parameters.Add(r6);
                    comando1.Parameters.Add(r7);
                    comando1.Parameters.Add(r8);
                    foreach(Orden_Items item in orden.items)
                    {
                        r1.Value = item.renglon;
                        r2.Value = item.numero;
                        r3.Value = item.Product_id;
                        r4.Value = item.Cantidad;
                        r5.Value = item.Unidad;
                        r6.Value = item.Width;
                        r7.Value = item.Large;
                        r8.Value = item.Msi;
                        comando1.ExecuteNonQuery();
                    }
                    //Ejecucion del Commit
                    transac.Commit();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                transac.Rollback();
                MessageBox.Show("Error al grabar la orden de corte...error->code: " + ex);
                return false;
            }
        }
        public DataTable GetRollDetails(string numero_orden,string product_id)
        {
            DataTable dt = new DataTable();
            try
            {
                Micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = Micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = sql5

                };
                darolls.SelectCommand = comando;
                SqlParameter p1 = new SqlParameter("@p1", numero_orden);
                SqlParameter p2 = new SqlParameter("@p2", product_id);
                comando.Parameters.Add(p1);
                comando.Parameters.Add(p2);
                comando.ExecuteNonQuery();
                darolls.Fill(dt);
                comando.Dispose();
                Micomm.Desconectar();
                return dt;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al cargar la lista de productos para armar la orden de corte. error code:" + ex);
                dt = null;
                return dt;
            }
        }
        public Boolean CargarProducts()
        {
            try
            {
                Micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = Micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = sql4

                };
                comando.ExecuteNonQuery();
                daproducts.SelectCommand = comando;
                daproducts.Fill(ds, "dtproducts");
                comando.Dispose();
                Micomm.Desconectar();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al cargar la lista de productos para armar la orden de corte. error code:" + ex);
                return false;
            }
        }
        public Boolean CargarCustomers()
        {
            try
            {
                Micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = Micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = sql3

                };
                comando.ExecuteNonQuery();
                dacustomer.SelectCommand = comando;
                dacustomer.Fill(ds, "dtcustomer");
                comando.Dispose();
                Micomm.Desconectar();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al cargar la lista de los clientes para armar las ordenes de corte . error code:" + ex);
                return false;
            }
        }
        public Boolean CargarOrdenes()
        {
            try
            {
                // encabeza de la orden de corte
                Micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = sql1,
                    Connection = Micomm.cnn
                };
                comando.ExecuteNonQuery();
                daordenes.SelectCommand = comando;
                daordenes.Fill(ds, "dtordenes");

                //detalle de la orden de corte.
                SqlCommand comando1 = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = sql2,
                    Connection = Micomm.cnn
                };
                comando1.ExecuteNonQuery();
                darenglones.SelectCommand = comando1;
                darenglones.Fill(ds, "dtrenglones");
                Micomm.Desconectar();
                comando.Dispose();
                comando1.Dispose();
            
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al cargar las Ordenes de Corte...Error Code: " + ex);
                return false;

            }
        }
        public Boolean RelacionesDS()
        {
            try
            {
                //Relacion Maestro-detalle.
                DataColumn ParentCol1 = ds.Tables["dtordenes"].Columns["numero"];
                DataColumn ChildCol1 = ds.Tables["dtrenglones"].Columns["numero"];
                DataRelation orden_detal = new DataRelation("FK_ORDENES_DETALLE", ParentCol1, ChildCol1);
                ds.Relations.Add(orden_detal);
                //Relacion Factura-Cliente.
                DataColumn ParentCol2 = ds.Tables["dtcustomer"].Columns["Customer_ID"];
                DataColumn ChildCol2 = ds.Tables["dtordenes"].Columns["customer_id"];
                DataRelation ordenes_cliente = new DataRelation("FK_ORDENES_CLIENTE", ParentCol2, ChildCol2);
                ds.Relations.Add(ordenes_cliente);
                ds.Tables["dtordenes"].Columns.Add("customer_name",
                Type.GetType("System.String"), "parent(FK_ORDENES_CLIENTE).customer_name");
                //Relacion detalle-productos.
                DataColumn ParentCol3 = ds.Tables["dtproducts"].Columns["product_id"];
                DataColumn ChildCol3 = ds.Tables["dtrenglones"].Columns["product_id"];
                DataRelation deta_producto = new DataRelation("FK_DETALLE_PRODUCTO", ParentCol3, ChildCol3);
                ds.Relations.Add(deta_producto);
                ds.Tables["dtrenglones"].Columns.Add("product_name",
                Type.GetType("System.String"), "parent(FK_DETALLE_PRODUCTO).product_name");
                // relaciones ordenes roll_id con key composite.
                DataColumn ParentCol4 = ds.Tables["dtordenes"].Columns["numero"];  
                DataColumn ChildCol4 = ds.Tables["dtrollid"].Columns["numero"];
                DataRelation ord_roll_id = new DataRelation("FK_ORDEN_ROLL_ID", ParentCol4, ChildCol4);
                ds.Relations.Add(ord_roll_id);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al tratar de establecer las relaciones entre tablas. Error Code:" + ex);
                return false;
            }
        }
    }
}
