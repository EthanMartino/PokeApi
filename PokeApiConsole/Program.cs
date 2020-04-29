using Microsoft.VisualBasic.CompilerServices;
using PokeApiCore;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokeApiConsole
{
    class Program
    {
        static async Task Main()
        {
            PokeApiClient client = new PokeApiClient();
            try
            {
                //Pokemon result = await client.GetPokemonByName("charizard");
                Pokemon result = await client.GetPokemonById(6);

                Console.WriteLine($"Pokemon Id: {result.id} \n" +
                    $"Name: {result.name} \n" +
                    $"Weight: {result.weight} Hectograms\n" +
                    $"Height: {result.height} Inches");
                Console.ReadKey();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("That pokemon does not exist");
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("Please try again later");
            }
        }
    }
}
