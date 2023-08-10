using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Order
    {
        public int Orderd_Id { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int Product_Id { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Order:");
            sb.AppendLine($"Id: {Orderd_Id}");
            sb.AppendLine($"Status: {Status}");
            sb.AppendLine($"Created Date: {CreatedDate}");
            sb.AppendLine($"Updated Date: {UpdatedDate}");
            sb.AppendLine($"Product Id: {Product_Id}");

            return sb.ToString();
        }
    }
}
