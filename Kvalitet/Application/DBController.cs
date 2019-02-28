using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Data.SqlClient;

namespace Application
{
    public class DBController
    {
        public static readonly DBController GetDBController;
        private readonly string ConnectionString;

        static DBController()
        {
            GetDBController = new DBController();
        }
        private DBController()
        {
            StreamReader streamReader = new StreamReader("ConnectionString.txt");
            ConnectionString = streamReader.ReadLine();
        }

        public void StartUp()
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("[SP_GetCustomers]", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = (int)reader["[CustomerID]"];
                        string name = (string)reader["[Name]"];
                        string address = (string)reader["[Address]"];
                        int zip = (int)reader["[ZipCode]"];
                        string city = (string)reader["[City]"];
                        int tele = (int)reader["[Telephone]"];
                        Customer customer = new Customer(id, name, address, zip, city, tele);
                        CustomerRepository.GetCustomerRepository.AddCustomer(customer);
                    }
                    reader.Close();
                }
                catch (SqlException e) { throw e; }

                try
                {
                    SqlCommand cmd = new SqlCommand("[SP_GetOrders]", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int cusId = (int)reader["[CustomerID]"];
                        int orderId = (int)reader["[OrderNumber]"];
                        DateTime orderDate = (DateTime)reader["[OrderDate]"];
                        DateTime deliveryDate = (DateTime)reader["[DeliveryDate]"];
                        int picked1 = (int)reader["[Picked]"];
                        bool picked2;
                        if(picked1 == 0) { picked2 = false; }
                        else { picked2 = true; }
                        Order order = new Order(cusId, orderId, orderDate, deliveryDate, picked2);
                        OrderRepository.GetOrderRepository.AddOrder(order);
                    }
                    reader.Close();
                }
                catch (SqlException e) { throw e; }

                try
                {
                    SqlCommand cmd = new SqlCommand("[SP_GetProducts]", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int barcode = (int)reader["[BarCode]"];
                        string name = (string)reader["[Name]"];
                        string description = (string)reader["[Description]"];
                        double price = (double)reader["[price]"];
                        int min = (int)reader["[MinInStock]"];
                        Product product = new Product(barcode, name, description, price, min);
                        ProductRepository.GetProductRepository.AddProduct(product);
                    }
                    reader.Close();
                }
                catch (SqlException e) { throw e; }

                try
                {
                    SqlCommand cmd = new SqlCommand("[SP_GetOrderLines]", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    Order order = new Order(0);
                    while (reader.Read())
                    {
                        int orderID = (int)reader["[OrderNumber]"];
                        int quantity = (int)reader["[Quantity]"];
                        double price = (double)reader["[Price]"];
                        int productID = (int)reader["[ProductID]"];
                        if(orderID != order.OrderID)
                        {
                            order = OrderRepository.GetOrderRepository.GetOrder(orderID);
                        }
                        Product product = ProductRepository.GetProductRepository.GetProduct(productID);
                        order.AddOrderLine(product, quantity, price);
                    }
                    reader.Close();
                }
                catch (SqlException e) { throw e; }
                connection.Close();
            }
        }

        public void UpdateDB()
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                try
                {
                    IEnumerator<Product> enumerator = ProductRepository.GetProductRepository.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        Product product = enumerator.Current;

                    }
                }
                catch (SqlException e) { throw e; }

            }
        }

        private void AlterProduct(Product product)
        {

        }

        private void CreateProduct(Product product)
        {

        }

        private void DeleteProduct(Product product)
        {

        }

        private void AlterOrder(Order order)
        {

        }

        private void CreateOrder(Order order)
        {

        }

        private void DeleteOrder(Order order)
        {

        }

        private void AlterCustomer(Customer customer)
        {

        }

        private void CreateCustomer(Customer customer)
        {

        }

        private void DeleteCustomer(Customer customer)
        {

        }
    }
}
