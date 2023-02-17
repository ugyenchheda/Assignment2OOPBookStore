using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2OOPBookStore
{
    class Program
    {
        public double CalcTotalPrice(List<Book> BuyABook)
        {

            double final_amount = 0;

            Console.WriteLine("You have selected following books.");
            int counter = 1;
            foreach (var book in BuyABook)
            {
                Console.WriteLine(counter + ") " + book.Name + ": Euro " + book.Price);

                counter++;
                final_amount += book.Price;
            }
            Console.WriteLine("Total price will be  " + final_amount +" Euros.");
            return final_amount;
        }
    }
}
