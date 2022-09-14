using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

// namespace acceso sql server
using System.Data.SqlClient;    //  sql server
using System.Data;              // datos generales
using System.Configuration;     // archivos de conf
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Drawing;
using System.IO;
using System.Net;
using System.Security.Policy;

namespace WebNorthwind
{
    /// <summary>
    /// Descripción breve de WSNorthwind
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSNorthwind : System.Web.Services.WebService
    {
        private static string cadenaconexion = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;

        // TEST METHODS
        /*
        public Image ImageTest()
        {
            try
            {
                string consulta = "select Picture from Categories where CategoryID = 1";
                SqlCommand command = new SqlCommand(consulta, conexion);
                conexion.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    byte[] byteData = (byte[])reader[0];

                    Image x = (Bitmap)((new ImageConverter()).ConvertFrom(byteData));
                    //string strData = Encoding.UTF8.GetString(byteData);
                    //MemoryStream ms = new MemoryStream(byteData);
                    //Image ret = Image.FromStream(ms);
                    return x;
                }
                else return null;
            }
            catch(SqlException e)
            {
                return null;
            }
            
        }
        */
        //=====================================================
        #region CATEGORIES METHODS
        [WebMethod(Description ="Listar Categorias")]
        public DataSet ListarCategorias()
        {
            using (SqlConnection conexion = new SqlConnection(cadenaconexion))
            {
                string consulta = "select * from Categories";
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);
                DataSet data = new DataSet();
                adapter.Fill(data);
                return data;
            }
                
        }
        [WebMethod(Description ="Agregar Categoria")]
        public void AgregarCategoria()
        {
            
        }
        [WebMethod(Description = "Actualizar Categoria")]
        public void ActualizarCategoria()
        {

        }
        [WebMethod(Description = "Eliminar Categoria")]
        public void EliminarCategoria()
        {

        }
        #endregion
        //=====================================================
        #region SUPPLIER METHODS
        [WebMethod(Description = "Listar Suppliers")]
        public DataSet ListarSuppliers()
        {
            using (SqlConnection conexion = new SqlConnection(cadenaconexion))
            {
                string consulta = "select * from Suppliers";
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);
                DataSet data = new DataSet();
                adapter.Fill(data);
                return data;
            }
        }
        [WebMethod(Description = "Agregar Suppliers")]
        public String AgregarSuppliers(String CompanyName, String ContactName = null, String ContactTitle = null, String Address = null, String City = null, String Region = null, String PostalCode = null, String Country = null,String Phone = null, String Fax = null, String HomePage = null)
        {
            string[] parametros_values = {
                CompanyName, 
                ContactName, 
                ContactTitle, 
                Address, 
                City, 
                Region, 
                PostalCode, 
                Country,
                Phone,
                Fax, 
                HomePage};
            string[] parametros_names = {
                nameof(CompanyName),
                nameof(ContactName),
                nameof(ContactTitle),
                nameof(Address),
                nameof(City),
                nameof(Region),
                nameof(PostalCode),
                nameof(Country),
                nameof(Phone),
                nameof(Fax),
                nameof(HomePage) };
            return Agregar(parametros_values, parametros_names, "Suppliers");
        }
        [WebMethod(Description = "Actualizar Suppliers")]
        public String ActualizarSuppliers(String SupplierID, String CompanyName = null, String ContactName = null, String ContactTitle = null, String Address = null, String City = null, String Region = null, String Country = null, String PostalCode = null, String Phone = null, String Fax = null, String HomePage = null)
        {
            string[] parametros_values = {
                CompanyName,
                ContactName,
                ContactTitle,
                Address,
                City,
                Region,
                PostalCode,
                Country,
                Phone,
                Fax,
                HomePage};
            string[] parametros_names = {
                nameof(CompanyName),
                nameof(ContactName),
                nameof(ContactTitle),
                nameof(Address),
                nameof(City),
                nameof(Region),
                nameof(PostalCode),
                nameof(Country),
                nameof(Phone),
                nameof(Fax),
                nameof(HomePage) 
            };
            return Actualizar(parametros_values, parametros_names, "Suppliers", nameof(SupplierID), SupplierID);
        }
        [WebMethod(Description = "Eliminar Suppliers")]
        public String EliminarSuppliers(String SupplierID)
        {
            if (!SupplierID.Equals(""))
            {
                bool result = Eliminar("delete from Suppliers where SupplierID = " + SupplierID);
                if (result)
                    return "Eliminado";
                else return "Error";
            }
            else return "SupplierID Invalido o no existe.";
        }
        #endregion
        //=====================================================
        #region PRODUCTS METHODS
        [WebMethod(Description = "Listar Products")]
        public DataSet ListarProducts()
        {
            using (SqlConnection conexion = new SqlConnection(cadenaconexion))
            {
                string consulta = "select * from Products";
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);
                DataSet data = new DataSet();
                adapter.Fill(data);
                return data;
            }
        }
        [WebMethod(Description = "Agregar Products")]
        public String AgregarProducts(String ProductName = null, String SupplierID = null, String CategoryID = null, String QuantityPerUnit = null, String UnitPrice = null, String UnitsInStock = null, String UnitsOnOrder=null, String ReorderLevel=null, String Discontinued = null)
        {
            String[] parametros_values =
            {
                ProductName,
                SupplierID,
                CategoryID,
                QuantityPerUnit, 
                UnitPrice, 
                UnitsInStock, 
                UnitsOnOrder, 
                ReorderLevel, 
                Discontinued
            };
            String[] parametros_names =
            {
                nameof(ProductName),
                nameof(SupplierID),
                nameof(CategoryID),
                nameof(QuantityPerUnit),
                nameof(UnitPrice),
                nameof(UnitsInStock),
                nameof(UnitsOnOrder),
                nameof(ReorderLevel),
                nameof(Discontinued)
            };
            return Agregar(parametros_values, parametros_names, "Products");
        }
        [WebMethod(Description = "Actualizar Products")]
        public String ActualizarProducts(String ProductID, String ProductName = null, String SupplierID = null, String CategoryID = null, String QuantityPerUnit = null, String UnitPrice = null, String UnitsInStock = null, String UnitsOnOrder = null, String ReorderLevel = null, String Discontinued = null)
        {
            string[] parametros_values = {
                ProductName,
                SupplierID,
                CategoryID,
                QuantityPerUnit,
                UnitPrice,
                UnitsInStock,
                UnitsOnOrder,
                ReorderLevel,
                Discontinued
            };
            string[] parametros_names = {
                nameof(ProductName),
                nameof(SupplierID),
                nameof(CategoryID),
                nameof(QuantityPerUnit),
                nameof(UnitPrice),
                nameof(UnitsInStock),
                nameof(UnitsOnOrder),
                nameof(ReorderLevel),
                nameof(Discontinued) 
            };
            return Actualizar(parametros_values, parametros_names, "Products", nameof(ProductID), ProductID);
        }
        [WebMethod(Description = "Eliminar Products")]
        public String EliminarProducts(String ProductID)
        {
            if (!ProductID.Equals(""))
            {
                bool result = Eliminar("delete from Products where ProductID = " + ProductID);
                if (result)
                    return "Eliminado";
                else return "Error";
            }
            else return "ProductID Invalido o no existe.";
        }
        #endregion
        //=====================================================
        #region SHIPPERS METHODS
        [WebMethod(Description = "Listar Shippers")]
        public DataSet ListarShippers()
        {
            using (SqlConnection conexion = new SqlConnection(cadenaconexion))
            {
                string consulta = "select * from Shippers";
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);
                DataSet data = new DataSet();
                adapter.Fill(data);
                return data;
            }
        }
        [WebMethod(Description = "Agregar Shippers")]
        public String AgregarShippers(String CompanyName = null, String Phone = null)
        {
            String[] parametros_values =
            {
                CompanyName,
                Phone
            };
            String[] parametros_names =
            {
                nameof(CompanyName),
                nameof(Phone)
            };
            return Agregar(parametros_values, parametros_names, "Shippers");
        }
        [WebMethod(Description = "Actualizar Shippers")]
        public String ActualizarShippers(String ShipperID,String CompanyName = null, String Phone = null)
        {
            String[] parametros_values =
            {
                CompanyName,
                Phone
            };
            String[] parametros_names =
            {
                nameof(CompanyName),
                nameof(Phone)
            };
            return Actualizar(parametros_values, parametros_names, "Shippers", nameof(ShipperID), ShipperID);
        }
        [WebMethod(Description = "Eliminar Shippers")]
        public String EliminarShippers(String ShipperID)
        {
            if (!ShipperID.Equals(""))
            {
                bool result = Eliminar("delete from Shippers where ShipperID = " + ShipperID);
                if (result)
                    return "Eliminado";
                else return "Error";
            }
            else return "ProductID Invalido o no existe.";
        }
        #endregion

        #region Avoid Spaguetti
        private bool Eliminar(String cadena)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaconexion))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conexion;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = cadena;

                    try
                    {
                        conexion.Open();
                        byte i = Convert.ToByte(cmd.ExecuteNonQuery());
                        if (i == 1) return true;
                        else return false;
                    }
                    catch (SqlException e)
                    {
                        return false;
                    }
                }
            }
        }
        
        private String Agregar(String[] parametros_values, String[] parametros_names, String tableName)
        {
            List<String> parametros_agregados = new List<String>();
            List<String> parametros_names_agregados = new List<string>();
            for (int i = 0; i < parametros_values.Length; i++)
            {
                if (!parametros_values[i].Equals(""))
                {
                    parametros_agregados.Add(parametros_values[i]);
                    parametros_names_agregados.Add(parametros_names[i]);
                }
            }
            String parametros = "";
            String values = "";

            for (int i = 0; i < parametros_agregados.Count; i++)
            {
                if (i == parametros_agregados.Count - 1)
                {
                    parametros += parametros_names_agregados[i];
                    values += "'" + parametros_agregados[i] + "'";
                }
                else
                {
                    parametros += parametros_names_agregados[i] + ",";
                    values += "'" + parametros_agregados[i] + "',";
                }
            }
            using (SqlConnection conexion = new SqlConnection(cadenaconexion))
            {

                string cadena = "insert into "+tableName+"(" + parametros + ") values(" + values + ")";

                using (SqlCommand cmd = new SqlCommand(cadena, conexion))
                {
                    Console.WriteLine(cadena);
                    try
                    {
                        conexion.Open();
                        cmd.ExecuteNonQuery();
                        conexion.Close();
                        return "Agregado";

                    }
                    catch (SqlException e)
                    {
                        conexion.Close();
                        return "Error al insertar: " + cadena;
                    }
                }
            }
        }
        
        private String Actualizar(String[] parametros_values, String[] parametros_names, String tableName, String ValueName, String ValueUpdate)
        {
            List<String> parametros_agregados = new List<string>();
            for (int i = 0; i < parametros_values.Length; i++)
            {
                if (!parametros_values[i].Equals(""))
                {
                    parametros_agregados.Add(parametros_values[i]);
                }
            }

            String updates = "";

            for (int i = 0; i < parametros_agregados.Count; i++)
            {
                if (i == parametros_agregados.Count - 1)
                {
                    updates += parametros_names[i] + "='" + parametros_agregados[i] + "'";
                }
                else
                {
                    updates += parametros_names[i] + "='" + parametros_agregados[i] + "',";
                }
            }
            using (SqlConnection conexion = new SqlConnection(cadenaconexion))
            {
                string cadena = "update "+ tableName + " set " + updates + " where "+ ValueName + " = " + ValueUpdate;
                using (SqlCommand cmd = new SqlCommand(cadena, conexion))
                {
                    try
                    {
                        conexion.Open();
                        cmd.ExecuteNonQuery();
                        conexion.Close();

                        return "Actualizado";
                    }
                    catch (SqlException e)
                    {
                        conexion.Close();

                        return "Error al Actualizar: " + cadena;
                    }
                }
            }
        }
        #endregion
    }
}
