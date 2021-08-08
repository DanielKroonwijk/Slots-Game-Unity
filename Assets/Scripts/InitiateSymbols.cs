using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assets.Scripts
{
    public class Symbol
    {
        public string symbolName;
        public int symbolChance;
        public double[] symbolPayouts;
        public int multi = 0;
    }

    public class InitiateSymbols
    {
        public void Initiate(GameInfo gameInfo, out Symbol[] symbols)
        {
            var symbolReadLineData = Read(gameInfo);
            var orderedSymbolData = Process(symbolReadLineData);
            symbols = Assign(orderedSymbolData);
        }

        public List<string> Read(GameInfo gameInfo)
        {
            var symbolReadLineData = new List<string>();
            var reader = new StreamReader($"{gameInfo.name}-SymbolsData.txt");
            while (reader.EndOfStream == false)
            {
                symbolReadLineData.Add(reader.ReadLine());
            }

            reader.Close();
            return symbolReadLineData;
        }

        public List<string[]> Process(List<string> symbolReadLineData)
        {
            var orderedSymbolData = new List<string[]>();
            for (int i = 0; i < symbolReadLineData.Count; i++)
            {
                var orderedReadLine = symbolReadLineData[i].Split('|');
                orderedSymbolData.Add(orderedReadLine);
            }

            return orderedSymbolData;
        }

        public Symbol[] Assign(List<string[]> orderedSymbolData)
        {
            var symbols = new Symbol[orderedSymbolData.Count];
            for (int i = 0; i < orderedSymbolData.Count; i++)
            {
                var symbol = new Symbol();
                var symbolData = orderedSymbolData[i];
                symbol.symbolName = symbolData[0].ToString();
                symbol.symbolChance = int.Parse(symbolData[1]);

                var payouts = new double[symbolData.Length - 2];
                for (int p = 0; p < symbolData.Length - 2; p++)
                {
                    payouts[p] = double.Parse(symbolData[p + 2].ToString());
                }

                symbol.symbolPayouts = payouts;
                symbols[i] = symbol;
            }

            return symbols;
        }
    }
}
