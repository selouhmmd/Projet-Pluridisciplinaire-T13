using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ESISBA.Models;
using System.Collections.ObjectModel;

namespace ESISBA
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        private ObservableCollection<Book> _books;

        internal ObservableCollection<Book> Books { get => _books; set => _books = value; }

        public MainPage()
        {
            InitializeComponent();
            _books = new ObservableCollection<Book>
            {
                 new Book {Title="Random Book Title",Description="this is a random description,so let's try to write a big paragraph so it can seem like we care",Writer="Random",Nbr=1,Available=1},
                 new Book {Title="Random Title",Description="this is a random description,so let's try to write a big paragraph so it can seem like we care",Writer="Random",Nbr=1,Available=1},
                 new Book{Title="Title Random Book",Description="this is a random description,so let's try to write a big paragraph so it can seem like we care",Writer="Random",Nbr=1,Available=1},
                 new Book{Title="Book Random Title",Description="this is a random description,so let's try to write a big paragraph so it can seem like we care",Writer="Danrom",Nbr=1,Available=1}
            };
            bookList.ItemsSource = _books;
        }

        private void BookList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        { 
            bookList.SelectedItem = null;
        }


        private void FavClicked(object sender, EventArgs e)
        {
            //var mitem = sender as MenuItem;
            //Book bk = mitem.CommandParameter as Book;

        }
        private void DeleteClicked(object sender, EventArgs e)
        {
            var bk = (sender as MenuItem).CommandParameter as Book;
            _books.Remove(bk);
        }

        private void BookList_Refreshing(object sender, EventArgs e)
        {
            // Check The Google Sheets Element
            bookList.EndRefresh();
        }

        private void bookList_ItemTapped_1(object sender, ItemTappedEventArgs e)
        {var book = e.Item as Book;
            DisplayAlert("Selected", book.Title, "Yes");

        }
    }
}
