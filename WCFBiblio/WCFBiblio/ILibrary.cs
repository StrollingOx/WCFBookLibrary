using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFBookLibrary
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę interfejsu „IService1” w kodzie i pliku konfiguracji.
    [ServiceContract(SessionMode = SessionMode.Required)] //TODO: ServiceMode
    public interface ILibrary
    {

        [OperationContract]
        List<Book> GetAllBooks();

        [OperationContract]
        List<Book> GetAllRentedBooks();

        [OperationContract]
        List<Book> GetAllBooksWithTitleLike(String text);

        [OperationContract]
        void ReturnBook(int signature);

        [OperationContract]
        void RentBook(int signature);

        [OperationContract]
        Book GetBook(int i);
        // TODO: dodaj tutaj operacje usługi
    }

    // Użyj kontraktu danych, jak pokazano w poniższym przykładzie, aby dodać typy złożone do operacji usługi.
    // Możesz dodać pliki XSD do projektu. Po skompilowaniu projektu możesz bezpośrednio użyć zdefiniowanych w nim typów danych w przestrzeni nazw „WCFBiblio.ContractType”.
    [DataContract]
    public class Book
    {
        [DataMember]
        private String _title;
        public String Title { set { _title = value; } get=>_title; }

        [DataMember]
        private Author _dude;
        public Author Dude { set { _dude = value; } get=>_dude; }

        [DataMember]
        private int _year;
        public int Year { set { _year = value; } get=>_year; }

        [DataMember]
        private int _signature;
        public int Signature { set { _signature = value; } get => _signature; }

        [DataMember]
        public bool IsRented = false;


        public Book(String Title, Author Dude, int Year, bool isRented,int Signature )
        {
            this.Title = Title;
            this.Dude = Dude;
            this.Year = Year;
            this.Signature = Signature;
            this.IsRented = isRented;
        }
    }
    [DataContract]
    public class Author
    {
        [DataMember]
        private String _name;
        public String Name { set { _name = value; } get=>_name; }
        [DataMember]
        private String _surname;
        public String Surname { set { _surname = value; } get=>_surname; }
        [OperationContract] //NOT WORKING!
        public String GetFullName()
        {
            return _name + " " + _surname;
        }
        public Author (String Name, String Surname)
        {
            _name = Name;
            _surname = Surname;
        }
    }
}
