using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RitramaAPP
{
    public class R
    {
        public class SQL
        { 
            public class DATABASE
            {
                public static string NAME = "ritrama";    
            }
            public class TABLES
            {
                public static string TABLE_RECEPCION = "OrdenRecepcion";
                public static string TABLE_PRODUCTS = "producto";
                public static string TABLE_CUSTOMERS = "Customer";
            }
            public class QUERY_SQL
            {
                public class PRODUCTS
                {
                    public static string SQL_QUERY_SELECT_PRODUCT_ALL = "SELECT Product_ID,Product_Name,Product_Descrip,Product_Ref,Codebar,Category_ID,MasterRolls,Resmas,anulado,precio,graphics FROM producto";
                    public static string SQL_QUERY_SELECT_PRODUCTS = "SELECT Product_ID, Product_Name FROM producto";
                    public static string SQL_QUERY_SELECT_TYPE_PRODUCT = "SELECT MasterRolls,Resmas,Graphics FROM producto WHERE product_id=@p1";
                    public static string SQL_QUERY_SELECT_PRODUCT_NAME = "SELECT  Product_Name FROM producto WHERE product_id=@p1";
                    public static string SQL_QUERY_INSERT_PRODUCT = "INSERT INTO producto (Product_ID,Product_Name,Product_Descrip,Product_Ref,Codebar,Category_ID,MasterRolls,Resmas,Graphics,anulado,precio) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)";
                    public static string SQL_QUERY_UPDATE_PRODUCTS = "UPDATE producto SET Product_Name=@p2,Product_Descrip=@p3,Product_Ref=@p4,Codebar=@p5,Category_ID=@p6,MasterRolls=@p7,Resmas=@p8,Graphics=@p9,anulado=@p10,precio=@p11 WHERE Product_ID=@p1";
                    public static string SQL_QUERY_COUNT_PRODUCTS = "SELECT count(*) FROM producto WHERE product_id=@p1";
                    
                }
                public class CUSTOMERS
                {
                }

                public class PROVIDERS
                {
                    public static string SQL_QUERY_SELECT_PROVIDER_ONLY_TABLE = "";
                    public static string SQL_QUERY_SELECT_PROVEEDORES = "SELECT Proveedor_ID,Proveedor_Name,Preveedor_phone,Preveedor_Dir,Preveedor_email,anulado,unidad_master_1,unidad_master_2 FROM provider";
                    public static string SQL_QUERY_INSERT_PROVEEDORES = "INSERT INTO provider (Proveedor_ID,Proveedor_Name,Preveedor_Dir,Preveedor_phone,Preveedor_email,anulado,unidad_master_1,unidad_master_2) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)";
                    public static string SQL_QUERY_UPDATE_PROVEEDORES = "UPDATE provider SET Proveedor_Name=@p2,Preveedor_Dir=@p3,Preveedor_phone=@p4,Preveedor_email=@p5,anulado=@p6,unidad_master_1=@p7,unidad_master_2=@p8 WHERE Proveedor_ID=@p1";
                    public static string SQL_QUERY_COUNT_PROVEEDORES = "SELECT count(*) FROM provider WHERE proveedor_id=@p1";
                }

                public class RECEPCIONES
                {
                    public static string SQL_QUERY_SELECT_ORDENES_RECEPCION = "SELECT OrderPurchase,Part_Number,Width,Lenght,Roll_Id,Proveedor_Id,Splice,Core,Ubicacion,anulado,fecha_reg,hora_reg,fecha_pro,master,resma,graphics,embarque,palet_num,palet_cant,palet_pag FROM OrdenRecepcion";
                    public static string SQL_QUERY_COUNT_FOR_ORDER = "SELECT count(*) FROM OrdenRecepcion WHERE OrderPurchase=@p1";
                    public static string SQL_QUERY_COUNT_FOR_VERIFY_UNIT2 = "SELECT unidad_master_2 FROM provider WHERE Proveedor_ID=@p1";
                    public static string SQL_QUERY_UPDATE_ORDEN_RECEPCION = "UPDATE OrdenRecepcion SET fecha_pro=@p2,embarque=@p3,Roll_Id=@p4,anulado=@p5,ubicacion=@p6,Proveedor_Id=@p7,width=@p8,lenght=@p9,splice=@p10,core=@p11 WHERE OrderPurchase=@p1";
                    public static string SQL_QUERY_INSERT_DOCS_RECEPCIONES = "INSERT INTO " + R.SQL.TABLES.TABLE_RECEPCION + 
                   "(OrderPurchase,Part_Number,Width,Lenght,Roll_Id,Proveedor_Id,Ubicacion,Core,Splice,Anulado,fecha_reg,hora_reg,fecha_pro,master,resma,graphics,embarque,palet_num,palet_cant,palet_pag,num_sincro) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17,@p18,@p19,@p20,@p21)";
                    public static string SQL_QUERY_VERIFY_ORDEN_REPEAT = "SELECT count(*) FROM OrdenRecepcion WHERE OrderPurchase=@p1";
                }
                public class HOJACOSTO
                {

                }

                public class DESPACHOS
                {
                }
                public class PEDIDOS
                {
                }


            }
        }
        public class MESSAGES_TEXT_SYSTEM_MODULES
        {
            public class MODULO_PRODUCTOS
            {
                public static string MESSAGE_SELECT_LOADPRODUCTOS_FAIL = "error al cargar la tabla de productos...error code:";
                public static string MESSAGE_ADD_PRODUCTS_ERROR = "Error al crear productos...Error Code:";
                public static string MESSAGE_UPDATE_PRODUCTS_ERROR = "Error al modificar producto...Error Code:";
            }
            public class MODULO_PROVEEDORES
            {
                public static string MESSAGE_SELECT_LOADPROVEEDORES_FAIL = "Error al cargar la tabla de providers...error code: ";
            }
            public class MODULO_RECEPCIONES
            {
                public static string MESSAGE_TEXT_RECEPCIONES_ERROR_ADD_DOCUMENTS = "Error al incluir ordenes de recepcion de materia prima(MASTER)..error code:";
                public static string MESSAGE_INSERT_RECEPCIONES_OK = "Se registraron los datos de la recepcion correctamente.";
                public static string MESSAGE_INSERT_RECEPCIONES_FAIL = "Error al tratar de registrar los datos de las recepciones de materia prima.";
                public static string MESSAGE_UPDATE_RECEPCIONES_OK = "Se actualizo la informacion de la orden de recepcion";
                public static string MESSAGE_UPDATE_RECEPCIONES_FAIL = "Error al tratar de actualizar los datos de la orden de recepcion";
                public static string MESSAGE_SELECT_LOADRECEPCIONES_FAIL = "Error al tratar de traer los datos de las recepciones de materia prima.";

            }
        }
        public class PATH_FILES
        {
            public static string FILE_TXT_MATERIA_PRIMA = @"C:\Users\npino\Documents\RITRAMA\RitramaAPP\data\data.txt";
        }
    }
}
