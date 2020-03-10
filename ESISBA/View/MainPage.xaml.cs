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

namespace ESISBA
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        IEnumerable<Book> GetBooks(string searchtxt = null)
            {
                List<Book> books = new List<Book>
                {
                     new Book{Title="Learning Java",Description="One Of The Most Popular Books In Learning Java",Writer="Random",Nbr=1,Available=1},
                     new Book{Title="Programming With C#",Description="this is a random description,so let's try to write a big paragraph so it can seem like we care",Writer="Random",Nbr=1,Available=1},
                     new Book{Title="Android Studio For Beginners",Description="this is a random description,so let's try to write a big paragraph so it can seem like we care",Writer="Random",Nbr=1,Available=1},
                     new Book{Title="Machine Learning And AI",Description="this is a random description,so let's try to write a big paragraph so it can seem like we care",Writer="Danrom",Nbr=1,Available=1},
                     new Book{Title="Python 3 Advanced",Description="this is a random description,so let's try to write a big paragraph so it can seem like we care",Writer="Danrom",Nbr=1,Available=1},
                     new Book{Title="Xamarin For IOS",Description="this is a random description,so let's try to write a big paragraph so it can seem like we care",Writer="Danrom",Nbr=1,Available=1},
                     new Book{Title="C++ And Graphic Design",Description="this is a random description,so let's try to write a big paragraph so it can seem like we care",Writer="Danrom",Nbr=1,Available=1},
                     new Book{Title="The World Of 3D",Description="this is a random description,so let's try to write a big paragraph so it can seem like we care",Writer="Danrom",Nbr=1,Available=1},
                     new Book{Title="Arduino Pour les nulles",Description="this is a random description,so let's try to write a big paragraph so it can seem like we care",Writer="Danrom",Nbr=1,Available=1},
                     new Book{Title="Electronique Fondamentale",Description="this is a random description,so let's try to write a big paragraph so it can seem like we care",Writer="Danrom",Nbr=1,Available=1},
                     new Book{Title="Analyse Et Algebre",Description="this is a random description,so let's try to write a big paragraph so it can seem like we care",Writer="Danrom",Nbr=1,Available=1},
                     new Book{Title="Probabilite et Statistiques",Description="this is a random description,so let's try to write a big paragraph so it can seem like we care",Writer="Danrom",Nbr=1,Available=1},
                     new Book{Title="Economie D\'entreprise",Description="this is a random description,so let's try to write a big paragraph so it can seem like we care",Writer="Danrom",Nbr=1,Available=1},
                     new Book{Title="Deep Learning",Description="this is a random description,so let's try to write a big paragraph so it can seem like we care",Writer="Danrom",Nbr=1,Available=1},
                     new Book{Title="The Problem With Chess",Description="this is a random description,so let's try to write a big paragraph so it can seem like we care",Writer="Danrom",Nbr=1,Available=1},
                     new Book{Title="Artificial Intelligence",Description="this is a random description,so let's try to write a big paragraph so it can seem like we care",Writer="Danrom",Nbr=1,Available=1}
                };
                if (String.IsNullOrWhiteSpace(searchtxt))
                {
                    return books;
                }

                return books.Where(c => (c.Title.ToLower().Contains(searchtxt.ToLower()) || c.Description.ToLower().Contains(searchtxt.ToLower()) || c.Writer.ToLower().Contains(searchtxt.ToLower())));
            }
        private ObservableCollection<Book> _books;

        internal ObservableCollection<Book> Books { get => _books; set => _books = value; }

        public MainPage()
        {
            

            InitializeComponent();
            
            bookList.ItemsSource = GetBooks();
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
        {
            bookList.ItemsSource = GetBooks(e.NewTextValue);
        }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage());
        }

        private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddBook());
        }
    }

}
