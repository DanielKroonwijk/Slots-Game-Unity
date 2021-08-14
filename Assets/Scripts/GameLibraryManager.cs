using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameLibraryManager : MonoBehaviour
    {
        public InititiateGameObjects initGameObjects;

        void Start()
        {
            initGameObjects.Initiate(out GameLibrary.gameObjects);

            GameLibrary.gameInfo = SetGameInfo.Set();

            var vectors = new Vectors();
            vectors.SetSpawn(out GameLibrary.spawnVector);
            vectors.SetOnBoard(out GameLibrary.onBoardVector);

            GameLibrary.symbols = InitiateSymbols.Initiate();

            var initGameBoard = new GenerateNewBoard();
            initGameBoard.Generate(out GameLibrary.gameBoard);
            while(GameElements.Check() == true) 
            {
                initGameBoard.Generate(out GameLibrary.gameBoard);
            }

            for (int column = 0; column < GameLibrary.gameInfo.boardColumn; column++)
            {
                for (int row = 0; row < GameLibrary.gameInfo.boardRow; row++)
                {
                    Instantiate(
                        GameLibrary.gameBoard[column, row].symbolPrefab,
                        GameLibrary.onBoardVector[column, row],
                        GameLibrary.gameObjects[0].transform.rotation);
                }
            }

            GameLibrary.gameStartBoard = false;
        }
    } 
}
