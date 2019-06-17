using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.LibraryGuest;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var guest = new LibraryClient();
            Console.WriteLine("All books that are present in the Library:");
            foreach (Book book in guest.GetAllBooks())
            {
                Console.WriteLine("-) Title: {0}", book._title);
                //TODO: HOW TO GETFULLNAME FFS!
                Console.WriteLine("-) Author: {0} {1}", book._dude._name, book._dude._surname);
                Console.WriteLine("-) Signature: {0}", book._signature);
                Console.WriteLine("-) Release date: {0}", book._year);
                Console.WriteLine("-) Availability: {0}", !book.IsRented);
                Console.WriteLine();
            }
            Console.ReadLine();
            Console.WriteLine("***********TESTS***********");
            Console.ReadLine(); 

            Console.WriteLine(">>>Renting a book.");
            guest.RentBook(0);
            guest.RentBook(2);
            Console.WriteLine("Books rented:");
            foreach (Book book in guest.GetAllRentedBooks())
            {
                Console.WriteLine("-) Title: {0}", book._title);
                //TODO: HOW TO GETFULLNAME FFS!
                Console.WriteLine("-) Author: {0} {1}", book._dude._name, book._dude._surname);
                Console.WriteLine("-) Signature: {0}", book._signature);
                Console.WriteLine("-) Release date: {0}", book._year);
                Console.WriteLine();
            }

            Console.ReadLine();
            Console.WriteLine(">>>Searching a book by title part");
            foreach (Book book in guest.GetAllBooksWithTitleLike("Future"))
            {
                Console.WriteLine("-) Title: {0}", book._title);
                //TODO: HOW TO GETFULLNAME FFS!
                Console.WriteLine("-) Author: {0} {1}", book._dude._name, book._dude._surname);
                Console.WriteLine("-) Signature: {0}", book._signature);
                Console.WriteLine("-) Release date: {0}", book._year);
                Console.WriteLine();
            }

            Console.ReadLine();
            Console.WriteLine(">>>Returning books");
            foreach (Book book in guest.GetAllBooks())
            {
                Console.WriteLine("-) Title: {0}", book._title);
                //TODO: HOW TO GETFULLNAME FFS!
                Console.WriteLine("-) Author: {0} {1}", book._dude._name, book._dude._surname);
                Console.WriteLine("-) Signature: {0}", book._signature);
                Console.WriteLine("-) Release date: {0}", book._year);
                Console.WriteLine("-) Availability: {0}", !book.IsRented);
                Console.WriteLine();
            }
            Console.WriteLine("Returning books 0 and 2...");
            guest.ReturnBook(0); guest.ReturnBook(2);
            Console.WriteLine("DONE!");
            foreach (Book book in guest.GetAllBooks())
            {
                Console.WriteLine("-) Title: {0}", book._title);
                //TODO: HOW TO GETFULLNAME FFS!
                Console.WriteLine("-) Author: {0} {1}", book._dude._name, book._dude._surname);
                Console.WriteLine("-) Signature: {0}", book._signature);
                Console.WriteLine("-) Release date: {0}", book._year);
                Console.WriteLine("-) Availability: {0}", !book.IsRented);
                Console.WriteLine();
            }

            Console.ReadLine();
        }

    }
}

