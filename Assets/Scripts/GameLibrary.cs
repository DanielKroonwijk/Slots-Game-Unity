using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public static class GameLibrary
    {
        public static GameInfo gameInfo;
        public static GameObject[] gameObjects;
        public static Symbol[] symbols;
        public static Symbol[,] gameBoard;
        public static Vector3[,] spawnVector;
        public static Vector3[,] onBoardVector;
        public static Vector3[] symbolStopPosition = new Vector3[30];

        public static int gameObjectID = 0;
        public static bool allgameObjectsAssigned = false;
        public static bool gameStartBoard = true;
    } 
}
