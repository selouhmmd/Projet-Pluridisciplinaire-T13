using ESISBA.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace ESISBA.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddBook : ContentPage
    {
        private string title;
        private string descript;
        private string author;
        private bool Update,t=false,a=false,d=false;
        private Book mbk;
        private SQLiteAsyncConnection _connection;
        public AddBook(SQLiteAsyncConnection connect, Book bk = null)
        {
            InitializeComponent();
            _connection = connect;
            if (bk != null)
            {
                Update = true;
                mbk = bk;
                Title.Text = mbk.Title;
                Author.Text = mbk.Writer;
                Desc.Text = mbk.Description;
                Button.Text = "Update Post";
            }
        }
       

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (Title.Text != "")
            {
                title = Title.Text;
                t = true;
            }
            else
            {
                await DisplayAlert("Fill Out Title", "Fill Out The Title", "ok");
            }

            if (Author.Text != "")
            {
                author = Author.Text;
                a = true;
            }
            else
            {
                await DisplayAlert("Author Empty", "Fill Out The Author Entry", "ok");
            }

            if (Desc.Text != "")
            {
                descript = Desc.Text;
                d = true;
            }
            else
            {
                await DisplayAlert("Description Empty", "Fill Out The Description Entry", "ok");
            }

            if (t && a && d)
            {
                if (Update) {
                        mbk.Title = title;mbk.Description = descript;mbk.Writer = author;
                        await _connection.UpdateAsync(mbk);
                    }
                else
                    {
                        var book = new Book { Title = title, Description = descript, Writer = author, Nbr = 1, Available = 1 };
                        
                }

                await Navigation.PopAsync();
            }
        }

        
    }
}