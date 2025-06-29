using System.Diagnostics.CodeAnalysis;

namespace Session.LINQ
{
    //class ProductComparer : IComparer<Product>
    //{
    //    public int Compare(Product? x, Product? y)
    //    {
    //        return x.UnitPrice.CompareTo(y.UnitPrice);
    //    }
    //}
    class ProductEqualityComparer : IEqualityComparer<long>
    {
        public bool Equals(long x, long y)
        {
            return x == y;
        }

        public int GetHashCode([DisallowNull] long obj)
        {
            return obj.GetHashCode();
        }
    }
    class CustomProductEqualityComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product? x, Product? y)
        {
            return x.UnitPrice == y.UnitPrice
                && x.UnitsInStock == y.UnitsInStock
                && x.ProductID == y.ProductID
                && x.ProductName == y.ProductName
                && x.Category == y.Category;
        }

        public int GetHashCode([DisallowNull] Product obj)
        {
            return HashCode.Combine(obj.UnitsInStock, obj.UnitsInStock, obj.ProductID, obj.ProductName, obj.Category);
        }
    }

    class Product
    {
        public Product(long productId, string productName, string category, decimal unitPrice, int unitsInStock)
        {
            ProductID = productId;
            ProductName = productName;
            Category = category;
            UnitPrice = unitPrice;
            UnitsInStock = unitsInStock;
        }
        public Product()
        {

        }
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }

        public override string ToString() => $"ProductId: {ProductID}, ProductName: {ProductName}, Category: {Category}, UnitPrice: {UnitPrice}, UnitsInStock: {UnitsInStock}\n";

        //public int CompareTo(Product? other)
        //{
        //    return UnitPrice.CompareTo(other.UnitPrice);
        //}
    }
}
