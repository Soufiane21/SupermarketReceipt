using SupermarketReceipt.Entities;
using System.Collections.Generic;


namespace SupermarketReceipt.Comparison
{
    public class ProductComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
            return x.Name == y.Name &&
                   x.Unit == y.Unit;
        }


        public int GetHashCode(Product obj)
        {
            return obj.Name.GetHashCode() ^ obj.Unit.GetHashCode();
        }
    }
}
