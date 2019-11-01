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
                    public static string SQL_QUERY_SELECT_PRODUCT_ALL = "SELECT Product_ID,Product_Name,Product_Descrip,Product_Ref,Codebar,Category_ID,MasterRolls,rollo_cortado,Resmas,anulado,precio,graphics,code_RC FROM producto";
                    public static string SQL_QUERY_SELECT_PRODUCTS = "SELECT Product_ID, Product_Name,case when MasterRolls = 1 then 'Master' when rollo_cortado = 1 then 'Rollo Cortado' when Graphics = 1 then 'Graphics' when Resmas = 1 then 'Resma' else 'sin tipo' end as tipo FROM producto";
                    public static string SQL_QUERY_SELECT_TYPE_PRODUCT = "SELECT MasterRolls,rollo_cortado,Resmas,Graphics FROM producto WHERE product_id=@p1";
                    public static string SQL_QUERY_SELECT_PRODUCT_NAME = "SELECT  Product_Name FROM producto WHERE product_id=@p1";
                    public static string SQL_QUERY_INSERT_PRODUCT = "INSERT INTO producto (Product_ID,Product_Name,Product_Descrip,Product_Ref,Codebar,Category_ID,MasterRolls,rollo_cortado,Resmas,Graphics,anulado,precio,code_RC) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13)";
                    public static string SQL_QUERY_UPDATE_PRODUCTS = "UPDATE producto SET Product_Name=@p2,Product_Descrip=@p3,Product_Ref=@p4,Codebar=@p5,Category_ID=@p6,Resmas=@p9,Graphics=@p10,anulado=@p11,precio=@p12 WHERE Product_ID=@p1";
                    public static string SQL_QUERY_COUNT_PRODUCTS = "SELECT count(*) FROM producto WHERE product_id=@p1";
                    public static string SQL_QUERY_CATEGORY_PRODUCTS = "select case when MasterRolls = 1 then 'Master' when rollo_cortado = 1 then 'Rollo Cortado' when Graphics = 1 then 'Graphics' when Resmas = 1 then 'Resma' else 'sin tipo' end from producto where Product_ID=@p1";
                }
                public class CUSTOMERS
                {
                    public static string SQL_SELECT_CUSTOMERS = "SELECT Customer_ID,Customer_Name,Customer_Category," +
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
                        "fecha_pro,master,resma,graphics,embarque,palet_num,palet_cant,palet_pag,num_sincro,registro_movil,disponible) " +
                        "VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14," +
                        "@p15,@p16,@p17,@p18,@p19,@p20,@p21,@p22,@p23)";
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
                    public static string SQL_QUERY_INSERT_DETAILS_OC = "INSERT rolls_details (numero,product_id,product_name,roll_number,unique_code,splice,width,large,msi,roll_id,code_person,status,disponible) " +
                        "VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13)";
                    public static string SQL_QUERY_SELECT_ROLLID = "SELECT a.roll_id,a.part_number,a.master,a.resma,a.graphics,b.product_name,a.width,a.lenght,disponible FROM OrdenRecepcion a LEFT JOIN producto b ON a.part_number = b.product_id where b.MasterRolls = 1 and a.disponible = 1";
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
                    public static string SQL_QUERY_UPDATE_ROLLSDETAILS_RENGLON = "UPDATE rolls_details SET splice=@p3,code_person=@p4,status=@p5,width=@p6,large=@p7,msi=@p8,roll_id=@p9 WHERE (numero=@p1 AND unique_code=@p2)";
                    public static string SQL_QUERY_SELECT_GETDATA_UNIQUE_CODE = "SELECT numero,product_id,product_name,roll_number,width,large,msi,splice,roll_id,code_person,status,unique_code FROM rolls_details WHERE unique_code=@p1";
                    public static string SQL_QUERY_SELECT_GETDATA_CODE_RC = "SELECT code_RC FROM producto WHERE product_id=@p1";
                    public static string SQL_QUERY_UPDATE_ROLLID_DISPONIBILIDAD = "UPDATE OrdenRecepcion SET disponible=0 WHERE Roll_Id=@p1";
                    public static string SQL_QUERY_SELECT_VERIFIFY_REPEAT_OC = "SELECT count(*) FROM orden_corte WHERE numero=@p1";


                }
                public class DESPACHOS
                {
                    public static string SQL_SELECT_DESPACHOS_HEADER = "SELECT numero,fecha,customer_id,person_contact,vendor_id,transport_id,chofer_id,placas_id,packing,orden_trabajo,orden_compra,subtotal,porc_itbis,itbis,total$rd FROM despacho";
                    public static string SQL_SELECT_DESPACHOS_DETAILS = "SELECT numero,product_id,cant,unid_id,width,lenght,msi,ratio,kilo_rollo,precio,total_renglon FROM item_despacho";
                    public static string SQL_SELECT_CUSTOMERS = "SELECT Customer_ID,Customer_Name,Customer_Category,Customer_Dir,Customer_Email,Anulado  FROM customer";
                    public static string SQL_SELECT_VENDEDORES = "SELECT vendor_id,vendor_name FROM vendedor";
                    public static string SQL_SELECT_TRANSPORTE = "SELECT transport_id,transport_name FROM transporte";
                    public static string SQL_SELECT_CHEFERES = "SELECT chofer_id,chofer_name FROM chofer";
                    public static string SQL_SELECT_CAMION = "SELECT placas_id,camion_name FROM camion";
                    public static string SQL_SELECT_PRODUCTOS = "SELECT product_id,product_name,masterRolls,Resmas,Graphics FROM producto";
                    public static string SQL_INSERT_HEADER_ORDEN_DESPACHO = "INSERT INTO despacho (numero,fecha,customer_id,person_contact,vendor_id,transport_id,chofer_id,placas_id,packing,orden_trabajo,orden_compra,subtotal,itbis,total$rd) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14)";
                    public static string SQL_INSERT_HEADER_DETAILS_DESPACHO = "INSERT INTO item_despacho (numero,product_id,cant,unid_id,width,lenght,msi,ratio,kilo_rollo,precio,total_renglon) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)";
                }
                public class INVENTARIO
                {
                    public static string SQL_INSERT_INVENTARIO_SAVE_INICIALES = "INSERT INTO iniciales (product_id,cantidad,width,lenght,msi,ubic,documento) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)";
                    public static string SQL_SELECT_INVENTARIO_INICIALES = "SELECT a.product_id,b.Product_Name,case when b.MasterRolls = 1 then 'Master' when b.rollo_cortado = 1 then 'Rollo Cortado' when b.Graphics = 1 then 'Graphics' when b.Resmas = 1 then 'Resma' else 'sin tipo' end as tipo,cantidad, width,lenght,msi,ubic,documento FROM iniciales a LEFT JOIN producto b ON a.product_id= b.Product_ID ";
                    public static string SQL_SELECT_INVENTARIO_QUERY_MASTER = "SELECT a.Product_ID,a.Product_Name,case when a.MasterRolls = 1 then 'Master' when a.rollo_cortado = 1 then 'Rollo Cortado' when a.Graphics = 1 then 'Graphics' when a.Resmas = 1 then 'Resma' else 'sin tipo' end as tipo,ISNULL((SELECT sum(cantidad) from iniciales b where a.Product_ID = b.product_id),0) as cant_ini,CASE WHEN a.MasterRolls=1 or a.Resmas=1 or a.Graphics= 1 THEN " +
                    "ISNULL((SELECT CASE WHEN b.master= 1 THEN count(*) ELSE SUM(b.palet_cant) END FROM OrdenRecepcion b where a.Product_ID = b.Part_Number GROUP BY b.Part_Number, b.master),0) ELSE ISNULL((select count(*) from rolls_details b where b.product_id = a.Product_ID group by b.product_id),0) END AS cant_ENT,CASE WHEN a.MasterRolls=1 THEN ISNULL((SELECT CASE WHEN b.master= 1 THEN COUNT(*) END FROM OrdenRecepcion b where a.Product_ID = b.Part_Number AND b.disponible= 0 " +
                    "GROUP BY b.Part_Number, b.master),0) WHEN a.Resmas=1 OR a.Graphics= 1 THEN ISNULL((SELECT sum(cant) from item_despacho b where a.Product_ID= b.product_id group by b.product_id),0)  WHEN a.rollo_cortado=1 THEN 0 END AS cant_sal FROM producto a";
                }
            }
        }
        public class ERROR_MESSAGES
        {
            public class INVENTARIO 
            {
                public static string MESSAGE_INSERT_INICIALES_ERROR = "Error al tratar de grabar la data de los iniciales.";
                public static string MESSAGE_SELECT_INICIALES_ERROR = "Error al de cargar la data de los iniciales.";
                public static string MESSAGE_CARGAR_INVENTARIO_ERROR = "ERROR AL CARGAR LOS INVENTARIO DEL SISTEMA.";

            }
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
                public static string MESSAGE_UPDATE_ERROR_UPDATE_ROLLID = "Error al actualizar la disponibilidad de los numeros ROLL ID.";
            }
            public class DESPACHOS
            {
                public static string MESSAGE_SELECT_ERROR_LOAD_PRODUCTS = "Error al tratar de cargar los productos.";
                public static string MESSAGE_SELECT_ERROR_LOAD_CHOFERES = "Error al tratar de cargar los choferes.";
                public static string MESSAGE_SELECT_ERROR_LOAD_CAMIONES = "Error al tratar de cargar los camiones.";
                public static string MESSAGE_SELECT_ERROR_LOAD_TRANSPORTE = "Error al tratar de cargar los transportes.";
                public static string MESSAGE_SELECT_ERROR_LOAD_VENDEDOR = "Error al tratar de cargar los vendedores.";
                public static string MESSAGE_SELECT_ERROR_LOAD_CUSTOMERS = "Error al tratar de cargar los clientes en el modulo de despacho.";
                public static string MESSAGE_SELECT_ERROR_LOAD_HEADER_DESPACHOS = "Error al tratar de cargar los encabezados de los despachos.";
                public static string MESSAGE_SELECT_ERROR_LOAD_DETAILS_DESPACHOS = "Error al tratar de cargar los detalle de los despachos.";
                public static string MESSAGE_INSERT_ERROR_ADD_HEADER_DESPACHOS = "Error al tratar de insertar el encabezado de despacho.";
                public static string MESSAGE_INSERT_ERROR_ADD_DETAILS_DESPACHOS = "Error al tratar de insertar el detalle en la orden de despacho.";
            }
        }
        public class PATH_FILES
        {
            public static string FILE_TXT_MATERIA_PRIMA = @"C:\Users\npino\Documents\RITRAMA\RitramaAPP\data\data.txt";
        }
    }
}
