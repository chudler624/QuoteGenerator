namespace QuoteGenerator.Services
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ApiResult
    {
        public string quote { get; set; }
        public string author { get; set; }
    }


}
