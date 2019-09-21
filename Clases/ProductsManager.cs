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
    public class ProductsManager
    {
        readonly Conexion micomm = new Conexion();
        public DataSet ds = new DataSet();
        readonly DataTable dtproducto = new DataTable();
        readonly SqlDataAdapter daproducto = new SqlDataAdapter();
        readonly string db = "RITRAMA";
        readonly string sql1 = "SELECT Product_ID,Product_Name,Product_Descrip,Product_Ref,Codebar,Category_ID,MasterRolls,Resmas,anulado,precio,graphics FROM producto";
        readonly string sql2 = "INSERT INTO producto (Product_ID,Product_Name,Product_Descrip,Product_Ref,Codebar,Category_ID,MasterRolls,Resmas,Graphics,anulado,precio) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)";
        readonly string sql3 = "UPDATE producto SET Product_Name=@p2,Product_Descrip=@p3,Product_Ref=@p4,Codebar=@p5,precio=@p6,Category_ID=@p7,MasterRolls=@p8,Resmas=@p9,Graphics=@p10,anulado=@p11 WHERE Product_ID=@p1";
        readonly string sql4="SELECT count(*) FROM producto WHERE product_id=@p1";
        public DataTable Dtproducto => dtproducto;

        public Boolean ToList()
        {
            try
            {
                micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = sql1
                 
                };
                comando.ExecuteNonQuery();
                daproducto.SelectCommand = comando;
                daproducto.Fill(ds, "dtproducto");
                comando.Dispose();
                micomm.Desconectar();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al cargar la lista de productos. error code:" + ex);
                return false;
            }
        }
        public Boolean Add(ClassProduct producto)
        {
            try
            {
                micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = sql2

                };
                SqlParameter p1 = new SqlParameter("@p1", producto.Prodct_ID);
                SqlParameter p2 = new SqlParameter("@p2", producto.ProductName);
                SqlParameter p3 = new SqlParameter("@p3", producto.Descripcion);
                SqlParameter p4 = new SqlParameter("@p4", producto.Referencia);
                SqlParameter p5 = new SqlParameter("@p5", producto.Codebar);
                SqlParameter p6 = new SqlParameter("@p6", producto.Categoria);
                SqlParameter p7 = new SqlParameter("@p7", producto.MasterRolls);
                SqlParameter p8 = new SqlParameter("@p8", producto.Resmas);
                SqlParameter p9 = new SqlParameter("@p9", producto.Graphics);
                SqlParameter p10 = new SqlParameter("@p10", producto.Anulado);
                SqlParameter p11 = new SqlParameter("@p11", producto.Precio);
                comando.Parameters.Add(p1);
                comando.Parameters.Add(p2);
                comando.Parameters.Add(p3);
                comando.Parameters.Add(p4);
                comando.Parameters.Add(p5);
                comando.Parameters.Add(p6);
                comando.Parameters.Add(p7);
                comando.Parameters.Add(p8);
                comando.Parameters.Add(p9);
                comando.Parameters.Add(p10);
                comando.Parameters.Add(p11);
                comando.ExecuteNonQuery();
                comando.Dispose();
                micomm.Desconectar();
                MessageBox.Show("proceso realizado con exito...");
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar nuevo registro de producto...Error Code:" + ex );
                return false;
            }
        }
        public Boolean Update(ClassProduct producto)
        {
            try
            {
                micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = sql3

                };
                SqlParameter p1 = new SqlParameter("@p1", producto.Prodct_ID);
                SqlParameter p2 = new SqlParameter("@p2", producto.ProductName);
                SqlParameter p3 = new SqlParameter("@p3", producto.Descripcion);
                SqlParameter p4 = new SqlParameter("@p4", producto.Referencia);
                SqlParameter p5 = new SqlParameter("@p5", producto.Codebar);
                SqlParameter p6 = new SqlParameter("@p6", producto.Precio);
                SqlParameter p7 = new SqlParameter("@p7", producto.Categoria);
                SqlParameter p8 = new SqlParameter("@p8", producto.MasterRolls);
                SqlParameter p9 = new SqlParameter("@p9", producto.Resmas);
                SqlParameter p10 = new SqlParameter("@p10", producto.Graphics);
                SqlParameter p11 = new SqlParameter("@p11", producto.Anulado);
                comando.Parameters.Add(p1);
                comando.Parameters.Add(p2);
                comando.Parameters.Add(p3);
                comando.Parameters.Add(p4);
                comando.Parameters.Add(p5);
                comando.Parameters.Add(p6);
                comando.Parameters.Add(p7);
                comando.Parameters.Add(p8);
                comando.Parameters.Add(p9);
                comando.Parameters.Add(p10);
                comando.Parameters.Add(p11);
                comando.ExecuteNonQuery();
                comando.Dispose();
                micomm.Desconectar();
                MessageBox.Show("Se actualizaron los datos con exito...");
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al modificar producto...Error Code:" + ex);
                return false;

            }
        }
        public DataTable GetTableProductsOnly()
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                try
                {
                    micomm.Conectar(db);
                    SqlCommand comando = new SqlCommand
                    {
                        Connection = micomm.cnn,
                        CommandType = CommandType.Text,
                        CommandText = sql1

                    };
                    comando.ExecuteNonQuery();
                    da.SelectCommand = comando;
                    da.Fill(dt);
                    comando.Dispose();
                    micomm.Desconectar();
                    return dt;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al cargar la lista de productos. error code:" + ex);
                    return dt;
                }
            }

        }
        public Boolean ProductoExiste(string codigo)
        {
            int result;
            micomm.Conectar(db);
            SqlCommand comando = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = sql4,
                Connection = micomm.cnn
            };
            SqlParameter p1 = new SqlParameter("@p1", codigo);
            comando.Parameters.Add(p1);
            result = Convert.ToInt16(comando.ExecuteScalar());
            micomm.Desconectar();
            comando.Dispose();
            if (result == 1)
            {
                // producto existe
                return true;
            }
            else
            {
                //producto no existe
                return false;
            }
        }
    }
}
