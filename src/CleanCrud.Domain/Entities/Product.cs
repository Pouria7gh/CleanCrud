using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCrud.Domain.Entities
{
    public class Product
    {
        public string Name { get; set; }
        public string ProduceDate { get; set; }
        public string ManufacturePhone { get; set; }
        public DateTime ManufactureEmail { get; set; }
        public bool IsAvailable { get; set; }
    }
}
