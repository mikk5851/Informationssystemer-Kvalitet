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
                        Customer cus = CustomerRepository.GetCustomerRepository.GetCustomer(cusId);
                        Order order = new Order(cus, orderId, orderDate, deliveryDate, picked2);
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
                    Order order = new Order(default(Customer), 0, default(DateTime), default(DateTime), default(bool));
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
                        switch (product.status)
                        {
                            case Status.Nothing:
                                break;
                            case Status.Alter:
                                AlterProduct(product, connection);
                                break;
                            case Status.Create:
                                CreateProduct(product, connection);
                                break;
                            case Status.Delete:
                                DeleteProduct(product, connection);
                                break;
                            default:
                                throw new FormatException($"Unknown status {product.status}");
                        }
                    }
                }
                catch (SqlException e) { throw e; }

                try
                {
                    IEnumerator<Customer> enumerator = CustomerRepository.GetCustomerRepository.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        Customer cus = enumerator.Current;
                        switch (cus.status)
                        {
                            case Status.Nothing:
                                break;
                            case Status.Alter:
                                AlterCustomer(cus, connection);
                                break;
                            case Status.Create:
                                CreateCustomer(cus, connection);
                                break;
                            case Status.Delete:
                                DeleteCustomer(cus, connection);
                                break;
                            default:
                                throw new FormatException($"Unknown status {cus.status}");
                        }
                    }
                }
                catch (SqlException e) { throw e; }

                try
                {
                    IEnumerator<Order> enumerator = OrderRepository.GetOrderRepository.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        Order order = enumerator.Current;
                        switch (order.status)
                        {
                            case Status.Nothing:
                                break;
                            case Status.Alter:
                                AlterOrder(order, connection);
                                break;
                            case Status.Create:
                                CreateOrder(order, connection);
                                break;
                            case Status.Delete:
                                DeleteOrder(order, connection);
                                break;
                            default:
                                throw new FormatException($"Unknown status {order.status}");
                        }
                        IEnumerator<SaleOrderLine> enumerator2 = order.GetEnumerator();
                        while (enumerator2.MoveNext())
                        {
                            SaleOrderLine line = enumerator2.Current;
                            switch (line.status)
                            {
                                case Status.Nothing:
                                    break;
                                case Status.Alter:
                                    AlterSaleOrderLine(line, connection);
                                    break;
                                case Status.Create:
                                    CreateSaleOrderLine(line, connection);
                                    break;
                                case Status.Delete:
                                    DeleteSaleOrderLine(line, connection);
                                    break;
                                default:
                                    throw new FormatException($"Unknown status {line.status}");
                            }
                        }
                    }
                }
                catch (SqlException e) { throw e; }
            }
        }

        private void AlterProduct(Product product, SqlConnection connection)
        {

        }

        private void CreateProduct(Product product, SqlConnection connection)
        {

        }

        private void DeleteProduct(Product product, SqlConnection connection)
        {

        }

        private void AlterOrder(Order order, SqlConnection connection)
        {

        }

        private void CreateOrder(Order order, SqlConnection connection)
        {

        }

        private void DeleteOrder(Order order, SqlConnection connection)
        {

        }

        private void AlterCustomer(Customer customer, SqlConnection connection)
        {

        }

        private void CreateCustomer(Customer customer, SqlConnection connection)
        {

        }

        private void DeleteCustomer(Customer customer, SqlConnection connection)
        {

        }

        private void AlterSaleOrderLine(SaleOrderLine line, SqlConnection connection)
        {

        }

        private void CreateSaleOrderLine(SaleOrderLine line, SqlConnection connection)
        {

        }

        private void DeleteSaleOrderLine(SaleOrderLine line, SqlConnection connection)
        {

        }
    }
}
