using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class GenerateNewBoard
    {
        public void Generate(GameInfo gameInfo, Symbol[] symbols, out Symbol[,] gameBoard)
        {
            gameBoard = Board(gameInfo, symbols);
        }

        public Symbol[,] Board(GameInfo gameInfo, Symbol[] symbols)
        {
            var gameBoardNumber = 0;
            var gameBoardSymbols = new Symbol[gameInfo.boardColumn, gameInfo.boardRow];
            for (int column = 0; column < gameInfo.boardColumn; column++)
            {
                for (int row = 0; row < gameInfo.boardRow; row++)
                {
                    gameBoardNumber = RandomNumber(gameInfo, symbols);
                    gameBoardSymbols[column, row] = TransformNumber(symbols, gameBoardNumber);
                }
            }

            return gameBoardSymbols;
        }

        public int RandomNumber(GameInfo gameinfo, Symbol[] symbols)
        {

            int chance = 0;
            for (int i = 0; i < symbols.Length - gameinfo.bonusSymbols; i++)
            {
                var symbol = symbols[i];
                chance += symbol.symbolChance;
            }

            int randomNumber;

            randomNumber = Random.Range(0, chance - 1);

            return randomNumber;
        }

        public Symbol TransformNumber(Symbol[] symbols, int gameBoardNumber)
        {
            Symbol numberInSymbol = new Symbol();
            int lastHighestNumber = 0;
            for (int i = 0; i < symbols.Length; i++)
            {
                var symbol = symbols[i];
                if ((gameBoardNumber >= lastHighestNumber) && (gameBoardNumber <= symbol.symbolChance + lastHighestNumber - 1))
                {
                    numberInSymbol = symbols[i];
                    lastHighestNumber += symbol.symbolChance;
                }
                else
                {
                    lastHighestNumber += symbol.symbolChance;
                }
            }

            return numberInSymbol;
        }
    }
}
