using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;


public class GameObjectSpawner : MonoBehaviour
{
    public Timer timer;

    public void Spawn(int column, int row)
    {
        
        if (row <= GameDataSafe.gameInfo.boardRow - 1)
        {
            Instantiate(
                GameDataSafe.gameBoard[column, row],
                GameDataSafe.spawnVectors[column, row],
                GameDataSafe.gameBoard[column, row].transform.rotation);
        }
        else
        {
            row = GameDataSafe.gameInfo.boardRow - 1;
        }

        if ((row == GameDataSafe.gameInfo.boardRow - 1) && (column == 0))
        {
            timer.spawnTimerDone = true;
            timer.waitTimerDone = false;
            timer.startWaitTimer = true;
        }
        else
        {
            timer.spawnTimerDone = false;
            timer.startSpawnTimer = true;
        }
    }

    public void Update()
    {
        if (SpinDataSafe.Spawn == true)
        {
            SpinDataSafe.Spawn = false;
            Spawn(SpinDataSafe.SpawnObjectCoordinates[0], SpinDataSafe.SpawnObjectCoordinates[1]);
        }
    }
}

