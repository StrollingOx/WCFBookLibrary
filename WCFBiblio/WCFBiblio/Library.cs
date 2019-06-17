using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFBookLibrary
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę klasy „Service1” w kodzie i pliku konfiguracji.
    [ServiceBehaviorAttribute(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Library : ILibrary
    {

        List<Book> bookList = new List<Book>();
        List<Book> rentedBookList = new List<Book>();

        public Library()
        {
            PopulateBiblio();
        }

        public void PopulateBiblio()
        {
            int i = 0;
            bookList.Add(new Book("GenericBookTitle_0", new Author("GenericName0", "GenericSurname0"), 2000, false, i++));
            bookList.Add(new Book("GenericBookTitle_1", new Author("GenericName1", "GenericSurname1"), 2001, false, i++));
            bookList.Add(new Book("GenericBookTitle_2", new Author("GenericName2", "GenericSurname2"), 2002, false, i++));
            bookList.Add(new Book("GenericBookTitle_3", new Author("GenericName3", "GenericSurname3"), 2003, false, i++));
            bookList.Add(new Book("BookFromFuture", new Author("AwsomeName", "AwsomeSurname"), 2077, false, i++));
            bookList.Add(new Book("BookFromMoreFuturisticFuture", new Author("Aguy", "Hissurname"), 2077, false, i++));

        }

        public List<Book> GetAllBooks()
        {
            List<Book> tmpList = new List<Book>();

            foreach (Book book in bookList){
                tmpList.Add(book);
            }
            return tmpList;
        }


        public List<Book> GetAllBooksWithTitleLike(String text)
        {
            List<Book> tmpList = new List<Book>();



            foreach (Book book in bookList)
            {
                if (book.Title.Contains(text)){
                    tmpList.Add(book);
                }
            }
            return tmpList;
        }

        public Book GetBook(int i)
        {
            if (i >= bookList.Capacity)
                throw new System.ArgumentException("Parameter out of bound", "original");
            else
                return bookList[i];

        }

        public void RentBook(int signature) {
            rentedBookList.Add(bookList[signature]);
        }

        public void ReturnBook(int signature){
            rentedBookList.Remove(bookList[signature]);
        }

        public List<Book> GetAllRentedBooks()
        {
            List<Book> tmpList = new List<Book>();

            foreach (Book book in rentedBookList)
            {
                tmpList.Add(book);
            }
            return tmpList;
        }
    }
}
