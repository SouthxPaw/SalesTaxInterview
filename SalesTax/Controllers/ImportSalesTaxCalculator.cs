using SalesTax.DataModels;
using SalesTax.Interface;

namespace SalesTax.Controllers
{
    internal class ImportSalesTaxCalculator : SalesTaxCalculator
    {
        private readonly ShoppingCartItem _cartItem;
        public ImportSalesTaxCalculator(ShoppingCartItem cartItem)
        {
            _cartItem = cartItem;
        }

        public ShoppingCartItem GetCartItem()
        {
            return _cartItem;
        }

        public double CalculateTax()
        {
            return Math.Ceiling((_cartItem.BasePrice * 0.05) * 20) / 20;
        }
    }
}
