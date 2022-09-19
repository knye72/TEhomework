using System;

namespace DiscountCalculator
{
    class Program
    {
        /// <summary>
        /// The main method is the start and end of our program.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Discount Calculator");


            double discountAmount = 0;
            //use do-while loop to make surethe user isn't giving themselves huge discounts
            do
            {             // Prompt the user for a discount amount
                          // The answer needs to be saved as a double
                Console.Write("Enter the discount amount (w/out percentage): ");

                string input = Console.ReadLine();

                discountAmount = double.Parse(input);

                //use shouldn't be able to put in a discount > 100%
                if (discountAmount > 100) //if greater than 100, user needs to try again
                {
                    Console.WriteLine("Please enter an amount below 100.");
                }
            }
            while (discountAmount > 100);

          


            discountAmount = discountAmount / 100.0;

            Console.WriteLine("you entered: " + discountAmount);

            // Prompt the user for a series of prices
            Console.Write("Please provide a series of prices (space separated): "); //2.00 5.00 10.00
            string prices = Console.ReadLine();

            Console.WriteLine("You entered: " + prices);
            //split the string of prices into separate values
            string[] priceArray = prices.Split(' '); //should now be ["2.00", "5.00", "10.00"]

            //placeholders for adding our totals
            decimal totalOriginalPrice = 0;
            decimal totalSalePrice = 0;
            for (int i = 0; i < priceArray.Length; i++)
            {
                string value = priceArray[i];
                decimal originalPrice = decimal.Parse(value); //turns the value into a decimal
                decimal discountAmountOfItem = originalPrice * (decimal)discountAmount; // finds the discount amount. adding (decimal) allows you to change discountAmount to a decimal since it's already a number (double)
                decimal salePrice = originalPrice - discountAmountOfItem; //sale price = original price minus discount

                Console.WriteLine($"Original price: {originalPrice:C2}, amount of discount: {discountAmountOfItem:C2}, sale price: {salePrice:C2}");//C2 is a currency format

                //add to the total amounts
                totalOriginalPrice += originalPrice; //add the item's original price to total original price
                totalSalePrice += salePrice; //same as above

            }
            Console.WriteLine($"Total original price: {totalOriginalPrice:C2}, total sale price: {totalSalePrice:C2}");
         







        }
    }
}
