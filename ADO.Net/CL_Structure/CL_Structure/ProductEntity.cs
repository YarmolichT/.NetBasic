using System.Text;

namespace CL_Structure
{
    public class ProductEntity
    {   
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
