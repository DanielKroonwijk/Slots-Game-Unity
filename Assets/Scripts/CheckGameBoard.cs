using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class CheckGameBoard
    {
        public bool CheckHit(GameInfo gameInfo, GameObject[] gameObjects, GameObject[,] gameBoard)
        {
            for (int i = 0; i < gameObjects.Length - gameInfo.bonusSymbols; i++)
            {
                int count = 0;
                var gameObject = gameObjects[i];
                for (int column = 0; column < gameBoard.GetLength(0); column++)
                {
                    for (int row = 0; row < gameBoard.GetLength(1); row++)
                    {
                        if (gameBoard[column, row] == gameObject)
                        {
                            count++;
                            if ((count >= 8) && (gameObject != gameObjects[0]))
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        public double CalculateWin(GameInfo gameInfo, Symbol[] symbols, GameObject[] gameObjects, GameObject[,] gameBoard, double totalWin, double betSize, out List<GameObject> removeGameObjects)
        {
            removeGameObjects = new List<GameObject>();
            for (int i = 0; i < gameObjects.Length - gameInfo.bonusSymbols; i++)
            {
                int count = 0;
                var gameObject = gameObjects[i];
                for (int column = 0; column < gameBoard.GetLength(0); column++)
                {
                    for (int row = 0; row < gameBoard.GetLength(1); row++)
                    {
                        if (gameBoard[column, row] == gameObject)
                        {
                            count++;
                        }
                    }
                }

                if (count >= 8)
                {
                    if (gameObject != gameObjects[0])
                    {
                        removeGameObjects.Add(gameObject);
                    }

                    totalWin += CalculatePayout(symbols[i], count, betSize);
                }
            }

            return totalWin;
        }

        private double CalculatePayout(Symbol symbol, int amounOfSymbol, double betSize)
        {
            var symbolPayouts = symbol.symbolPayouts;
            if (symbol.symbolName == "scatter")
            {
                if (amounOfSymbol == 4)
                {
                    return symbolPayouts[0] * betSize / 100;
                }
                else if (amounOfSymbol == 5)
                {
                    return symbolPayouts[1] * betSize / 100;
                }
                else
                {
                    return symbolPayouts[2] * betSize / 100;
                }
            }
            else
            {
                if ((amounOfSymbol >= 8) && (amounOfSymbol <= 9))
                {
                    return symbolPayouts[0] * betSize / 100;
                }
                else if ((amounOfSymbol >= 10) && (amounOfSymbol <= 11))
                {
                    return symbolPayouts[1] * betSize / 100;
                }
                else
                {
                    return symbolPayouts[2] * betSize / 100;
                }
            }
        }
    }
}
