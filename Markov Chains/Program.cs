using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Makov_Chains
{
    public class Program
    {
        static void Main(string[] args)
        {
            var mc = new MarkovChain();
            var chains = new Dictionary<string, List<string>>();
            var tg = new TweetGenerator(chains);
            var hf = new HandleFile();
            var op = 0;
            do
            {
                DrawMenu();
                op = int.Parse(Console.ReadLine());
                if (op == 1)
                    chains = hf.ReadDictionary(GetFileName());
                if (op == 2)
                     mc.GenerateChains(hf.ReadFile(GetFileName()).Result.ToLower(), chains);
                if(op == 3)
                {
                    if (chains.Count > 0)
                    {
                        tg.UpdateChains(chains);
                        Console.WriteLine(tg.GenerateTweet());
                    }
                    else
                        Console.WriteLine("You need to create a dictionary first");
                }
                if (op == 4)
                {
                    if (chains.Count > 0)
                    {
                        hf.SaveDictionary(GetFileName(), chains);
                        Console.WriteLine("Saved");
                    }
                    else
                        Console.WriteLine("You need to create a dictionary first");

                }
            } while (op != 0);
        }

        private static void DrawMenu()
        {
            Console.WriteLine("Select one Option: ");
            Console.WriteLine("  1 - Load Dictionary");
            Console.WriteLine("  2 - Feed Dictionary");
            Console.WriteLine("  3 - Generate Tweet");
            Console.WriteLine("  4 - Save Dictionary");
            Console.WriteLine("  0 - Exit");
        }

        private static String GetFileName()
        {
            String fileName;

            Console.Write("Name of the file: ");
            fileName = Console.ReadLine();
            
            return "../../" + fileName + ".txt";
        }
    }
}
