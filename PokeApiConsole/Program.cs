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
            Pokemon result = await client.GetPokemonByName("charizard");
            Console.WriteLine($"Pokemon Id: {result.id} \n" +
                $"Name: {result.name} \n" +
                $"Weight: {result.weight} Hectograms\n" +
                $"Height: {result.height} Inches");
            Console.ReadKey();
        }
    }
}
