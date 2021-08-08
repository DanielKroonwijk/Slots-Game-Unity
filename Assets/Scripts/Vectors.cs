using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Vectors
    {

        public void SetSpawn(GameInfo gameInfo, out Vector3[,] vectors)
        {
            int i = 0;
            vectors = new Vector3[gameInfo.boardColumn, gameInfo.boardRow];
            for(int column = 0; column < gameInfo.boardColumn; column++)
            {
                for(int row = 0; row < gameInfo.boardRow; row++)
                {
                    vectors[column, row] = GameObject.Find($"SpawnPoint-{i}").transform.position;
                    i++;
                }
            }
        }

        public void SetOnBoard(GameInfo gameInfo, out Vector3[,] vectors)
        {
            int i = 0;
            vectors = new Vector3[gameInfo.boardColumn, gameInfo.boardRow];
            for (int column = 0; column < gameInfo.boardColumn; column++)
            {
                for (int row = 0; row < gameInfo.boardRow; row++)
                {
                    vectors[column, row] = GameObject.Find($"OnBoardPoint-{i}").transform.position;
                    i++;
                }
            }
        }
    }
}
