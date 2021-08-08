using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;


public class OnClick : MonoBehaviour
{
    public GameObjectSpawner objectSpawner;
    public Timer timer;

    public void OnSingleClick()
    {
        if (GameDataSafe.spinActive == false)
        {
            GameDataSafe.spinActive = true;
            GameDataSafe.onBoardOccupied = InitiateGameData.InitBoardOccupied(GameDataSafe.gameInfo);

            var startSpin = new NormalSpin();
            startSpin.Start(
                GameDataSafe.gameInfo, 
                GameDataSafe.symbols,
                GameDataSafe.gameObjects,
                out GameDataSafe.gameBoard);

            timer.startDropTimer = true;
            objectSpawner.Spawn(GameDataSafe.gameInfo.boardColumn-1, 0);
        }
    }
}
