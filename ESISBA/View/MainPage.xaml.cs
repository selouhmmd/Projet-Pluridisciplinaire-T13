using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ESISBA.View;
using ESISBA.Models;
using System.Collections.ObjectModel;
using SQLite;
using HelloWorld;

namespace ESISBA
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
    // Google Sheets Thing Here 



    // Google Sheets Thing End Here



    IEnumerable<Book> GetBooks(ObservableCollection<Book> bk,string searchtxt = null)
            {
            // This Is Crashing The App For Some Reason 
                return bk.Where(c => (c.Title.ToLower().Contains(searchtxt.ToLower()) || c.Description.ToLower().Contains(searchtxt.ToLower()) || c.Writer.ToLower().Contains(searchtxt.ToLower())));
            }
        private ObservableCollection<Book> _books;
        private SQLiteAsyncConnection _connection;

        internal ObservableCollection<Book> Books { get => _books; set => _books = value; }

        public MainPage()
        {
            

            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

        }

        private void BookList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        { 
            bookList.SelectedItem = null;
        }

        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<Book>();
            var books = await _connection.Table<Book>().ToListAsync();
            _books = new ObservableCollection<Book>(books);
            bookList.ItemsSource = _books;
        }

        private void FavClicked(object sender, EventArgs e)
        {
            //var mitem = sender as MenuItem;
            //Book bk = mitem.CommandParameter as Book;
        }

        private void BookList_Refreshing(object sender, EventArgs e)
        {
            // Check The Google Sheets Element
            bookList.EndRefresh();
        }

        async void BookList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var book = e.Item as Book;
            await Navigation.PushAsync(new BookView(book));

        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {   // THis Part Is For Aek Research Uncomment The Next Line if you Feel Like The Called Function Is Working And MAke The FUnction A Seperate FIle
            //bookList.ItemsSource = GetBooks(_books,e.NewTextValue);
        }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage());
        }

        private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddBook(_connection));
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var item = sender as MenuItem;
            Book book = item.CommandParameter as Book;
            await Navigation.PushAsync(new AddBook(_connection,book));
        }

        private async void ToolbarItem_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new addISBN(_connection));
        }
    }

}
