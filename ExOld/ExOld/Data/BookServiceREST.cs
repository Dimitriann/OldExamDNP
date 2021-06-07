using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using API.Models;

namespace ExOld.Data
{
    public class BookServiceREST : IBookService
    {
        
        private string uri = "https://localhost:5000/Book";
        private HttpClient client;

        public BookServiceREST()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
            client = new HttpClient(clientHandler);
        }

        public async Task<IList<Book>> GetBooks()
        {
            HttpResponseMessage response =
                await client.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($@"Error: {response.ReasonPhrase}");
            }
            string result = await response.Content.ReadAsStringAsync();
            IList<Book> newBook = JsonSerializer.Deserialize<IList<Book>>(result, new JsonSerializerOptions{ PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            return newBook;
        }

        public async Task<Book> AddBook(int AuthorId, Book book)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Book> DeleteBook(int ISBN)
        {
            HttpResponseMessage response =
                await client.DeleteAsync(uri + $"?ISBN={@ISBN}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($@"Error: {response.ReasonPhrase}");
            }
            string result = await response.Content.ReadAsStringAsync();
            
            Book removedBook = JsonSerializer.Deserialize<Book>(result, new JsonSerializerOptions{ PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            return removedBook;
        }
    
}