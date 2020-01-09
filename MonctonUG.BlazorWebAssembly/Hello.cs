using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MonctonUG.BlazorWebAssembly
{
    public class Hello : IHello
    {
        private readonly HttpClient _client;

        public Hello(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> SayHello(string name)
        {
            var result = await _client.GetAsync("hello/" + name);
            return await result.Content.ReadAsStringAsync();
        }
    }
}
