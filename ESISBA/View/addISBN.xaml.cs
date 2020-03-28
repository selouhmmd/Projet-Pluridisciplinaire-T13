using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scripts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESISBA.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class addISBN : ContentPage
    {
        private SQLiteAsyncConnection connect;
        public addISBN(SQLiteAsyncConnection conn)
        {
            InitializeComponent();
            connect = conn;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var book = Isbn.GetBook(isbn.Text).Result;

            await connect.InsertAsync(book);
            await Navigation.PopAsync();
        }
    }
}