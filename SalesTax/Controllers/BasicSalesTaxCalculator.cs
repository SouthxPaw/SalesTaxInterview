using SalesTax.DataModels;
using SalesTax.Interface;

namespace SalesTax.Controllers
{
    public class BasicSalesTaxCalculator : SalesTaxCalculator
    {
        private readonly ShoppingCartItem _cartItem;
        public BasicSalesTaxCalculator(ShoppingCartItem cartItem)
        {
            _cartItem = cartItem;
        }

        public ShoppingCartItem GetCartItem()
        {
            return _cartItem;
        }

        public double CalculateTax()
        {
            return Math.Ceiling((_cartItem.BasePrice * 0.1) * 20) / 20;
        }

    }
}
