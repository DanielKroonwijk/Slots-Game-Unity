using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public static class GameDataSafe
    {
        public static GameInfo gameInfo;
        public static Symbol[] symbols;
        public static Multiplier[] multipliers;
        public static GameObject[] gameObjects;
        public static GameObject[,] gameBoard;
        public static Vector3[,] spawnVectors;
        public static Vector3[,] onBoardVectors;
        public static bool[,] onBoardOccupied;
        public static bool spinActive;
        public static double betSize = 1;
    }

    public static class SpinDataSafe 
    {
        public static bool newSpin = false;
        public static bool Spawn = false;
        public static bool gameObjectsInPlace;
        public static int[] onBoardCoordinates = new int[2];
        public static int[] SpawnObjectCoordinates = new int[2];
        public static GameObject removeGameObject;
    }

}
