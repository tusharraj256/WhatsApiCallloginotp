using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class SmsService
{
    public readonly HttpClient _httpClient;

    public const string ApiKey = "Your Api key";// username 
    public const string ApiToken = "Your Api Token";// Password
    public const string Subdomain = "api.exotel.com"; // subDomain according your cluster area 
    public const string AccountSid = "Your sid"; // your Sid

    public SmsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task SendMessageAsync()
    {      
       var url = "https://@api.exotel.com/v2/accounts/{AccountSid}/messages";
        var requestData = new
        {
            whatsapp = new
            {
                messages = new[]
                {
                    new
                    {
                        from = "+91XXXXXXXXXXX",  
                        to = "+91XXXXXXXXXXX",    
                        content = new
                        {
                            type = "template",
                            template = new
                            {
                                name = "loginotp",  
                                language = new
                                {
                                    policy = "deterministic",
                                    code = "en_us"
                                },
                                components = new[]
                                {
                                    new
                                    {
                                        type = "body",
                                        parameters = new[]
                                        {
                                            new
                                            {
                                                type = "text",
                                                text = "12345"
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        };

        //Convert json to  content 
        var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(requestData));

        //set header 
        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        var username = ApiKey; 
        var password = ApiToken; 
        var credentials = $"{username}:{password}";
        var encodedCredentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(credentials));
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", encodedCredentials); 
        
        var response = await _httpClient.PostAsync(url, content);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        Console.WriteLine("Response: " + responseContent);
        
    }
}
class Program
{
    static async Task Main(string[] args)
    {        
        var httpClient = new HttpClient();
        
        var smsService = new SmsService(httpClient);
        await smsService.SendMessageAsync();

        Console.WriteLine("Message sent!");
    }
}
