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
        public Manufacture Manufacturer { get; private set; }
        public string Name { get; private set; }
        public DateTime ProduceDate { get; private set; }
        public bool IsAvailable { get; private set; }
        public Guid CreatedById { get; private set; }
        public int Quantity { get; private set; }

        private Product() { }

        private Product(
            Manufacture manufacture,
            string name,
            DateTime produceDate,
            Guid createdById,
            int quantity)
        {
            Id = Guid.NewGuid();
            Manufacturer = manufacture;
            Name = name;
            ProduceDate = produceDate;
            IsAvailable = quantity > 0;
            CreatedById = createdById;
            Quantity = quantity;
        }

        public static Product Create(string name, DateTime produceDate, Guid createdById, Manufacture manufacturer, int quantity = 0)
        {
            if (manufacturer == null) throw new ArgumentNullException(nameof(manufacturer));

            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            if (produceDate == default) throw new ArgumentException("Produce date is required.", nameof(produceDate));

            if (createdById == Guid.Empty) throw new ArgumentException("CreatedById is required.", nameof(createdById));

            if (quantity < 0 ) throw new ArgumentOutOfRangeException(nameof(quantity));

            return new Product(
                manufacturer,
                name.Trim(),
                produceDate,
                createdById,
                quantity
            );
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(Name));
            Name = name.Trim();
        }

        public void SetManufacturer(Manufacture manufacturer)
        {
            if (manufacturer == null) throw new ArgumentNullException(nameof(Manufacturer));
            Manufacturer = manufacturer;
        }

        public void SetProduceDate(DateTime produceDate)
        {
            if (produceDate == default) throw new ArgumentException("Produce date is required.", nameof(produceDate));
            ProduceDate = produceDate;
        }

        public void IncreaseStock(int amount)
        {
            if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));
            Quantity += amount;
            IsAvailable = true;
        }

        public void DecreaseStock(int amount)
        {
            if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));
            if (Quantity - amount < 0) throw new InvalidOperationException("Insufficient stock.");
            Quantity -= amount;
            IsAvailable = Quantity > 0;
        }
    }
}
