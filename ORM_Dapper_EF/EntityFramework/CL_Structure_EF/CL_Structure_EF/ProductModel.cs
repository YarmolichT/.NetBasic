using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_Structure_EF
{
    [Table("Product")]
    public class ProductModel
    {
        [Key]
        public int Product_Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Weight { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public int Length { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Product:");
            sb.AppendLine($"Id: {Product_Id}");
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Description: {Description}");
            sb.AppendLine($"Weight: {Weight}");
            sb.AppendLine($"Height: {Height}");
            sb.AppendLine($"Width: {Width}");
            sb.AppendLine($"Length: {Length}");

            return sb.ToString();
        }
    }
}
