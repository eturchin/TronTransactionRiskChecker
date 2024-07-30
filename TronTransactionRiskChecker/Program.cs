using Newtonsoft.Json.Linq;

const string transactionHash = "853793d552635f533aa982b92b35b00e63a1c1add062c099da2450a15119bcb2";
const string url = $"https://apilist.tronscan.org/api/transaction-info?hash={transactionHash}";

try
{
    using var client = new HttpClient();
    
    var response = await client.GetAsync(url);
    
    response.EnsureSuccessStatusCode();

    var responseBody = await response.Content.ReadAsStringAsync();
    var transactionData = JObject.Parse(responseBody);
    var riskData = transactionData["riskTransaction"];

    Console.WriteLine($"Risk Data: {riskData}");
}
catch (HttpRequestException e)
{
    Console.WriteLine($"Request error: {e.Message}");
}
catch (Exception e)
{
    Console.WriteLine($"Unexpected error: {e.Message}");
}