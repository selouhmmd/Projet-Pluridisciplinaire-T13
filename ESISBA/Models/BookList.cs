using System;
using System.Collections.Generic;
using System.Text;

namespace ESISBA.Models
{
    class BookList : List<Book>
    {
        public string Title { get; set; }
        public string ShortTitle { get; set; }
        public BookList(string title , string shortTitle)
        {
            this.Title = title;
            this.ShortTitle = shortTitle;
        }
    }
}
