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
                    public static string  SQL_SELECT_CUSTOMERS = "SELECT Customer_ID,Customer_Name,Customer_Category," +
                        "Customer_Dir,Customer_Email,Anulado  FROM customer";
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
                    public static string SQL_QUERY_SELECT_ORDENES_RECEPCION = "SELECT OrderPurchase,Part_Number,Width,Lenght," +
                        "Roll_Id,Proveedor_Id,Splice,Core,Ubicacion,anulado,fecha_reg,hora_reg,fecha_pro,master,resma,graphics," +
                        "embarque,palet_num,palet_cant,palet_pag,num_sincro,registro_movil FROM OrdenRecepcion";
                    public static string SQL_QUERY_COUNT_FOR_ORDER = "SELECT count(*) FROM OrdenRecepcion WHERE OrderPurchase=@p1";
                    public static string SQL_QUERY_COUNT_FOR_VERIFY_UNIT2 = "SELECT unidad_master_2 FROM provider WHERE Proveedor_ID=" +
                        "@p1";
                    public static string SQL_QUERY_UPDATE_ORDEN_RECEPCION = "UPDATE OrdenRecepcion SET fecha_pro=@p2,embarque=@p3," +
                        "Roll_Id=@p4,anulado=@p5,ubicacion=@p6,Proveedor_Id=@p7,width=@p8,lenght=@p9,splice=@p10,core=@p11 " +
                        "WHERE OrderPurchase=@p1";
                    public static string SQL_QUERY_INSERT_DOCS_RECEPCIONES = "INSERT INTO " + R.SQL.TABLES.TABLE_RECEPCION + 
                    "(OrderPurchase,Part_Number,Width,Lenght,Roll_Id,Proveedor_Id,Ubicacion,Core,Splice,Anulado,fecha_reg,hora_reg," +
                        "fecha_pro,master,resma,graphics,embarque,palet_num,palet_cant,palet_pag,num_sincro,registro_movil) " +
                        "VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14," +
                        "@p15,@p16,@p17,@p18,@p19,@p20,@p21,@p22)";
                    public static string SQL_QUERY_VERIFY_ORDEN_REPEAT = "SELECT count(*) FROM OrdenRecepcion WHERE " +
                        "OrderPurchase=@p1";
                }
                public class PRODUCCION
                {
                    public static string SQL_SELECT_ORDEN_CORTE = "SELECT  numero,fecha,fecha_produccion,product_id,rollid_1,width_1," +
                        "lenght_1,rollid_2,width_2,lenght_2,cant_cortado,width_cortado,lenght_cortado,msi_cortado,anulada,Procesado " +
                        "FROM orden_corte ";
                    public static string SQL_SELECT_DETALLE_OC = "SELECT reng_num,numero,product_id,cantidad,unidad,width,large,msi FROM  detalle_oc";
                    public static string SQL_UPDATE_ROLLS_DETAILS = "SELECT product_id,roll_number,unique_code,splice,width,large,product_name,roll_id,msi," +
                        "code_perso FROM rolls_details WHERE numero=@p1 and product_id=@p2";
                    public static string SQL_QUERY_INSERT_MASTER_OC = "INSERT orden_corte (numero,fecha,fecha_produccion,product_id,rollid_1,width_1,lenght_1," +
                        "rollid_2,width_2,lenght_2,cant_cortado,width_cortado,lenght_cortado,msi_cortado,anulada,Procesado) " +
                        "VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16) ";
                    public static string SQL_QUERY_INSERT_DETAILS_OC = "INSERT rolls_details (numero,product_id,product_name,roll_number,unique_code,splice,width,large,msi,roll_id,code_person,status) " +
                        "VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)";
                    public static string SQL_QUERY_SELECT_ROLLID = "SELECT a.roll_id,a.part_number,b.product_name,a.width,a.lenght FROM OrdenRecepcion a LEFT JOIN producto b ON a.part_number = b.product_id";
                    public static string SQL_QUERY_SELECT_ROLLOS_CORTADOS = "SELECT numero,product_id,product_name,roll_number,unique_code,splice,width,large,msi,roll_id,code_person,status FROM rolls_details";
                    public static string SQL_QUERY_INSERT_ROLLID = "INSERT INTO roll_id (numero,roll_id) VALUES (@P1,@p2)";
                    public static string SQL_QUERY_INSERT_ROLLS_DETAILS = "INSERT rolls_details (fecha,numero,roll_number,product_id," +
                        "product_name,roll_id,width,large,msi,splice,code_perso,unique_code) VALUES (@r1,@r2,@r3,@r4,@r5,@r6,@r7,@r8,@r9,@r10,@r11,@r12)";
                    public static string SQL_QUERY_DELETE_ROLLID = "DELETE roll_id WHERE (numero=@p1 AND roll_id=@p2)";
                    public static string SQL_QUERY_UPDATE_ROLLID = "UPDATE rolls_details SET roll_id=@p3 WHERE (numero=@p1 AND product_id=@p2)";
                    public static string SQL_QUERY_UPDATE_ORDEN_PRODUCCION = "UPDATE orden_corte SET fecha=@p2,fecha_produccion=@P3," +
                        "product_id=@p4,rollid_1=@p5,width_1=@p6,lenght_1=@p7,rollid_2=@p8,width_2=@p9,lenght_2=@p10,cant_cortado=@p11," +
                        "width_cortado=@p12,lenght_cortado=@p13,msi_cortado=@p14 WHERE numero=@p1";
                    public static string SQL_QUERY_DELETE_ORDEN_ROLLDETAILS = "DELETE rolls_details WHERE numero=@p1";
                    public static string SQL_QUERY_UPDATE_ROLLSDETAILS_RENGLON = "UPDATE rolls_details SET splice=@p3,code_person=@p4,status=@p5 WHERE (numero=@p1 AND unique_code=@p2)";
                }
                public class DESPACHOS
                {
                    public static string SQL_SELECT_DESPACHOS_HEADER = "SELECT numero,fecha,customer_id,person_contact,conduce,vendor_id,transport_id,chofer_id,placas_id,packing,orden_trabajo,orden_corte,orden_compra,subtotal,porc_itbis,itbis,total$rd FROM despacho";
                    public static string SQL_SELECT_DESPACHOS_DETAILS = "SELECT numero,product_id,cant,unid_id,width,lenght,msi,ratio,kilo_rollo,kilo_total,precio,total_renglon FROM item_despacho";
                    public static string SQL_SELECT_CUSTOMERS = "SELECT Customer_ID,Customer_Name,Customer_Category,Customer_Dir,Customer_Email,Anulado  FROM customer";
                    public static string SQL_SELECT_VENDEDORES = "SELECT vendor_id,vendor_name FROM vendedor";
                    public static string SQL_SELECT_TRANSPORTE = "SELECT transport_id,transport_name FROM transporte";
                    public static string SQL_SELECT_CHEFERES = "SELECT chofer_id,chofer_name FROM chofer";
                    public static string SQL_SELECT_CAMION = "SELECT placas_id,camion_name FROM camion";
                    public static string SQL_SELECT_PRODUCTOS = "SELECT product_id,product_name FROM producto";
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
            public class CUSTOMERS 
            {
                public static string MESSAGE_SELECT_LOAD_CUSTOMERS_FAIL = "Error al tratar de cargas los clientes al sistema ERROR: ";
            }
            public class PRODUCCION 
            {
                public static string MESSAGE_LOAD_ROLLOS_CORTADOS_ERROR_FAIL = "Error al cargar la lista de los rollos cortados. error code:";
                public static string MESSAGE_ADD_ORDEN_ERROR_FAIL_HEADER = "Error al tratar de grabar el encabezado de la orden de produccion";
                public static string MESSAGE_ADD_ORDEN_ERROR_FAIL_DETAILS = "Error al tratar de grabar el detalle de la orden de produccion";
                public static string MESSAGE_LOAD_ROLLID_ERROR_FAIL = "Error al cargar los roll id de la materia prima";
                public static string MESSAGE_UPDATE__ERROR_HEADER = "Error al modificar el encabezado de la orden de produccion";
                public static string MESSAGE_DELETE_ORDER_ROLLSDETAIL = "Error al tratar de eliminar informacion de los rollos cortados...";
                public static string MESSAGE_UPDATE_ERROR_ORDER_ROLLSDETAIL = "ERROR AL ACTUALIZAR LA DATA DE LOS ROLLOS CORTADOS...";


            }
            public class DESPACHOS 
            {
                public static string MESSAGE_SELECT_ERROR_LOAD_PRODUCTS = "Error al tratar de cargar los productos.";
                public static string MESSAGE_SELECT_ERROR_LOAD_CHOFERES = "Error al tratar de cargar los choferes.";
                public static string MESSAGE_SELECT_ERROR_LOAD_CAMIONES= "Error al tratar de cargar los camiones.";
                public static string MESSAGE_SELECT_ERROR_LOAD_TRANSPORTE = "Error al tratar de cargar los transportes.";
                public static string MESSAGE_SELECT_ERROR_LOAD_VENDEDOR = "Error al tratar de cargar los vendedores.";
                public static string MESSAGE_SELECT_ERROR_LOAD_CUSTOMERS = "Error al tratar de cargar los clientes en el modulo de despacho.";
                public static string MESSAGE_SELECT_ERROR_LOAD_HEADER_DESPACHOS = "Error al tratar de cargar los encabezados de los despachos.";
                public static string MESSAGE_SELECT_ERROR_LOAD_DETAILS_DESPACHOS = "Error al tratar de cargar los detalle de los despachos.";
            }
        }
        public class PATH_FILES
        {
            public static string FILE_TXT_MATERIA_PRIMA = @"C:\Users\npino\Documents\RITRAMA\RitramaAPP\data\data.txt";
        }
    }
}
