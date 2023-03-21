using SalesTax.Controllers;
using SalesTax.DataModels;

class Program
{
    static void Main(string[] args)
    {
        //Declaring shopping carts items up here
        //Separating each cart by region
        #region FirstShoppingCartItems

        ShoppingCartItem book = new ShoppingCartItem()
        {
            Id = 1,
            Name = "book",
            TaxExempt = SalesTax.Enums.Exempt.Books,
            IsImported = false,
            BasePrice = 12.49
        };

        //This commented out in case you want to check the logic on multiple of the same product added to the cart
        //Also uncomment Line 117
        //ShoppingCartItem book2 = new ShoppingCartItem()
        //{
        //    Id = 1,
        //    Name = "book",
        //    TaxExempt = SalesTax.Enums.Exempt.Books,
        //    IsImported = false,
        //    BasePrice = 12.49
        //};

        ShoppingCartItem musicCD = new ShoppingCartItem()
        {
            Id = 2,
            Name = "music CD",
            TaxExempt = SalesTax.Enums.Exempt.None,
            IsImported = false,
            BasePrice = 14.99
        };

        ShoppingCartItem chocolateBar = new ShoppingCartItem()
        {
            Id = 3,
            Name = "chocolate bar",
            TaxExempt = SalesTax.Enums.Exempt.Food,
            IsImported = false,
            BasePrice = 0.85
        };
        #endregion

        #region SecondShoppingCartItems
        ShoppingCartItem importedBoxOfChocolatesSecondCart = new ShoppingCartItem()
        {
            Id = 4,
            Name = "imported box of chocolates",
            TaxExempt = SalesTax.Enums.Exempt.Food,
            IsImported = true,
            BasePrice = 10.00
        };

        ShoppingCartItem importedPerfumeSecondCart = new ShoppingCartItem()
        {
            Id = 5,
            Name = "imported bottle of perfume",
            TaxExempt = SalesTax.Enums.Exempt.None,
            IsImported = true,
            BasePrice = 47.50
        };
        #endregion

        #region ThirdShoppingCartItems
        ShoppingCartItem importedPerfumeThirdCart = new ShoppingCartItem()
        {
            Id = 6,
            Name = "imported bottle of perfume",
            TaxExempt = SalesTax.Enums.Exempt.None,
            IsImported = true,
            BasePrice = 27.99
        };

        ShoppingCartItem perfumeThirdCart = new ShoppingCartItem()
        {
            Id = 7,
            Name = "bottle of perfume",
            TaxExempt = SalesTax.Enums.Exempt.None,
            IsImported = false,
            BasePrice = 18.99
        };

        ShoppingCartItem headachePills = new ShoppingCartItem()
        {
            Id = 8,
            Name = "packet of headache pills",
            TaxExempt = SalesTax.Enums.Exempt.Medical,
            IsImported = false,
            BasePrice = 9.75
        };

        ShoppingCartItem importedBoxOfChocolatesThirdCart = new ShoppingCartItem()
        {
            Id = 9,
            Name = "imported box of chocolates",
            TaxExempt = SalesTax.Enums.Exempt.Food,
            IsImported = true,
            BasePrice = 11.25
        };
        #endregion

        #region Cart Declarations
        //Declaring carts down here for readability

        //Comment out this line if going to uncomment to the other list on Line 117
        List<ShoppingCartItem> firstCart = new List<ShoppingCartItem>() { book, musicCD, chocolateBar };

        //This is commented out in case you want to check the logic on multiple of the same product added to the cart
        //Also uncomment Line 24-30
        //List<ShoppingCartItem> firstCart = new List<ShoppingCartItem>() { book, book2, musicCD, chocolateBar };

        List<ShoppingCartItem> secondCart = new List<ShoppingCartItem>() { importedBoxOfChocolatesSecondCart, importedPerfumeSecondCart };

        List<ShoppingCartItem> thirdCart = new List<ShoppingCartItem>() { importedPerfumeThirdCart, perfumeThirdCart, headachePills, importedBoxOfChocolatesThirdCart };
        #endregion

        #region Start of Receipt Printing
        Receipt receipt = new Receipt();

        //First output
        Console.WriteLine("---First Output---" + Environment.NewLine);
        receipt.PrintReceipt(firstCart).ForEach(c => Console.WriteLine(c));
        Console.WriteLine("------------" + Environment.NewLine);

        //Second output
        Console.WriteLine("---Second Output---" + Environment.NewLine);
        receipt.PrintReceipt(secondCart).ForEach(c => Console.WriteLine(c));
        Console.WriteLine("------------" + Environment.NewLine);

        //Third output
        Console.WriteLine("---Third Output---" + Environment.NewLine);
        receipt.PrintReceipt(thirdCart).ForEach(c => Console.WriteLine(c));
        Console.WriteLine("------------" + Environment.NewLine);

        #endregion
    }
}
