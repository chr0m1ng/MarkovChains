using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makov_Chains
{
    public class TweetGenerator
    {
        private Dictionary<string, List<string>> chains;
        private Random rnd;
        public TweetGenerator(Dictionary<string, List<string>> chains)
        {
            this.chains = chains;
            rnd = new Random(Guid.NewGuid().GetHashCode());
        }

        public bool UpdateChains(Dictionary<string, List<string>> chains)
        {
            try
            {
                this.chains = chains;
                return true;
            }
            catch(Exception err)
            {
                Console.WriteLine("Error while Updating the Dictionary");
                Console.WriteLine(err.Message);
                return false;
            }
        }

        public String GenerateTweet()
        {
            var key = GetRandomKey();
            var tweet = key + " ";

            while (chains.ContainsKey(key) && tweet.Length < 280)
            {
                var value = GetRandomValue(chains[key]);
                tweet += value + " ";
                key = value;
            }

            return tweet;
        }

        private string GetRandomKey()
        {
            var rndIndex = rnd.Next(0, chains.Keys.Count);
            return chains.Keys.ElementAt(rndIndex);
        }

        private string GetRandomValue(List<string> chain)
        {
            var rndIndex = rnd.Next(0, chain.Count);
            return chain[rndIndex];
        }

    }
}
