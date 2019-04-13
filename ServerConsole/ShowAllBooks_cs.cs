using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerConsole
{
    public class ShowAllBooks_cs
    {
        public int _book_id  { get; set;}
        public String _title { get; set;}
        public String _author { get; set;}
        public String _year { get; set;}
        public String _genre { get; set;}

        public String _available { get; set;}
        public String _date_of_issue { get; set;}
        public int? _user_id { get; set;}
    
        public void Show()
        {
            Console.WriteLine(_book_id.ToString(), _title, _author, _year, _genre, _available, _date_of_issue, _user_id.ToString());
        }
    }
}
