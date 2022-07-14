using FakeTweeter.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FakeTweeter.services
{
    public class ChuckNorrisJokeService
    {
        // Service pour aller requêtter l'API de blagues de chuck norris
        HttpClient client = new HttpClient();

        public async Task<ChuckNorrisJoke> GetRandomJokeAsync()
        {
            var reponse = await client.GetStringAsync("https://api.chucknorris.io/jokes/random");
            var joke = JsonConvert.DeserializeObject<ChuckNorrisJoke>(reponse);
            return joke;
        }
    }
}
