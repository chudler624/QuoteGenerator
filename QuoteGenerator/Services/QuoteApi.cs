using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuoteGenerator.Models;
using RestSharp;

namespace QuoteGenerator.Services
{
	public class QuoteApi
	{
		public QuoteApi() { }

		public QuoteModel GetQuote()
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://inspiring-quotes.p.rapidapi.com/random?author=Albert"),
				Headers =

				{
					{ "X-RapidAPI-Key", "fe96c29976msh7164fa7f072bef1p19efc6jsn0ad83cbe2bb2" },
					{ "X-RapidAPI-Host", "inspiring-quotes.p.rapidapi.com" },
				},
			};

			using (var response = client.SendAsync(request).Result)
			{
				response.EnsureSuccessStatusCode();
				var body = response.Content.ReadAsStringAsync().Result;

				var quote = JsonConvert.DeserializeObject<ApiResult>(body);

				var quoteModel = new QuoteModel();

				quoteModel.Quote = quote.quote;
				quoteModel.Author = quote.author;

				return quoteModel;
			}
		}
	}
}
    