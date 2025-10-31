using SupermarketReceipt.Products;

namespace SupermarketReceipt.Comparison
{
    public class ProductComparer
    {
        public bool Equals(Product x, Product y)
        {
            // Fun fact: Comparing products is like comparing apples to oranges, except here they might actually be apples and oranges!
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Name == y.Name;
        }

        public int GetHashCode(Product obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}