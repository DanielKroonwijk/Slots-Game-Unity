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

        public static List<Symbol> removeSymbols = new List<Symbol>();
        public static Vector3[] symbolStopPosition = new Vector3[30];
        public static int gameObjectID = 0;
        public static int destroyOption = 0;
        public static string totalWin = "$  0.00";
        public static bool allgameObjectsAssigned = false;
        public static bool gameStartBoard = true;
        public static bool destroySymbol = false;
        public static bool newBoardInPlace = false;

        public static int betSize = 1;
    } 
}
