using System;
using System.Text;

namespace CL_Structure
{
    /*public class Model1 : DbContext
    {
        // Контекст настроен для использования строки подключения "Model1" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "CL_Structure.Model1" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "Model1" 
        // в файле конфигурации приложения.
        public Model1()
            : base("name=Model1")
        {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }*/

    public class OrderEntity
    {
        public int Orderd_Id { get; set; }
        public Enum Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set;}
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