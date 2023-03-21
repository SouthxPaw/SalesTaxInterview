using SalesTax.DataModels;

namespace SalesTax.Controllers
{
    public class Receipt
    {
        public List<string> PrintReceipt(List<ShoppingCartItem> cartItems) 
        {
            List<string> errorStrings = new List<string>() { "The application could not return the correct information you requested." };

            //Checking if the list has objects inside of it at all
            if (cartItems != null || cartItems?.Count > 0)
            {
                //leaving the calcs null so they don't have to be initialized every single time
                //that this method is called
                //only initialized when needed
                //other values set to 0 or empty string
                //so we won't have to null check them
                ImportSalesTaxCalculator? importSalesCalc = null;
                BasicSalesTaxCalculator? basicSalesCalc = null;
                List<string> formattedStrings = new List<string>();
                double salesTax = 0.0;
                string formattedString = string.Empty;
                double total = 0.0;
                double priceAfterTax = 0.0;
                List<ShoppingCartItem> dupeList = cartItems.GroupBy(c => new { c.Name, c.BasePrice }).Where(c => c.Count() > 1).SelectMany(c => c).ToList();

                //Iterate through cartItems
                //So we can correctly add up sales tax and get the individual items added to the list
                //Added ids to the cartItems so we could weed out dupes when interating
                //This will play a part in adding the correct quantities
                //I added the ids manually, but I know in a real world scenario, these are set by the databas
                //and entries that are exactly the same will have the same id, which is how I set it up in the Program.cs file
                foreach (var cartItem in cartItems.DistinctBy(c => c.Id))
                {
                    //Setting quantity here because if we are iterating through this foreach
                    //Then there are items inside the list and we can assume
                    //that the customer has at least one of this item inside their basket
                    int quantity = 1;

                    //Checking if the item exists in the duplicate list
                    //If so, then we can set the list to how many the customer has in their basket
                    if (dupeList.Contains(cartItem)) quantity = dupeList.Where(c => c.Id == cartItem.Id).Count();

                    //Checking each scenario to add certain taxes to the price after tax and sales tax
                    if (cartItem.TaxExempt == Enums.Exempt.None && !cartItem.IsImported)
                    {
                        basicSalesCalc = new BasicSalesTaxCalculator(cartItem);
                        salesTax += basicSalesCalc.CalculateTax();
                        priceAfterTax = Math.Round(cartItem.BasePrice + basicSalesCalc.CalculateTax(), 2);
                        formattedString = quantity + " " + cartItem.Name + ": " + priceAfterTax + Environment.NewLine;
                        formattedStrings.Add(formattedString);
                    }

                    if (cartItem.TaxExempt == Enums.Exempt.None && cartItem.IsImported)
                    {
                        importSalesCalc = new ImportSalesTaxCalculator(cartItem);
                        basicSalesCalc = new BasicSalesTaxCalculator(cartItem);
                        salesTax += importSalesCalc.CalculateTax();
                        salesTax += basicSalesCalc.CalculateTax();
                        priceAfterTax = Math.Round(cartItem.BasePrice + importSalesCalc.CalculateTax() + basicSalesCalc.CalculateTax(), 2);
                        formattedString = quantity + " " + cartItem.Name + ": " + priceAfterTax + Environment.NewLine;
                        formattedStrings.Add(formattedString);
                    }

                    if (cartItem.TaxExempt != Enums.Exempt.None && cartItem.IsImported)
                    {
                        importSalesCalc = new ImportSalesTaxCalculator(cartItem);
                        salesTax += importSalesCalc.CalculateTax();
                        priceAfterTax = Math.Round(cartItem.BasePrice + importSalesCalc.CalculateTax(), 2);
                        formattedString = quantity + " " + cartItem.Name + ": " + priceAfterTax + Environment.NewLine;
                        formattedStrings.Add(formattedString);
                    }

                    if (cartItem.TaxExempt != Enums.Exempt.None && !cartItem.IsImported)
                    {
                        formattedString = quantity + " " + cartItem.Name + ": " + cartItem.BasePrice + Environment.NewLine;
                        formattedStrings.Add(formattedString);
                    }

                    total += cartItem.BasePrice;
                }

                if (salesTax != 0.0 && total != 0.0)
                {
                    //Round the total and sales tax so it displays easier
                    salesTax = Math.Round(salesTax, 2);
                    total = Math.Round(total + salesTax, 2);

                    //separated these two strings in case, something needs to be tested or changed in one individually
                    var salesString = "Sales Tax: " + salesTax + Environment.NewLine;
                    var totalString = "Total: " + total + Environment.NewLine;

                    formattedStrings.Add(salesString);
                    formattedStrings.Add(totalString);
                }


                //For whatever reason that there are no strings added to this list at all
                //We want to be able to catch it to make sure that it's not printing nonsense and instead
                //printing the error message so we can let the user know that something happened while running the code
                if (formattedStrings.Count != 0)
                {
                    return formattedStrings;
                }
                else
                {
                    return errorStrings;
                }
            }

            //Going to print this to the console instead
            //This is if the list has no objects
            return errorStrings;
        }
    }
}
