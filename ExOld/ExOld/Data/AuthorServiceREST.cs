using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Models;

namespace ExOld.Data
{
    public class AuthorServiceREST : IAuthorService
    {
        private string uri = "http://localhost:5000/Author";
        private HttpClient client;

        public AuthorServiceREST()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            }; 
            client = new HttpClient(clientHandler);
        }
        public async Task<Author> AddAuthor(Author author)
        {
            string UserAsJSON = JsonSerializer.Serialize(author);
            HttpContent content = new StringContent(
                UserAsJSON,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = await client.PostAsync(uri, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($@"Error: {response.ReasonPhrase}");
            }
            
            string result = await response.Content.ReadAsStringAsync();
            Author newAuthor = JsonSerializer.Deserialize<Author>(result, new JsonSerializerOptions{ PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            return newAuthor;
           
        }

        public async Task<IList<Author>> getAuthors()
        {
            
            HttpResponseMessage response =
                await client.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($@"Error: {response.ReasonPhrase}");
            }
            string result = await response.Content.ReadAsStringAsync();
            IList<Author> author = JsonSerializer.Deserialize<IList<Author>>(result, new JsonSerializerOptions{ PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            return author;
        }
    }
}