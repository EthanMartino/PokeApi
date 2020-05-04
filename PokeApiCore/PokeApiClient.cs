using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokeApiCore
{
    /// <summary>
    /// Client class to consume PokeApi
    /// https://pokeapi.co/
    /// </summary>
    public class PokeApiClient
    {
        static readonly HttpClient client;

        static PokeApiClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
            client.DefaultRequestHeaders.Add("User-Agent", "Ethan's PokeApi");
        }

        /// <summary>
        /// Retrieve Pokemon by name
        /// </summary>
        /// <exception cref="HttpRequestException"></exception>
        /// <param name="name"></param>
        /// <exception cref="ArgumentException">Thrown when Pokemon is not found</exception>
        /// <returns></returns>
        public async Task<Pokemon> GetPokemonByName(string name)
        {
            name = name.ToLower(); // Pokemon name must be lowercase

            return await GetPokemonByNameOrId(name);
        }

        /// <summary>
        /// Gets a Pokemon by their Pokedex number 
        /// </summary>
        /// <param name="id">The Pokedex Id of the Pokemon</param>
        /// <returns></returns>
        public async Task<Pokemon> GetPokemonById(int id)
        {
            return await GetPokemonByNameOrId(id.ToString());
        }

        private static async Task<Pokemon> GetPokemonByNameOrId(string name)
        {
            string url = $"pokemon/{name}";
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Pokemon>(responseBody);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new ArgumentException($"{name} does not exist.");
            }
            else
            {
                throw new HttpRequestException();
            }
        }
    }
}
