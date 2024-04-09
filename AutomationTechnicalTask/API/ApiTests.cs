using System.Net;
using NUnit.Framework;
using RestSharp;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AutomationTechnicalTask.API
{
    [TestFixture]
    public class ApiTests
    {
        [Test]
        public void VerifyBookDetails()
        {

            // For RestSharp versions 106.11.0 and above
            var client = new RestClient("https://simple-books-api.glitch.me");
            var request = new RestRequest("/books", Method.Get);


            // Execute the request and obtain the response
            // For non-generic response
            var response = client.Execute(request);
            
            // Or for generic response (if you know the response structure)
            // var response = client.Execute<List<Book>>(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Status code is 200");

            // Assuming the response content is a JSON array of objects
             var books = JsonConvert.DeserializeObject<List<dynamic>>(response.Content);

            Assert.IsNotNull(books[0].id, "Response body has id");
            Assert.IsNotNull(books[0].name, "Response body has name");
        }
    }

}

