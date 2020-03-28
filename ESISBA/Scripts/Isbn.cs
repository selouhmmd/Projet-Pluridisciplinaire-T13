using ESISBA.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Scripts
{
    class Isbn
    {
        private const string url = "https://www.googleapis.com/books/v1/volumes?q=isbn:";
        

        public static async Task<Book> GetBook(string isbn)
        {
            using (var httpClient = new HttpClient())
            {
                string uri = url + isbn;
                var response = await httpClient.GetAsync(uri).ConfigureAwait(false);

                var test = response;

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        var _elet = JsonConvert.DeserializeObject<RootObject>(json);
                        var book = _elet.items[0].volumeInfo;
                        Book bk = new Book { Title =book.title,Description=book.description,Writer=book.authors[0],ISBN=isbn,Coverurl=_elet.items[0].volumeInfo.imageLinks.thumbnail};
                       return bk;

                    }

                }
                return null;
            }
        }
    }
}
