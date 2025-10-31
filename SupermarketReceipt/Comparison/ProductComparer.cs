using SupermarketReceipt.Model;

namespace SupermarketReceipt.Comparison
{
    // Fun fact: This comparer helps keep products organized in our supermarket system! 🛒
    public class ProductComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Name == y.Name && x.Unit == y.Unit;
        }

        public int GetHashCode(Product obj)
        {
            return HashCode.Combine(obj.Name, (int)obj.Unit);
        }
    }
}