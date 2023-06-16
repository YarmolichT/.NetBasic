using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppReflection
{
    public interface IProvider
    {
        public string GetValue(string key);
        public void SetValue(string key, string value);
        public void SaveChanges();
    }
}
