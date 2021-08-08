using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{

    public class NormalSpin
    {
        public void Start(GameInfo gameInfo, Symbol[] symbols, GameObject[] gameObjects, out GameObject[,] gameObjectGameBoard)
        {
            GetBoard(gameInfo, symbols, out Symbol[,] symbolGameBoard);
            GetGameObjectBoard(gameInfo, symbols, symbolGameBoard, gameObjects, out gameObjectGameBoard);
        }

        public void GetBoard(GameInfo gameInfo, Symbol[] symbols, out Symbol[,] gameBoard)
        {
            var generateNewBoard = new GenerateNewBoard();
            generateNewBoard.Generate(gameInfo, symbols, out gameBoard);
        }

        public void GetGameObjectBoard(GameInfo gameInfo, Symbol[] symbols, Symbol[,] symbolGameBoard, GameObject[] gameObjects, out GameObject[,] gameObjectGameBoard)
        {
            gameObjectGameBoard = new GameObject[gameInfo.boardColumn, gameInfo.boardRow];
            for (int column = 0; column < gameInfo.boardColumn; column++)
            {
                for (int row = 0; row < gameInfo.boardRow; row++)
                {
                    for (int i = 0; i < symbols.Length; i++)
                    {
                        if (symbolGameBoard[column, row] == symbols[i])
                        {
                            gameObjectGameBoard[column, row] = gameObjects[i];
                            break;
                        }
                    }
                }
            }

        }

        public void Continue()
        {
            double totalWin = 0;
            var checkGameBoard = new CheckGameBoard();
            while (checkGameBoard.CheckHit(GameDataSafe.gameInfo, GameDataSafe.gameObjects, GameDataSafe.gameBoard) == true)
            {
                CheckBoard(totalWin, out List<GameObject> removeGameObjects, out totalWin);
                UpdateBoard(GameDataSafe.gameInfo, GameDataSafe.gameObjects, GameDataSafe.gameBoard, removeGameObjects);            }
        }

        public void CheckBoard(double currentWin, out List<GameObject> removeGameObjects, out double totalWin)
        {
            var checkGameBoard = new CheckGameBoard();
            totalWin = checkGameBoard.CalculateWin(GameDataSafe.gameInfo, GameDataSafe.symbols, GameDataSafe.gameObjects, GameDataSafe.gameBoard, currentWin, GameDataSafe.betSize, out removeGameObjects);
        }

        public void UpdateBoard(GameInfo gameInfo, GameObject[] gameObjects, GameObject[,] gameBoard, List<GameObject> removeGameObjects)
        {
            var updateBoard = new UpdateGameBoard();
            updateBoard.Remove(gameBoard, removeGameObjects);
            updateBoard.Add(gameInfo, gameObjects, gameBoard);
        }
    }
}
