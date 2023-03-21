using SalesTax.Enums;

namespace SalesTax.DataModels
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Exempt TaxExempt { get; set; }
        public bool IsImported { get; set; }
        public double BasePrice { get; set; }
    }
}
