using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.LibraryGuest;

/* połączenia kolejowe - zapytanie dwa miasta odpowiedz o ktorej wyjazd o ktorej przyjazd, przesiadki*/
/* struktura danych lub lista struktury danych*/
/* system oddający liste ocen od studenta*/

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var guest = new LibraryClient();
                Console.WriteLine("All books that are present in the Library:");
                foreach (Book book in guest.GetAllBooks())
                {
                    Console.WriteLine("-) Title: {0}", book._title);
                    if (book._dude.SingleAuthor)
                        Console.WriteLine("-) Author: {0} {1}", book._dude._name, book._dude._surname);
                    else
                    {
                        Console.Write("-) Authors:");
                        foreach (Author author in book._dude._authors)
                            Console.Write(" {0} {1};", author._name, author._surname);
                        Console.Write("\n");
                    }
                    Console.WriteLine("-) Signature: {0}", book._signature);
                    Console.WriteLine("-) Release date: {0}", book._year);
                    Console.WriteLine("-) Availability: {0}", !book.IsRented);
                    Console.WriteLine();
                }
                Console.ReadLine();

                Console.WriteLine("***********TESTS***********");
                Console.WriteLine(">>>Renting books.");

                //EXCEPTION 1

                try
                { 
                    guest.RentBook(0);
                    guest.RentBook(0);
                    guest.RentBook(2);
                }
                catch (FaultException<BookIsAlreadyRentedFault> e)
                {
                    Console.WriteLine("////////////////////////////////////////////////////////////////");
                    Console.WriteLine("              This book is already rented!");
                    Console.WriteLine("////////////////////////////////////////////////////////////////");
                }
                Console.WriteLine("Books rented:");
                foreach (Book book in guest.GetAllRentedBooks())
                {
                    Console.WriteLine("-) Title: {0}", book._title);
                    if (book._dude.SingleAuthor)
                        Console.WriteLine("-) Author: {0} {1}", book._dude._name, book._dude._surname);
                    else
                    {
                        Console.Write("-) Authors:");
                        foreach (Author author in book._dude._authors)
                            Console.Write(" {0} {1};", author._name, author._surname);
                        Console.Write("\n");
                    }
                    Console.WriteLine("-) Signature: {0}", book._signature);
                    Console.WriteLine("-) Release date: {0}", book._year);
                    Console.WriteLine();
                }




                Console.ReadLine();
                Console.WriteLine(">>>Searching a book by title part");

                //EXCEPTION 2

                try
                {
                    foreach (Book book in guest.GetAllBooksWithTitleLike("FutureTEXTTHATISNOTINANYBOOKS"))
                    {
                        Console.WriteLine("-) Title: {0}", book._title);
                        if (book._dude.SingleAuthor)
                            Console.WriteLine("-) Author: {0} {1}", book._dude._name, book._dude._surname);
                        else
                        {
                            Console.Write("-) Authors:");
                            foreach (Author author in book._dude._authors)
                                Console.Write(" {0} {1};", author._name, author._surname);
                            Console.Write("\n");
                        }
                        Console.WriteLine("-) Signature: {0}", book._signature);
                        Console.WriteLine("-) Release date: {0}", book._year);
                        Console.WriteLine();
                    }
                }
                catch(FaultException<NoSuchBooksFault> e)
                {
                    Console.WriteLine("////////////////////////////////////////////////////////////////");
                    Console.WriteLine("              There are no such books!");
                    Console.WriteLine("////////////////////////////////////////////////////////////////");
                }




                Console.ReadLine();
                Console.WriteLine(">>>Returning books");
                foreach (Book book in guest.GetAllBooks())
                {
                    Console.WriteLine("-) Title: {0}", book._title);
                    if (book._dude.SingleAuthor)
                        Console.WriteLine("-) Author: {0} {1}", book._dude._name, book._dude._surname);
                    else
                    {
                        Console.Write("-) Authors:");
                        foreach (Author author in book._dude._authors)
                            Console.Write(" {0} {1};", author._name, author._surname);
                        Console.Write("\n");
                    }
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
                    if (book._dude.SingleAuthor)
                        Console.WriteLine("-) Author: {0} {1}", book._dude._name, book._dude._surname);
                    else
                    {
                        Console.Write("-) Authors:");
                        foreach (Author author in book._dude._authors)
                            Console.Write(" {0} {1};", author._name, author._surname);
                        Console.Write("\n");
                    }
                    Console.WriteLine("-) Signature: {0}", book._signature);
                    Console.WriteLine("-) Release date: {0}", book._year);
                    Console.WriteLine("-) Availability: {0}", !book.IsRented);
                    Console.WriteLine();
                }

                Console.ReadLine();
            }
            //TODO: hadnle communication 
            catch (ObjectDisposedException e)
            {
                Console.WriteLine("ObjectDisposedException error");
            }
            catch(CommunicationException e)
            {
                Console.WriteLine("CommunicationException error");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception error");
                
            }
        }

    }
}

