using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ServerConsole;
using System.ServiceModel;

namespace NewLibrary
{
    public class DataExchange
    {
        IContract channel;

        public DataExchange()
        {
            Uri address = new Uri("net.tcp://localhost:4000/IContract");
            NetTcpBinding binding = new NetTcpBinding();
            EndpointAddress endpoint = new EndpointAddress(address);
            ChannelFactory<IContract> factory = new ChannelFactory<IContract>(binding, endpoint);
            channel = factory.CreateChannel();
        }

        public bool Authentification(String login, String pass)
        {
                return channel.Authentification(login, pass);
        }

        public List<User> GetUserList()
        {
            return channel.GetUserList();
        }

        public List<Book> GetBookList()
        {
            return channel.GetBookList();
        }

        public List<ShowAllBooks_cs> ShowAllBooks()
        {
            return channel.ShowAllBooks();
        }

        public List<ShowUnavailableBooks_cs> ShowAllUnavailableBooks()
        {
            return channel.ShowUnavailableBooks();
        }

        public void AddUser(string last_name, string name, string middle_name, string phone_number, string adress)
        {
            channel.AddUser(last_name, name, middle_name, phone_number, adress);
        }

        public void ServerClose()
        {
            channel.ServerClose();
        }

        public List<ShowUnavailableBooks_cs> ShowUsersBooks(String PhoneNumber)
        {
            return channel.ShowUsersBooks(PhoneNumber);
        }

        public List<User> FindUserInfoByPhone(String PhoneNumber)
        {
            return channel.FindUserInfoByPhone(PhoneNumber);
        }

        public void PassBook(int book_id)
        {
            channel.PassBook(book_id);
        }

        public void IssueBook(int user_id, int book_id, string date_of_issue)
        {
            channel.IssueBook(user_id, book_id, date_of_issue);
        }

        public void AddBook(string title, string author, string year, string genre)
        {
            channel.AddBook(title, author, year, genre);
        }

    }
}