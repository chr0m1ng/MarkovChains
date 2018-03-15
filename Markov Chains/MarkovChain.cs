using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makov_Chains
{
    public class MarkovChain
    {
        public void GenerateChains(string feedText, Dictionary<string, List<string>> chains)
        {
            var words = feedText.Split(' ');

            for(var i = 0; i < words.Length - 1; i++)
            {
                if(!string.IsNullOrEmpty(words[i]))
                {
                    if (chains.ContainsKey(words[i]) && !chains[words[i]].Contains(words[i + 1]))
                        chains[words[i]].Add(words[i + 1]);
                    else if(!chains.ContainsKey(words[i]))
                        chains.Add(words[i], new List<string>() { words[i + 1] });
                }
            }

            Console.WriteLine("Chained");
        }

        private String getWord(string feedText)
        {
            return feedText.Split(' ')[0];
        }
    }
}
