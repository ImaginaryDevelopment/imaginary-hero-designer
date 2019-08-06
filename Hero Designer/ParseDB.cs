using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Base;
using Newtonsoft.Json.Linq;

namespace Hero_Designer
{
    public class ParseDb
    {
        public IList<string> PowerIndexes { get; private set; }

        public async Task GetIndexesFromJson(string output)
        {
            string[] files = Directory.GetFiles("data\\db\\", "*.json", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                PowerIndexes = new List<string>();
                var jData = File.ReadAllText(file);
                var jItems = JObject.Parse(jData);
                var indexes =
                    from p in jItems["Powers"]
                    select new
                    {
                        Index = p["StaticIndex"].ToStringOrNull(),
                        Name = (string) p["FullName"]
                    };
                foreach (var item in indexes)
                {
                    if (!string.IsNullOrWhiteSpace(item.Index))
                    {
                        PowerIndexes.Add($"{item.Index},{item.Name}");
                    }
                }
                var ordered = PowerIndexes.OrderByDescending(s => long.Parse(Regex.Match(s, @"^(\d+)").Value)).ToList();
                if (!File.Exists(output))
                {
                    using (StreamWriter writer = File.CreateText(output))
                    {
                        foreach (string index in ordered)
                        {
                            await writer.WriteLineAsync($"{index}");
                        }
                    }
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter(output, true))
                    {
                        foreach (string index in ordered)
                        {
                            await writer.WriteLineAsync($"{index}");
                        }
                    }
                }
            }
        }
    }
}