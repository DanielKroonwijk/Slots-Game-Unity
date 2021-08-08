using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assets.Scripts
{
    public class Multiplier
    {
        public int multiplierMulti;
        public int multiplierChance;
    }

    public class InitiateMultiplier
    {
        public void Initiate(GameInfo gameInfo, out Multiplier[] multipliers)
        {
            var MultiplierReadLineData = Read(gameInfo);
            var orderedMultiplierData = Process(MultiplierReadLineData);
            multipliers = Assign(orderedMultiplierData);
        }

        public List<string> Read(GameInfo gameInfo)
        {
            var multiplierReadLineData = new List<string>();
            var reader = new StreamReader($"{gameInfo.name}-MultiplierData.txt");
            while (reader.EndOfStream == false)
            {
                multiplierReadLineData.Add(reader.ReadLine());
            }

            reader.Close();
            return multiplierReadLineData;
        }

        public List<string[]> Process(List<string> multiplierReadLineData)
        {
            var orderedMultiplierData = new List<string[]>();
            for (int i = 0; i < multiplierReadLineData.Count; i++)
            {
                var orderedReadLine = multiplierReadLineData[i].Split('|');
                orderedMultiplierData.Add(orderedReadLine);
            }

            return orderedMultiplierData;
        }

        public Multiplier[] Assign(List<string[]> orderedMultiplierData)
        {
            var multipliers = new Multiplier[orderedMultiplierData.Count];
            for (int i = 0; i < orderedMultiplierData.Count; i++)
            {
                var multiplier = new Multiplier();
                var multiplierData = orderedMultiplierData[i];
                multiplier.multiplierMulti = int.Parse(multiplierData[0]);
                multiplier.multiplierChance = int.Parse(multiplierData[1]);
                multipliers[i] = multiplier;
            }

            return multipliers;
        }
    }
}
