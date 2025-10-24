using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCrud.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public Manufacturer Manufacturer { get; private set; }
        public string Name { get; private set; }
        public DateTime ProduceDate { get; private set; }
        public bool IsAvailable => Quantity > 0;
        public int Quantity { get; private set; }

        private Product() { }

        private Product(
            Manufacturer manufacture,
            string name,
            DateTime produceDate,
            int quantity)
        {
            Id = Guid.NewGuid();
            Manufacturer = manufacture;
            Name = name;
            ProduceDate = produceDate;
            Quantity = quantity;
        }

        public static Product Create(string name, DateTime produceDate, Manufacturer manufacturer, int quantity = 0)
        {
            if (manufacturer == null) throw new ArgumentNullException(nameof(manufacturer));

            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            if (produceDate == default) throw new ArgumentNullException(nameof(produceDate));

            if (quantity < 0 ) throw new ArgumentOutOfRangeException(nameof(quantity));

            return new Product(
                manufacturer,
                name.Trim(),
                produceDate,
                quantity
            );
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(Name));
            Name = name.Trim();
        }

        public void SetManufacturer(Manufacturer manufacturer)
        {
            if (manufacturer == null) throw new ArgumentNullException(nameof(Manufacturer));
            Manufacturer = manufacturer;
        }

        public void SetProduceDate(DateTime produceDate)
        {
            if (produceDate == default) throw new ArgumentNullException(nameof(produceDate));
            ProduceDate = produceDate;
        }

        public void IncreaseStock(int amount)
        {
            if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));
            Quantity += amount;
        }

        public void DecreaseStock(int amount)
        {
            if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));
            if (Quantity - amount < 0) throw new InvalidOperationException("Insufficient stock.");
            Quantity -= amount;
        }
    }
}
