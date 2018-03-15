using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Makov_Chains
{
    public class HandleFile
    {
        public async Task<String> ReadFile(string file, bool removeSpecialChars = true)
        {
            String text = "";
            try
            {
                using (StreamReader sr = new StreamReader(file, Encoding.GetEncoding(CultureInfo.GetCultureInfo("pt-BR").TextInfo.ANSICodePage)))
                {
                    text = await sr.ReadToEndAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            if(removeSpecialChars)
                text = Regex.Replace(text, @"\t|\n|\r", " ");
            return text;
        }

        public bool SaveDictionary(string file, Dictionary<string, List<string>> chains)
        {
            string json = JsonConvert.SerializeObject(chains, Formatting.Indented);
            try
            {
                File.WriteAllText(file, json);
                return true;
            }
            catch (Exception err)
            {
                Console.WriteLine("The file could not be saved: ");
                Console.WriteLine(err.Message);
                return false;
            }
        }

        public Dictionary<string, List<string>> ReadDictionary(string file)
        {
            var chains = new Dictionary<string, List<string>>();
            var textDict = "";

            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    textDict = sr.ReadToEnd();
                }

                chains = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(textDict);

            }
            catch (Exception err)
            {
                Console.WriteLine("Error While Reading the Dictionary");
                Console.WriteLine(err.Message);
            }

            return chains;
        }
    }
}
