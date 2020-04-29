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

                Console.WriteLine($"Pokemon Id: {result.Id} \n" +
                    $"Name: {result.Name} \n" +
                    $"Weight: {result.Weight} Hectograms\n" +
                    $"Height: {result.Height} Inches");
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
