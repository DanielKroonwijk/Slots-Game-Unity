using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;


public class Timer : MonoBehaviour
{
    public GameObjectSpawner objectSpawner;
    public bool startSpawnTimer = false;
    public bool spawnTimerDone = false;
    public bool spawnerDone = true;
    public bool startWaitTimer = false;
    public bool waitTimerDone = false;
    public bool startDropTimer = false;
    public bool dropTimerDone = false;
    public bool dropperDone = true;
    public int countColumnSpawner = -10;
    public int countRowSpawner = -10;
    public int countColumnDropper = -10;
    public int countRowDropper = -10;
    public int spawnTimer = 0;
    public int waitTimer = 0;
    public int dropTimer = 0;

    private void FixedUpdate()
    {
        if (startSpawnTimer == true)
        {
            spawnTimer++;
            if (spawnTimer == 60 * 0.05)
            {
                spawnTimerDone = true;
                spawnTimer = 0;
                startSpawnTimer = false;
            }
        }
        else if (spawnTimerDone == true)
        {
            spawnTimerDone = false;
            objectSpawner.Spawn(countColumnSpawner, countRowSpawner);
            if (countColumnSpawner == 0)
            {
                countColumnSpawner = GameDataSafe.gameInfo.boardColumn - 1;
                countRowSpawner++;
            }
            else
            {
                countColumnSpawner--;
            }
        }
        else if (spawnerDone == true)
        {
            countColumnSpawner = GameDataSafe.gameInfo.boardColumn - 2;
            countRowSpawner = 0;
        }

        if (startWaitTimer == true)
        {
            waitTimer++;
            if (waitTimer == 60 * 5)
            {
                waitTimerDone = true;
                waitTimer = 0;
                startWaitTimer = false;
            }
        }
        else if (waitTimerDone == true)
        {
            startWaitTimer = false;
            SpinDataSafe.gameObjectsInPlace = true;
            var spin = new NormalSpin();
            spin.Continue();
        }

        if (startDropTimer == true)
        {
            dropTimer++;
            if (dropTimer == 60 * 0.05)
            {
                dropTimerDone = true;
                dropTimer = 0;
                startDropTimer = false;
            }
        }
        else if(dropTimerDone == true)
        {
            dropTimerDone = false;
            SpinDataSafe.onBoardCoordinates[0] = countColumnDropper;
            SpinDataSafe.onBoardCoordinates[1] = countRowDropper;
            if (countColumnDropper == 0)
            {
                countColumnDropper = GameDataSafe.gameInfo.boardColumn - 1;
                countRowDropper++;
            }
            else
            {
                countColumnDropper--;
            }
        }
        else if(dropperDone == true)
        {
            dropperDone = false;
            countColumnDropper = GameDataSafe.gameInfo.boardColumn - 1;
            countRowDropper = 0;
        }
    }
}

