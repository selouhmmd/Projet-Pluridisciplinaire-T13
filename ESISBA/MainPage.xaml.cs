using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ESISBA.Models;

namespace ESISBA
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var bkList = new List<Book>
            {
                 new Book {Title="Random Book Title",Description="this is a random description,so let's try to write a big paragraph so it can seem like we care",Writer="Random",Nbr=1,Available=1},
                 new Book {Title="Random Title",Description="this is a random description,so let's try to write a big paragraph so it can seem like we care",Writer="Random",Nbr=1,Available=1},
                 new Book{Title="Title Random Book",Description="this is a random description,so let's try to write a big paragraph so it can seem like we care",Writer="Random",Nbr=1,Available=1},
                 new Book{Title="Book Random Title",Description="this is a random description,so let's try to write a big paragraph so it can seem like we care",Writer="Danrom",Nbr=1,Available=1}
            };
            bookList.ItemsSource = bkList;
        }
    }
}
