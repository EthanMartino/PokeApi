using Microsoft.VisualBasic.CompilerServices;
using PokeApiCore;
using System;
using System.Threading.Tasks;

namespace PokeApiConsole
{
    class Program
    {
        static async Task Main()
        {
            PokeApiClient client = new PokeApiClient();
            string result = await client.GetPokemonByName("charizard");
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
