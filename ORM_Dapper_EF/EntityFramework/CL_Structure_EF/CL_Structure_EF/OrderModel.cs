using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CL_Structure_EF
{
    [Table("Orders")]
    public class OrderModel
    {
        [Key]
        public int Orderd_Id { get; set; }

        public int Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int Product_Id { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Order:");
            sb.AppendLine($"Order id: {Orderd_Id}");
            sb.AppendLine($"Status: {Status}");
            sb.AppendLine($"Created date: {CreatedDate}");
            sb.AppendLine($"Updated date: {UpdatedDate}");
            sb.AppendLine($"Product id: {Product_Id}");

            return sb.ToString();
        }
    }
}