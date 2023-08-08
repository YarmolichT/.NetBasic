using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CL_Structure
{
    public class OrderRepository<T> : IRepository<T> where T : OrderEntity
    {
        private readonly static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SQL_Project;Integrated Security=True";
        private readonly SqlConnection _sqlConnection = new SqlConnection(connectionString);

        private void CallQuery(string query)
        {
            _sqlConnection.Open();
            var command = new SqlCommand(query, _sqlConnection);
            command.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public void InsertItem(T item)
        {
            var query = "INSERT INTO dbo.Orders " +                      
                        $"VALUES ({Convert.ToInt32(item.Status)}, '{item.CreatedDate}', '{item.UpdatedDate}', {item.Product_Id})";

            CallQuery(query);
        }

        public T SelectItemById(int itemId)
        {
            var query = "SELECT * FROM dbo.Orders " +
                        $"WHERE Orderd_Id = {itemId}";

            _sqlConnection.Open();
            var command = new SqlCommand(query, _sqlConnection);

            var dataReader = command.ExecuteReader();
            OrderEntity order = null;

            if (dataReader.Read())
            {
                order = new OrderEntity()
                {
                    Orderd_Id = (int)dataReader[0],
                    Status = (Status)Convert.ToInt32(dataReader[1]),
                    CreatedDate = Convert.ToDateTime(dataReader[2].ToString()),
                    UpdatedDate = Convert.ToDateTime(dataReader[3]),
                    Product_Id = Convert.ToInt32(dataReader[4])
                };
            }

            _sqlConnection.Close();

            return (T)order;
        }

        public List<T> SelectAll()
        {
            var query = "SELECT * " +
                        "FROM dbo.Orders";

            var command = new SqlCommand(query, _sqlConnection);
            _sqlConnection.Open();

            return ReturnDataReaderResult(command);
        }

        private List<T> ReturnDataReaderResult(SqlCommand command)
        {
            var ordersList = new List<T>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var item = new[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString()
                    };

                    var product = ConvertToEntities(item);
                    ordersList.Add((T)product);
                }
            }

            _sqlConnection.Close();

            return ordersList;
        }

        private static T ConvertToEntities(string[] inputList)
        {
            var order = new OrderEntity()
            {
                Orderd_Id = inputList[0] == null ? 0 : Convert.ToInt32(inputList[0]),
                Status = inputList[1] == null || inputList[1] == string.Empty ? 0 : (Status)Convert.ToInt32(inputList[1]),
                CreatedDate = Convert.ToDateTime(inputList[2]),
                UpdatedDate = Convert.ToDateTime(inputList[3]),
                Product_Id = Convert.ToInt32(inputList[4])
            };

            return (T)order;
        }

        public void UpdateItem(T item)
        {
            var query = "UPDATE dbo.Orders " +
                        $"SET Status = {Convert.ToInt32(item.Status)}, UpdatedDate = '{item.UpdatedDate}', Product_Id = {item.Product_Id} " +
                        $"WHERE Orderd_Id = {item.Orderd_Id}";

            CallQuery(query);
        }

        public void DeleteItem(int itemId)
        {
            var query = "DELETE FROM dbo.Orders " +
                        $"WHERE Orderd_Id = {itemId}";

            CallQuery(query);
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
            var command = ReturnSpCommand(procedureName, parameterName, value);

            _sqlConnection.Open();

            return ReturnDataReaderResult(command);
        }

        private SqlCommand ReturnSpCommand(string procedureName, string parameterName, int value)
        {
            return new SqlCommand
            {
                CommandText = procedureName,
                Connection = _sqlConnection,
                CommandType = CommandType.StoredProcedure,
                Parameters = {  new SqlParameter
                {
                    ParameterName = parameterName,
                    Value = value,
                    Direction = ParameterDirection.Input
                }}
            };
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

            var command = ReturnSpCommand(procedureName, parameterName, value);

            _sqlConnection.Open();

            var transaction = _sqlConnection.BeginTransaction();
            command.Transaction = transaction;

            try
            {
                command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
            }

            _sqlConnection.Close();
        }
    }
}
