using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerConsole
{
    class NewLibraryData : IContract
    {
        public void DoWork()
        {
            Console.WriteLine("Отработал сервис!");
        }

        public bool Authentification(string PhoneNumber, string Password)
        {

            using (newlibrary_dbEntities db = new newlibrary_dbEntities())
            {

                var res = GetUserList();
                if (res.Where(x => x.phone_number == PhoneNumber && x.password == Password).Count() == 1)
                {
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<User> GetUserList()
        {
            Console.WriteLine("Получение списка пользователей ...");
            using (newlibrary_dbEntities db = new newlibrary_dbEntities())
            {
                var users_db = db.users_table.ToList();
                var u = db.users_table.Select(x => new User() { user_id = x.C_user_id, last_name = x.C_last_name, name = x.C_name, phone_number = x.C_phone_number, adress = x.C_adress, middle_name = x.C_middle_name, password = x.C_password }).ToList();
                Console.WriteLine("Список пользователей успешно получен!");

                return u;
            }
        }

        public List<Book> GetBookList()
        {
            Console.WriteLine("Получение списка книг ...");
            using (newlibrary_dbEntities db = new newlibrary_dbEntities())
            {
                var books_db = db.books_table.ToList();
                var u = db.books_table.Select(x => new Book() { book_id = x.C_book_id, title = x.C_title, author = x.C_author, year = x.C_year, genre = x.C_genre, available = x.C_available, date_of_issue = x.C_date_of_issue }).ToList();
                Console.WriteLine("Список книг успешно получен!");

                return u;
            }
        }

        public List<ShowAllBooks_cs> ShowAllBooks()
        {
            Console.WriteLine("Получение списка книг ...");
            using (newlibrary_dbEntities db = new newlibrary_dbEntities())
            {
                //var books_db = db.Database.SqlQuery<ShowAllBooks_cs>("select * from books_table").ToList();

                var books_db = db.Database.SqlQuery<ShowAllBooks_cs>("dbo.ShowAllBooks").ToList();


                for (int i = 0; i < books_db.Count(); i++)
                {
                    books_db[i].Show();
                }

                return books_db;
            }
        }

        public List<ShowUnavailableBooks_cs> ShowUnavailableBooks()
        {
            Console.WriteLine("Получение списка книг ...");
            using (newlibrary_dbEntities db = new newlibrary_dbEntities())
            {
                //var books_db = db.Database.SqlQuery<ShowAllBooks_cs>("select * from books_table").ToList();

                var books_db = db.Database.SqlQuery<ShowUnavailableBooks_cs>("dbo.ShowAllUnavailableBooks").ToList();


                return books_db;
            }
        }

        public void AddUser(string last_name, string name, string middle_name, string phone_number, string adress)
        {
            using (newlibrary_dbEntities db1 = new newlibrary_dbEntities())
            {
                var res = GetUserList();

                int nums = 0;

                for (int i = 0; i < res.Count(); i++)
                {
                    if (res[i].phone_number != phone_number)
                    {
                        nums++;
                        if (nums == res.Count())
                        {
                            Console.WriteLine("Регистрирую пользователя..");
                            newlibrary_dbEntities db = new newlibrary_dbEntities();
                            SqlParameter param1 = new SqlParameter("@_LastName", last_name.Trim());
                            SqlParameter param2 = new SqlParameter("@_Name", name.Trim());
                            SqlParameter param3 = new SqlParameter("@_MiddleName", middle_name.Trim());
                            SqlParameter param4 = new SqlParameter("@_PhoneNumber", phone_number.Trim());
                            SqlParameter param5 = new SqlParameter("@_Adress", adress.Trim());
                            SqlParameter param6 = new SqlParameter("@_Password", "12345");

                            db.Database.Connection.Open();
                            db.Database.ExecuteSqlCommand("exec AddUser @_LastName, @_Name, @_MiddleName, @_PhoneNumber, @_Adress, @_Password", param1, param2, param3, param4, param5, param6);
                            db.Database.Connection.Close();
                            db.SaveChanges();

                            Console.WriteLine("Пользователь зарегистрирован!");
                            return;
                        }

                    }
                    Console.WriteLine("Пользователь с таким номером уже создан!");
                }
            }

        }

        public void ServerClose()
        {
            Environment.Exit(0);
        }

        public List<ShowUnavailableBooks_cs> ShowUsersBooks(String PhoneNumber)
        {
            Console.WriteLine("Получение списка книг ...");
            using (newlibrary_dbEntities db = new newlibrary_dbEntities())
            {
                //var books_db = db.Database.SqlQuery<ShowAllBooks_cs>("select * from books_table").ToList();

                SqlParameter param1 = new SqlParameter("@_PhoneNumber", PhoneNumber.Trim());

                var books_db = db.Database.SqlQuery<ShowUnavailableBooks_cs>("dbo.FindUserByPhone @_PhoneNumber", param1).ToList();

                //db.Database.Connection.Open();
                //db.Database.ExecuteSqlCommand("exec FindUserByPhone @_PhoneNumber", param1);
                //db.Database.Connection.Close();
                //db.SaveChanges();


                return books_db;
            }
        }

        public List<User> FindUserInfoByPhone(String PhoneNumber)
        {
            Console.WriteLine("Начало функции FindUserInfoByPhone");
            using (newlibrary_dbEntities db = new newlibrary_dbEntities())
            {
                Console.WriteLine("Задаю параметр");
                SqlParameter param1 = new SqlParameter("@_PhoneNumber", PhoneNumber.Trim());
                Console.WriteLine("Параметр задан");

                Console.WriteLine("Выполняю запрос процедуры");
                var user_db = db.Database.SqlQuery<User>("exec FindUserInfoByPhone @_PhoneNumber", param1).ToList();
                Console.WriteLine("Запрос выполнен");

                Console.WriteLine("user_db.Count = " + user_db.Count());

                for (int i = 0; i < user_db.Count; i++)
                {
                    Console.WriteLine("id = " + user_db[i].user_id);
                    Console.WriteLine("lastname = " + user_db[i].last_name);
                    Console.WriteLine("name = " + user_db[i].name);
                    Console.WriteLine("middlename = " + user_db[i].middle_name);
                }
                //db.Database.Connection.Open();
                //db.Database.ExecuteSqlCommand("exec FindUserByPhone @_PhoneNumber", param1);
                //db.Database.Connection.Close();
                //db.SaveChanges();

                Console.WriteLine("Возвращаю класс");
                return user_db;
            }
        }

        public void PassBook(int book_id)
        {
            using (newlibrary_dbEntities db = new newlibrary_dbEntities())
            {
                SqlParameter param1 = new SqlParameter("@_BookID", book_id);
                db.Database.Connection.Open();
                db.Database.ExecuteSqlCommand("exec Pass @_BookID", param1);
                db.Database.Connection.Close();
                db.SaveChanges();
            }
        }


        public void IssueBook(int user_id, int book_id, string date_of_issue)
        {
            using (newlibrary_dbEntities db = new newlibrary_dbEntities())
            {
                SqlParameter param1 = new SqlParameter("@_UserID", user_id);
                SqlParameter param2 = new SqlParameter("@_BookID", book_id);
                SqlParameter param3 = new SqlParameter("@_DateOfIssue", date_of_issue);
                db.Database.Connection.Open();
                db.Database.ExecuteSqlCommand("exec Issue @_UserID, @_BookID, @_DateOfIssue", param1, param2, param3);
                db.Database.Connection.Close();
                db.SaveChanges();

            }
        }

        public void AddBook(string title, string author, string year, string genre)
        {
            using (newlibrary_dbEntities db = new newlibrary_dbEntities())
            {
                SqlParameter param1 = new SqlParameter("@_Title", title);
                SqlParameter param2 = new SqlParameter("@_Author", author);
                SqlParameter param3 = new SqlParameter("@_Year", year);
                SqlParameter param4 = new SqlParameter("@_Genre", genre);

                db.Database.Connection.Open();
                db.Database.ExecuteSqlCommand("exec Addbook @_Title, @_Author, @_Year, @_Genre", param1, param2, param3, param4);
                db.Database.Connection.Close();
                db.SaveChanges();
            }
        }
    }
}