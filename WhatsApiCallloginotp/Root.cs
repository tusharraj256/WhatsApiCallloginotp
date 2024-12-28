//using System;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;

//public class SmsService
//{
//    private readonly HttpClient _httpClient;

//    // Your provided credentials
//    private const string ApiKey = "4d6f6f542dc0c4f0753fa0fa094476d6cfcb74a7eb51d6a6";
//    private const string ApiToken = "6620d8722eb7a05bff8fe960b9fbe9adbf6c106ef26890ba";
//    private const string Subdomain = "api.exotel.com";
//    private const string AccountSid = "divrajtaxiandrentals1";

//    public SmsService(HttpClient httpClient)
//    {
//        _httpClient = httpClient;
//    }

//    public async Task SendMessageAsync()
//    {
//        // Build the URL with the provided credentials
//        var url = $"https://{Subdomain}/v2/accounts/{AccountSid}/messages";

//        var requestData = new
//        {
//            custom_data = "order12",
//            status_callback = "https://webhook.site",
//            whatsapp = new
//            {
//                messages = new[]
//                {
//                    new
//                    {
//                        from = "+911414937952",  // Updated sender phone number
//                        to = "+6396339291",     // Updated receiver phone number
//                        content = new
//                        {
//                            type = "template",
//                            template = new
//                            {
//                                name = "loginotp",   // Updated template name
//                                language = new
//                                {
//                                    policy = "deterministic",
//                                    code = "en"
//                                },
//                                components = new[]
//                                {
//                                    new
//                                    {
//                                        type = "body",
//                                        parameters = new[]
//                                        {
//                                            new
//                                            {
//                                                type = "text",
//                                                text = "Your OTP is 123456"
//                                            }
//                                        }
//                                    }
//                                }
//                            }
//                        }
//                    }
//                }
//            }
//        };

//        var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

//        // Basic Authentication using the API key and token
//        var authValue = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{ApiKey}:{ApiToken}"));
//        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authValue);

//        try
//        {
//            var response = await _httpClient.PostAsync(url, content);
//            response.EnsureSuccessStatusCode(); // Throws exception if not successful
//            var responseContent = await response.Content.ReadAsStringAsync();
//            Console.WriteLine("Response: " + responseContent);
//        }
//        catch (HttpRequestException ex)
//        {
//            Console.WriteLine("Request failed: " + ex.Message);
//        }
//    }
//}
