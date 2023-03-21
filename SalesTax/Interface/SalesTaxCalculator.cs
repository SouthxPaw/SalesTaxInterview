using SalesTax.DataModels;

namespace SalesTax.Interface
{
    public interface SalesTaxCalculator
    {
        ShoppingCartItem GetCartItem();
        double CalculateTax();
    }
}
