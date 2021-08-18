﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class SymbolManager : MonoBehaviour
    {
        public int gameObjectSpecificID;
        private bool m_GameObjectInUse = false;
        private bool m_OldGameObject = false;

        private void Awake()
        {
            if (GameLibrary.gameStartBoard == true) { m_OldGameObject = true; }

            if (GameLibrary.newSpin == true)
            {
                gameObjectSpecificID = GameLibrary.gameObjectID;
                GameLibrary.gameObjectID++;
                if (GameLibrary.gameObjectID == 6 * 5)
                {
                    if (GameLibrary.gameStartBoard != true)
                    {
                        GameLibrary.allgameObjectsAssigned = true;
                    }
                    GameLibrary.gameObjectID = 0;
                }
            }
            else
            {

            }
        }

        private void Update()
        {
            if ((GameLibrary.allgameObjectsAssigned == true) && (GameLibrary.gameObjectID == gameObjectSpecificID) && (m_GameObjectInUse == false))
            {
                m_GameObjectInUse = true;
                if (m_OldGameObject == true)
                {
                    name = $"TargetGameObject{gameObjectSpecificID + 100}";
                }
                else
                {
                    name = $"TargetGameObject{gameObjectSpecificID}";
                }
            }
            else if (m_GameObjectInUse == true)
            {
                if (transform.position.y <= -10)
                {
                    Destroy(gameObject);
                }
                if ((transform.position.y <= GameLibrary.symbolStopPosition[gameObjectSpecificID].y) && (m_OldGameObject != true))
                {
                    Destroy(GetComponent<Rigidbody2D>());
                    transform.position = GameLibrary.symbolStopPosition[gameObjectSpecificID];
                    m_OldGameObject = true;
                    m_GameObjectInUse = false;
                }
            }
            else if ((GameLibrary.removeGameObjectID.Contains(gameObjectSpecificID)) && (GameLibrary.destroySymbols == true))
            {
                Destroy(gameObject);
            }
            else if (GameLibrary.reAssignGameObjectID == true)
            {
                Debug.Log($"chance: {GameLibrary.chanceGameObjectID}");
                if (GameLibrary.chanceGameObjectID == gameObjectSpecificID)
                {
                    gameObjectSpecificID = GameLibrary.newGameObjectID;
                    name = $"TargetGameObject{gameObjectSpecificID}";
                }
            }
        }
    }
}
