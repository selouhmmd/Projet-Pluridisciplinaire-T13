using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESISBA.Models
{
    // Must Be Modified After Knowing How To Work With APIs
    public class Book
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Writer { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public int Nbr { get; set; }
        public int Available { get; set; }
        public string Coverurl { get; set; }
    }
}
