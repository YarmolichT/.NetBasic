using Microsoft.EntityFrameworkCore;

namespace CL_Structure_EF
{
    public class OrderRepository
    {
        private ApplicationContext _context;

        public OrderRepository()
        {
            _context = new ApplicationContext();
        }

        public void Create(OrderModel item)
        {
            _context.Orders.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Orders.Remove(new OrderModel() { Orderd_Id = id });
            _context.SaveChanges();
        }

        public OrderModel Get(int id)
        {
            return _context.Orders.Where(x => x.Orderd_Id == id).FirstOrDefault();
        }

        public List<OrderModel> GetItems()
        {
            return _context.Orders.ToList();
        }

        public void Update(OrderModel item)
        {
            _context.Orders.Update(item);
            _context.SaveChanges();
        }

        public List<OrderModel> SelectByFilter(string filterName, int value)
        {
            switch (filterName.ToUpper())
            {
                case "STATUS":
                    return ReturnProcedureResult("SelectByStatus", value);
                case "PRODUCT":
                    return ReturnProcedureResult("SelectByProductId", value);
                case "MONTH":
                    return ReturnProcedureResult("SelectByMonth", value);
                case "YEAR":
                    return ReturnProcedureResult("SelectByYear", value);
                default:
                    return new List<OrderModel>();
            }
        }

        private List<OrderModel> ReturnProcedureResult(string procedureName, int value)
        {
            return _context.Orders.FromSql($"{procedureName} {value}").ToList();
        }

        public void DeleteBulk(string arg, int value)
        {
            switch (arg.ToUpper())
            {
                case "STATUS":
                    BulkDeleteTransaction("BulkDeleteByStatus", value);
                    break;
                case "PRODUCT":
                    BulkDeleteTransaction("BulkDeleteByProductId", value);
                    break;
                case "MONTH":
                    BulkDeleteTransaction("BulkDeleteByMonth", value);
                    break;
                case "YEAR":
                    BulkDeleteTransaction("BulkDeleteByYear", value);
                    break;
            }
        }

        private void BulkDeleteTransaction(string procedureName, int value)
        {
            _context.Orders.FromSql($"{procedureName} {value}");
            _context.SaveChanges();
        }
    }
}
