using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2OOPBookStore
{
    class Program
    {
        static void Main(string[] args)
        {
            bool more;
            Console.WriteLine("Welcome to the Book Store!");
            BookinStore bookStore = new BookinStore();
            do
            {
                Console.WriteLine("Which book are you looking for?");
                string keyword = Console.ReadLine();

                var foundBooks = bookStore.FindBook(keyword);

                Console.Write("More books (Y/N)? ");
                string decision = Console.ReadLine().ToUpper();
                if (decision.StartsWith("Y"))
                    more = true;
                else
                    more = false;
            } while (more);
            double final_amount = 0;

            Console.WriteLine("You have selected following books.");
            int counter = 1;
            foreach (var book in bookStore.shoppingList)
            {
                Console.WriteLine(counter + ") " + book.Name + ": Euro " + book.Price);

                counter++;
                final_amount += book.Price;
            }
            Console.WriteLine("Total price will be  " + final_amount +" Euros.");
        }
    }
}
