using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public static class GameElements
    {
        public static bool CheckHit()
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

        public static string CalculateSymbolWin(out List<Symbol> removeSymbol)
        {
            double totalWinNumber = 0;
            removeSymbol = new List<Symbol>();
            for (int i = 0; i < GameLibrary.symbols.Length - GameLibrary.gameInfo.bonusSymbols; i++)
            {
                int count = 0;
                var symbol = GameLibrary.symbols[i];
                for (int column = 0; column < GameLibrary.gameBoard.GetLength(0); column++)
                {
                    for (int row = 0; row < GameLibrary.gameBoard.GetLength(1); row++)
                    {
                        if (GameLibrary.gameBoard[column, row].symbolPrefab == symbol.symbolPrefab)
                        {
                            count++;
                        }
                    }
                }

                if (count >= 8)
                {
                    if ((symbol.symbolPrefab != GameLibrary.symbols[0].symbolPrefab) && (symbol.symbolPrefab != GameLibrary.symbols[GameLibrary.symbols.Length - 1].symbolPrefab))
                    {
                        removeSymbol.Add(symbol);

                        if ((count >= 8) && (count <= 9))
                        {
                            totalWinNumber += GameLibrary.symbols[i].symbolPayouts[0] * GameLibrary.betSizes[GameLibrary.betSizeID] / 100;
                        }
                        else if ((count >= 10) && (count <= 11))
                        {
                            totalWinNumber += GameLibrary.symbols[i].symbolPayouts[1] * GameLibrary.betSizes[GameLibrary.betSizeID] / 100;
                        }
                        else
                        {
                            totalWinNumber += GameLibrary.symbols[i].symbolPayouts[2] * GameLibrary.betSizes[GameLibrary.betSizeID] / 100;
                        }
                    }
                }
            }

            if (GameLibrary.gameInfo.bonusActive != true)
            {
                GameLibrary.totalWin += totalWinNumber;
                return $"$ {GameLibrary.totalWin:0.00}";
            }
            else
            {
                GameLibrary.tumbleWin += totalWinNumber;
                return $"$ {GameLibrary.tumbleWin:0.00}";
            }
        }

        public static void RemoveSymbols()
        {
            var count = 0;
            for (int row = 0; row < GameLibrary.gameInfo.boardRow; row++)
            {
                for (int column = GameLibrary.gameInfo.boardColumn - 1; column > -1; column--)
                {
                    for (int i = 0; i < GameLibrary.removeSymbols.Count; i++)
                    {
                        if (GameLibrary.gameBoard[column, row].symbolPrefab == GameLibrary.removeSymbols[i].symbolPrefab)
                        {
                            GameLibrary.gameBoard[column, row] = null;
                            GameLibrary.removeGameObjectID.Add(count);
                            break;
                        }
                    }

                    count++;
                }
            }
        }

        public static void ReAssignSymbolsID()
        {
            for (int row = 0; row < GameLibrary.gameInfo.boardRow; row++)
            {
                for (int column = GameLibrary.gameInfo.boardColumn - 1; column > -1; column--)
                {
                    if (GameLibrary.gameBoard[column, row] == null)
                    {
                        int columnCount = 1;
                        for (; ; )
                        {
                            if ((column != 0) && (column - columnCount > -1))
                            {
                                if (GameLibrary.gameBoard[column - columnCount, row] != null)
                                {
                                    GameLibrary.gameBoard[column, row] = GameLibrary.gameBoard[column - columnCount, row];
                                    GameLibrary.gameBoard[column - columnCount, row] = null;
                                    break;
                                }
                                else
                                {
                                    columnCount++;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        public static void AddNewSymbols()
        {
            for (int row = 0; row < GameLibrary.gameInfo.boardRow; row++)
            {
                for (int column = GameLibrary.gameInfo.boardColumn - 1; column > -1; column--)
                {
                    if (GameLibrary.gameBoard[column, row] == null)
                    {
                        var addSymbols = new GenerateNewBoard();
                        GameLibrary.gameBoard[column, row] = addSymbols.TransformNumber(addSymbols.RandomNumber());
                    }
                }
            }
        }

        public static bool CheckScatters(out double scatterWin)
        {
            int count = 0;
            scatterWin = 0;
            for (int column = 0; column < GameLibrary.gameBoard.GetLength(0); column++)
            {
                for (int row = 0; row < GameLibrary.gameBoard.GetLength(1); row++)
                {
                    if (GameLibrary.gameBoard[column, row] == GameLibrary.symbols[0])
                    {
                        count++;
                        if (count >= 4)
                        {
                            if (count == 4)
                            {
                                scatterWin = GameLibrary.symbols[0].symbolPayouts[0] * GameLibrary.betSizes[GameLibrary.betSizeID] / 100;
                            }
                            else if (count == 5)
                            {
                                scatterWin = GameLibrary.symbols[0].symbolPayouts[1] * GameLibrary.betSizes[GameLibrary.betSizeID] / 100;
                            }
                            else
                            {
                                scatterWin = GameLibrary.symbols[0].symbolPayouts[2] * GameLibrary.betSizes[GameLibrary.betSizeID] / 100;
                            }

                            GameLibrary.gameInfo.bonusActive = true;
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public static void ApplyMultiplier()
        {
            int totalMultiplier = 0;
            for (int column = 0; column < GameLibrary.gameInfo.boardColumn; column++)
            {
                for (int row = 0; row < GameLibrary.gameInfo.boardRow; row++)
                {
                    totalMultiplier += GameLibrary.gameBoard[column, row].multi;
                }
            }

            if (totalMultiplier > 0)
            {
                GameLibrary.tumbleWin *= totalMultiplier;
            }
        }

        public static bool CheckIfBonusRetriggers()
        {
            bool bonusRetrigger = false;
            double totalWin = 0;
            int count = 0;
            var symbol = GameLibrary.symbols[0];
            for (int column = 0; column < GameLibrary.gameBoard.GetLength(0); column++)
            {
                for (int row = 0; row < GameLibrary.gameBoard.GetLength(1); row++)
                {
                    if (GameLibrary.gameBoard[column, row].symbolPrefab == symbol.symbolPrefab)
                    {
                        count++;
                    }
                }
            }

            if (count >= 3)
            {
                bonusRetrigger = true;
                if (count == 4)
                {
                    totalWin =  symbol.symbolPayouts[0] * GameLibrary.betSizes[GameLibrary.betSizeID] / 100;
                }
                else if (count == 5)
                {
                    totalWin = symbol.symbolPayouts[1] * GameLibrary.betSizes[GameLibrary.betSizeID] / 100;
                }
                else if (count != 3)
                {
                    totalWin = symbol.symbolPayouts[2] * GameLibrary.betSizes[GameLibrary.betSizeID] / 100;
                }
            }

            GameLibrary.totalWin += totalWin;
            return bonusRetrigger;
        }
    }
}
