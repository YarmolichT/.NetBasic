using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ClassLibrary1
{
    public class ProductRepository<T> : IRepository<T> where T : Product
    {
        private readonly static string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SQL_Project;Integrated Security=True";

        public void InsertItem(T item)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);

            var query = "INSERT INTO Product " +
                        "VALUES (@Name, @Description, @Weight, @Height, @Width, @Length)";

            dbConnection.Execute(query, item);
        }

        public void DeleteItem(int id)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);

            var query = "DELETE FROM Product WHERE Product_Id = @ProductId";

            dbConnection.Query<T>(query, new { ProductId = id });
        }

        public T SelectItemById(int id)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);

            var query = "SELECT Product_Id AS Product_Id, name, description, weight, height, width, length FROM Product WHERE Product_Id = @product_id";

            return dbConnection.Query<T>(query, new { Product_Id = id }).FirstOrDefault();
        }

        public void UpdateItem(T item)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);

            var query = "Update Product " +
                        "SET name = @Name, description = @Description, weight = @Weight, height = @Height, width = @Width, length = @Length " +
                        "WHERE Product_Id = @Product_Id";

            dbConnection.Execute(query, item);
        }

        public List<T> SelectAll()
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);

            var query = "SELECT Product_Id AS Product_Id, name, description, weight, height, width, length FROM Product";

            return dbConnection.Query<T>(query).ToList();
        }
    }
}
