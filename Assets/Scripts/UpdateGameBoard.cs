using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class UpdateGameBoard
    {
        public GameObject[,] Remove(GameObject[,] gameBoard, List<GameObject> removeSymbol)
        {
            for (int column = 0; column < gameBoard.GetLength(0); column++)
            {
                for (int row = 0; row < gameBoard.GetLength(1); row++)
                {
                    for (int i = 0; i < removeSymbol.Count; i++)
                    {
                        if (gameBoard[column, row] == removeSymbol[i])
                        {
                            SpinDataSafe.removeGameObject = gameBoard[column, row];
                            gameBoard[column, row] = null;
                            //GameDataSafe.onBoardOccupied[]
                        }
                    }
                }
            }

            return gameBoard;
        }
                    
        public void Add(GameInfo gameInfo, GameObject[] gameObjects, GameObject[,] gameBoard)
        {
            gameBoard = Drop(gameBoard);
            for (int column = 0; column < gameInfo.boardColumn; column++)
            {
                for (int row = 0; row < gameInfo.boardRow; row++)
                {
                    if (gameBoard[column, row] == null)
                    {
                        var updateBoard = new GenerateNewBoard();
                        var symbol = updateBoard.TransformNumber(GameDataSafe.symbols, updateBoard.RandomNumber(gameInfo, GameDataSafe.symbols));
                        for (int i = 0; i < GameDataSafe.symbols.Length; i++)
                        {
                            if (symbol == GameDataSafe.symbols[i])
                            {
                                gameBoard[column, row] = gameObjects[i];
                                SpinDataSafe.SpawnObjectCoordinates[0] = column;
                                SpinDataSafe.SpawnObjectCoordinates[1] = row;
                                SpinDataSafe.Spawn = true;
                                break;
                            }
                        }
                    }
                }
            }

            GameDataSafe.gameBoard = gameBoard;
        }

        public GameObject[,] Drop(GameObject[,] gameBoard)
        {

            for (int row = gameBoard.GetLength(1) - 1; row > -1; row--)
            {
                for (int column = gameBoard.GetLength(0) - 1; column > -1; column--)
                {
                    if (gameBoard[column, row] == null)
                    {
                        int count = 1;
                        for (; ; )
                        {
                            if ((column != 0) && (column - count > -1))
                            {
                                if (gameBoard[column - count, row] != null)
                                {
                                    gameBoard[column, row] = gameBoard[column - count, row];
                                    gameBoard[column - count, row] = null;
                                    break;
                                }
                                else
                                {
                                    count++;
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

            return gameBoard;
        }
    }
}
