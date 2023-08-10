using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ClassLibrary1
{
    public class OrderRepository<T> : IRepository<T> where T : Order
    {
        private readonly static string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SQL_Project;Integrated Security=True";

        public void InsertItem(T item)
        {  
            IDbConnection dbConnection = new SqlConnection(_connectionString);

            var query = "INSERT INTO dbo.Orders " +
                        $"VALUES (@Status, @CreatedDate, @UpdatedDate, @Product_Id)";

            dbConnection.Execute(query, item);
        }

        public void DeleteItem(int id)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);

            var query = "DELETE FROM dbo.Orders " +
                        $"WHERE Orderd_Id = @Orderd_Id";

            dbConnection.Query<T>(query, new { Orderd_Id = id });
        }

        public T SelectItemById(int id)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);

            var query = "SELECT Orderd_Id AS Orderd_Id, Status, CreatedDate, UpdatedDate, Product_Id AS Product_Id " +
                        "FROM Orders " +
                        "WHERE Orderd_Id = @Orderd_Id";

            return dbConnection.Query<T>(query, new { Orderd_Id = id }).FirstOrDefault();
        }

        public List<T> SelectAll()
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);

            var query = "SELECT Orderd_Id AS Orderd_Id, Status, CreatedDate, UpdatedDate, Product_Id AS Product_Id FROM Orders";

            return dbConnection.Query<T>(query).ToList();
        }


        public void UpdateItem(T item)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);

            var query = "Update Orders " +
                        "SET Status = @Status, UpdatedDate = @UpdatedDate, Product_Id = @Product_Id " +
                        "WHERE Orderd_Id = @Orderd_Id";

            dbConnection.Execute(query, item);
        }

        public List<T> SelectByFilter(string filterName, int value)
        {
            switch (filterName.ToUpper())
            {
                case "STATUS":
                    return ReturnProcedureResult("SelectByStatus", "@status", value);
                case "PRODUCT":
                    return ReturnProcedureResult("SelectByProductId", "@product_id", value);
                case "MONTH":
                    return ReturnProcedureResult("SelectByMonth", "@month", value);
                case "YEAR":
                    return ReturnProcedureResult("SelectByYear", "@year", value);
                default:
                    return new List<T>();
            }
        }

        private List<T> ReturnProcedureResult(string procedureName, string parameterName, int value)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);

            var parameters = new DynamicParameters();
            parameters.Add(parameterName, value);

            return dbConnection.Query<T>(procedureName, parameters, commandType: CommandType.StoredProcedure).ToList();
        }

        public void DeleteBulk(string arg, int value)
        {
            switch (arg.ToUpper())
            {
                case "STATUS":
                    BulkDeleteTransaction("BulkDeleteByStatus", "@status", value);
                    break;
                case "PRODUCT":
                    BulkDeleteTransaction("BulkDeleteByProductId", "@product_id", value);
                    break;
                case "MONTH":
                    BulkDeleteTransaction("BulkDeleteByMonth", "@month", value);
                    break;
                case "YEAR":
                    BulkDeleteTransaction("BulkDeleteByYear", "@year", value);
                    break;
            }
        }

        private void BulkDeleteTransaction(string procedureName, string parameterName, int value)
         {
            IDbConnection dbConnection = new SqlConnection(_connectionString);

            var parameters = new DynamicParameters();
            parameters.Add(parameterName, value);

            dbConnection.Query<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);

        }
    }
}
