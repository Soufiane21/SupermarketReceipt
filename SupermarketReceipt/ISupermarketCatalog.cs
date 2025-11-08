using SupermarketReceipt.Entities;

namespace SupermarketReceipt
{
    public interface ISupermarketCatalog
    {
        void AddProduct(Product product, double price);

        double GetUnitPrice(Product product);
    }
    // This is a happy comment! Keep smiling!
}