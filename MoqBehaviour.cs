using FrontendMock.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendMock
{
    public class MoqBehaviour
    {
        public static readonly string Url = "https://localhost:32783";

        public static async Task<string> Register(string name, string password, int role)
        {
            HttpMessageHandler handler = new HttpClientHandler();

            using (var client = new HttpClient(handler, false))
            {
                var stringContent = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("accept", "text/plain"),
                });

                var result = (await client.PostAsync($"{Url}/register?username={name}&password={password}&role={role}", stringContent));

                return result.Content.ReadAsStringAsync().Result;
            }
        }

        public static async Task<string> Login(string name, string password)
        {
            HttpMessageHandler handler = new HttpClientHandler();

            using (var client = new HttpClient(handler, false))
            {
                var stringContent = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("accept", "text/plain"),
                });

                var result = (await client.PostAsync($"{Url}/login?username={name}&password={password}", stringContent));

                return result.Content.ReadAsStringAsync().Result;
            }
        }

        public static async Task<string> GetAllUsers()
        {
            HttpMessageHandler handler = new HttpClientHandler();

            using (var client = new HttpClient(handler, false))
            {
                var stringContent = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("accept", "text/plain"),
                });

                var result = (await client.GetAsync($"{Url}/getAllPerson"));

                return result.Content.ReadAsStringAsync().Result;
            }
        }

        public static async Task<string> AppendAgregate(string Id, string Name, int State)
        {
            HttpMessageHandler handler = new HttpClientHandler();

            using (var client = new HttpClient(handler, false))
            {
                var stringContent = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("accept", "application/json"),

                new KeyValuePair<string, string>("Content-Type", "multipart/form-data"),
                new KeyValuePair<string, string>("Id", Id),
                new KeyValuePair<string, string>("Name", Name),
                new KeyValuePair<string, string>("State", State.ToString()),
                });

                var result = (await client.PutAsync($"{Url}/Request/application/AppendAgregate", stringContent));

                Console.WriteLine(result.StatusCode);

                return result.Content.ReadAsStringAsync().Result;
            }
        }

        public static async Task<string> GetAllAgregates()
        {
            HttpMessageHandler handler = new HttpClientHandler();

            using (var client = new HttpClient(handler, false))
            {
                var stringContent = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("accept", "application/json"),
                });

                var result = (await client.GetAsync($"{Url}/Request/application/GetAgregateList"));

                return result.Content.ReadAsStringAsync().Result;
            }
        }

        public static async Task<string> RenameAgregat(string sourceName, string newName)
        {
            HttpMessageHandler handler = new HttpClientHandler();

            using (var client = new HttpClient(handler, false))
            {
                var stringContent = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("accept", "application/json"),
                });

                var result = (await client.PostAsync($"{Url}/Request/application/RenameAgregat?sourceName={sourceName}&newName={newName}", stringContent));

                return result.Content.ReadAsStringAsync().Result;
            }
        }

        public static async Task<string> GetAgregateStateByName(string name)
        {
            HttpMessageHandler handler = new HttpClientHandler();

            using (var client = new HttpClient(handler, false))
            {
                var stringContent = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("accept", "application/json"),
                });

                var result = (await client.GetAsync($"{Url}/Request/application/GetAgregateStateByName?Name={name}"));

                return result.Content.ReadAsStringAsync().Result;
            }
        }

        public static async Task<string> ChangeAgregateStateByName(string name, int state)
        {
            HttpMessageHandler handler = new HttpClientHandler();

            using (var client = new HttpClient(handler, false))
            {
                var stringContent = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("accept", "application/json"),
                });

                var result = (await client.PostAsync($"{Url}/Request/application/ChangeStateByName?name={name}&state={state}", stringContent));

                return result.Content.ReadAsStringAsync().Result;
            }
        }
    }
}