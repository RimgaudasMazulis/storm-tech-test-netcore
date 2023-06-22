using System.Net.Http;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Todo.Models.Gravatar;

namespace Todo.Services
{
    public static class Gravatar
    {
        public static string GetHash(string emailAddress)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.Default.GetBytes(emailAddress.Trim().ToLowerInvariant());
                var hashBytes = md5.ComputeHash(inputBytes);

                var builder = new StringBuilder();
                foreach (var b in hashBytes)
                {
                    builder.Append(b.ToString("X2"));
                }
                return builder.ToString().ToLowerInvariant();
            }
        }

        public static async Task<GravatarProfile> GetProfile (string baseAddress, string email)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Todo/1.0");     

                try
                {
                    client.BaseAddress = new Uri(baseAddress);
                    HttpResponseMessage response = await client.GetAsync($"/{Gravatar.GetHash(email)}.json");

                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();

                        return JsonConvert.DeserializeObject<GravatarProfile>(responseBody);
                    }
                    else
                    {
                        Console.WriteLine("API request failed with status code: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }

                return null;
            }
        }
    }
}