using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2OOPBookStore
{
    class Book
    {
        public Book(string name, double price)
        {
            Name = name;
            Price = price;
        }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    class BookinStore
    {
        List<Book> books = new List<Book>()
        {
            new Book("The Miserable Ones", 23.85),
            new Book("East of Eden", 31.10),
            new Book("Anna Karenina", 31.45),
            new Book("Bury My Heart at Wounded Knee", 25.80),
            new Book("Nana", 27.35),
            new Book("Crime and Punishment", 26.55),
            new Book("The Mother", 34.75),
            new Book("Found", 10.90),
            new Book("The Story of My Life", 18.60),
            new Book("The Complete Chronicles of Narnia", 44.65),
            new Book("Till We Have Faces", 14.95),
            new Book("The Lord of the Rings", 32.95),
            new Book("Pride and Prejudice", 24.15),
            new Book("A Farewell to Arms", 28.70),
            new Book("Harry Potter and the Order of the Phoenix", 33.25),
            new Book("The Catcher in the Rye", 17.65),
            new Book("Paradise Lost", 32.50),
            new Book("To Kill a Mockingbird", 20.95),
            new Book("In Search of Lost Time", 23.15),
            new Book("And Then There Were None", 13.35),
            new Book("The Name of the Rose", 25.55),
            new Book("Death of a Salesman", 29.90),
            new Book("Don Quixote", 18.85),
            new Book("Hamlet", 27.35),
            new Book("The Purpose Driven Life", 33.75),
            new Book("War and Peace", 30.55),
            new Book("The five love languages", 13.70),
            new Book("The Brothers Karamazov", 33.35),
            new Book("Wuthering Heights", 27.75),
            new Book("Little Women", 19.85),
            new Book("The Trial", 37.05),
            new Book("The Grapes of Wrath", 29.95),
            new Book("Great Expectations", 22.25),
            new Book("Dead Souls", 17.45),
            new Book("For Whom the Bells Tolls", 31.25),
            new Book("Vanity Fair", 22.95),
            new Book("The Old Man and the Sea", 29.65),
            new Book("The Tin Drum", 16.65),
            new Book("Les Miserables", 24.40),
            new Book("Wall Street Coyotes, part 1", 23.80),
            new Book("Wall Street Coyotes, part 2", 24.70),
            new Book("Wall Street Coyotes, part 3", 25.60),
            new Book("Fire and Fury", 30.00),
            new Book("The Woman in the Window", 21.20),
            new Book("A Higher Loyalty: Truth, Lies, and Leadership", 19.45)
        };
       
        public List<Book> FindBook(string keyword)
        {
            var searchResult = books.Where(b => b.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();

            if (searchResult.Count == 0)
            {
                Console.WriteLine("Book you are looking for is not found: " + keyword);
            }
            else
            {
                Console.WriteLine("Number of book found is  " + searchResult.Count + ".");

                foreach (var book in searchResult)
                {
                    Console.WriteLine("Book found: " + book.Name + ". Price is Euro " + book.Price);
                    Console.WriteLine("Do you want to buy this book? (Y/N)");
                    string decision = Console.ReadLine().ToUpper();
                    if (decision.StartsWith("Y"))
                    {
                        Console.WriteLine("Adding the book " + book.Name + " to your shopping list.");
                        BuyABook.Add(book);
                    }
                    else if (decision.StartsWith("N"))
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter either Y or N.");
                    }
                }
            }
            return searchResult;
        }
       
        public List<Book> BuyABook = new List<Book>();
        static double CalcTotalPrice(List<Book> books)
        {
            double totalPrice = 0;
            foreach (var book in books)
            {
                totalPrice += book.Price;
            }
            return totalPrice;
        }
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


            Console.WriteLine("You have selected following books.");
            int counter = 1;
            foreach (var book in bookStore.BuyABook)
            {
                Console.WriteLine(counter + ") " + book.Name + ": Euro " + book.Price);

                counter++;
            }
            double totalPrice = CalcTotalPrice(bookStore.BuyABook);
            Console.WriteLine("Total price will be Euro " + totalPrice + ".");
        }


    }


}