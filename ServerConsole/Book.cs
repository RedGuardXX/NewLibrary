using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerConsole
{
    public class Book
    {
        public int book_id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string year { get; set; }
        public string genre { get; set; }
        public string available { get; set; }
        public string date_of_issue { get; set; }
        public string user_id { get; set; }
    }
}
