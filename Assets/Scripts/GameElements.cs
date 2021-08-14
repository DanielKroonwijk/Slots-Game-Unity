using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public static class GameElements
    {
        public static bool Check()
        {
            for (int i = 0; i < GameLibrary.symbols.Length - GameLibrary.gameInfo.bonusSymbols; i++)
            {
                int count = 0;
                var symbol = GameLibrary.symbols[i];
                for (int column = 0; column < GameLibrary.gameBoard.GetLength(0); column++)
                {
                    for (int row = 0; row < GameLibrary.gameBoard.GetLength(1); row++)
                    {
                        if (GameLibrary.gameBoard[column, row].symbolPrefab == GameLibrary.gameObjects[i])
                        {
                            count++;
                            if ((count >= 8) && (symbol.symbolPrefab != GameLibrary.gameObjects[0]))
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        
    }
}
