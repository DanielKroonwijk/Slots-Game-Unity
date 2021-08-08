using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class InitiateGameData
    {
        public static Symbol[] InitSymbols(GameInfo gameInfo)
        {
            var initiateSymbols = new InitiateSymbols();
            initiateSymbols.Initiate(gameInfo, out var symbols);
            return symbols;
        }

        public static Multiplier[] InitMultipliers(GameInfo gameInfo)
        {
            var initiateMultipliers = new InitiateMultiplier();
            initiateMultipliers.Initiate(gameInfo, out var multipliers);
            return multipliers;
        }

        public static GameObject[] InitGameObjects(InititiateGameObjects initiateGameObjects)
        {
            var gameObjects = initiateGameObjects.Initiate();
            return gameObjects;
        }

        public static Vector3[,] InitVectors(GameInfo gameInfo, int keyNumber)
        {
            var vectors = new Vectors();
            Vector3[,] setVectors;

            if(keyNumber == 0)
            {
                vectors.SetSpawn(gameInfo, out setVectors);
            }
            else if(keyNumber == 1)
            {
                vectors.SetOnBoard(gameInfo, out setVectors);
            }
            else
            {
                setVectors = new Vector3[0, 0];
                Debug.LogError("KeyNumber Fault Restart Game");
            }

            return setVectors;
        }

        public static bool[,] InitBoardOccupied(GameInfo gameInfo)
        {
            var onBoardOccupied = new bool[gameInfo.boardColumn, gameInfo.boardRow];
            for(int column = 0; column < gameInfo.boardColumn; column++)
            {
                for(int row = 0; row < gameInfo.boardRow; row++)
                {
                    onBoardOccupied[column, row] = false;
                }
            }

            return onBoardOccupied;
        }
    }
}
