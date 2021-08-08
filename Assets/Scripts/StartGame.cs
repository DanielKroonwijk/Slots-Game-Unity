using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;


public class StartGame : MonoBehaviour
{
    public Timer timer;
    public InititiateGameObjects initGameObjects;

    void Start()
    {
        Time.timeScale = 3f;
        GameDataSafe.gameInfo = SetGameInfo.Set();
        GameDataSafe.symbols = InitiateGameData.InitSymbols(GameDataSafe.gameInfo);
        GameDataSafe.multipliers = InitiateGameData.InitMultipliers(GameDataSafe.gameInfo);
        GameDataSafe.gameObjects = InitiateGameData.InitGameObjects(initGameObjects);
        GameDataSafe.spawnVectors = InitiateGameData.InitVectors(GameDataSafe.gameInfo, 0);
        GameDataSafe.onBoardVectors = InitiateGameData.InitVectors(GameDataSafe.gameInfo, 1);

        timer.enabled = true;
    }
}


