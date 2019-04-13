using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ServerConsole
{
    [ServiceContract]
    public interface IContract
    {
        [OperationContract]
        List<User> GetUserList();

        [OperationContract]
        List<Book> GetBookList();

        [OperationContract]
        bool Authentification(String PhoneNumber, String Password);

        // PROCEDURES

        [OperationContract]
        List<ShowAllBooks_cs> ShowAllBooks();

        [OperationContract]
        List<ShowUnavailableBooks_cs> ShowUsersBooks(String PhoneNumber);

        [OperationContract]
        List<User> FindUserInfoByPhone(String PhoneNumber);

        [OperationContract]
        List<ShowUnavailableBooks_cs> ShowUnavailableBooks();

        [OperationContract]
        void AddUser(string last_name, string name, string middle_name, string phone_number, string adress);

        [OperationContract]
        void ServerClose();

        [OperationContract]
        void PassBook(int book_id);

        [OperationContract]
        void IssueBook(int user_id, int book_id, string date_of_issue);

        [OperationContract]
        void AddBook(string title, string author, string year, string genre);
           
    }
}
