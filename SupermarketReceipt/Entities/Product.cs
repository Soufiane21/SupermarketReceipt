using SupermarketReceipt.Enums;

namespace SupermarketReceipt.Entities
{
    public class Product
    {
        public Product(string name, ProductUnit unit)
        {
            Name = name;
            Unit = unit;
        }

        public string Name { get; }
        public ProductUnit Unit { get; }
    }

}
