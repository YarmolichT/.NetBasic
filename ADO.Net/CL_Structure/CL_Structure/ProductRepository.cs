using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CL_Structure
{
    public class ProductRepository<T> : IRepository<T> where T : ProductEntity
    {
        private readonly static string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SQL_Project;Integrated Security=True";
        private SqlConnection _sqlConnection;
        private SqlDataAdapter _dataAdapter;
        private SqlCommandBuilder _commandBuilder;
        private DataSet _dataSet;
        private const string TableName = "Product";

        private void FetchData()
        {
            _sqlConnection = new SqlConnection(_connectionString);
            _sqlConnection.Open();
            _dataAdapter = new SqlDataAdapter($"SELECT * FROM {TableName}", _sqlConnection);
            _commandBuilder = new SqlCommandBuilder(_dataAdapter);
            _dataSet = new DataSet();
            _dataAdapter.Fill(_dataSet, TableName);
        }

        public void InsertItem(T item)
        {
            FetchData();

            var dataRow = _dataSet.Tables[TableName].NewRow();

            dataRow[0] = item.Product_Id;
            dataRow[1] = item.Name;
            dataRow[2] = item.Description;
            dataRow[3] = item.Weight;
            dataRow[4] = item.Height;
            dataRow[5] = item.Width; 
            dataRow[6] = item.Length;

            _dataSet.Tables[TableName].Rows.Add(dataRow);

            _commandBuilder.GetInsertCommand();

            _dataAdapter.Update(_dataSet, TableName);

            _sqlConnection.Close();
        }

        public T SelectItemById(int itemId)
        {
            FetchData();
            ProductEntity product = null;

            foreach (DataRow dataRow in _dataSet.Tables[TableName].Rows)
            {
                var id = dataRow[0] == null ? 0 : Convert.ToInt32(dataRow[0]);

                if (id == itemId)
                {
                    product = ConvertToProductEntity(dataRow.ItemArray);
                }
            }

            _sqlConnection.Close();

            return (T)product;
        }

        private ProductEntity ConvertToProductEntity(object[] item)
        {
            var product = new ProductEntity()
            {
                Product_Id = item[0] == null ? 0 : Convert.ToInt32(item[0]),
                Name = item[1].ToString(),
                Description = item[2].ToString(),
                Height = item[3] == DBNull.Value ? 0 : Convert.ToInt32(item[3]),
                Weight = item[4] == DBNull.Value ? 0 : Convert.ToInt32(item[4]),
                Width  = item[5] == DBNull.Value ? 0 : Convert.ToInt32(item[5]),
                Length = item[6] == DBNull.Value ? 0 : Convert.ToInt32(item[6]),
            };

            return product;
        }

        public void UpdateItem(T item)
        {
            FetchData();

            foreach (DataRow dataRow in _dataSet.Tables[TableName].Rows)
            {
                var itemId = dataRow[0] == null ? 0 : Convert.ToInt32(dataRow[0]);

                if (item.Product_Id == itemId)
                {
                    dataRow[1] = item.Name;
                    dataRow[2] = item.Description;
                    dataRow[3] = item.Height;
                    dataRow[4] = item.Weight;
                    dataRow[5] = item.Width; 
                    dataRow[6] = item.Length;
                }
            }

            _commandBuilder.GetUpdateCommand();

            _dataAdapter.Update(_dataSet, TableName);

            _sqlConnection.Close();
        }

        public void DeleteItem(int itemId)
        {
            FetchData();

            foreach (DataRow dataRow in _dataSet.Tables[TableName].Rows)
            {
                var Id = dataRow[0] == null ? 0 : Convert.ToInt32(dataRow[0]);

                if (itemId == Id) 
                { 
                    dataRow.Delete();
                    break;                
                }
            }

            _commandBuilder.GetDeleteCommand();

            _dataAdapter.Update(_dataSet, TableName);

            _sqlConnection.Close();
        }

        public List<T> SelectAll()
        {
            FetchData();

            var productList = new List<T>();

            foreach (DataRow dataRow in _dataSet.Tables[0].Rows)
            {
                var product = ConvertToProductEntity(dataRow.ItemArray);
                productList.Add((T)product);
            }

            _sqlConnection.Close();

            return productList;
        }
    }
}
