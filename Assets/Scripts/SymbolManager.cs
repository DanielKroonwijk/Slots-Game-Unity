using System;
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

            gameObjectSpecificID = GameLibrary.gameObjectID;
            GameLibrary.gameObjectID++;
            if(GameLibrary.gameObjectID == 6 *5 -1)
            {
                if (GameLibrary.gameStartBoard != true)
                {
                    GameLibrary.allgameObjectsAssigned = true;
                }
                GameLibrary.gameObjectID = 0;
            }
        }

        private void Update()
        {
            if((GameLibrary.allgameObjectsAssigned == true) && (GameLibrary.gameObjectID == gameObjectSpecificID) && (m_GameObjectInUse == false))
            {
                m_GameObjectInUse = true;
                if (m_OldGameObject == true)
                {
                    name = $"TargetGameObject{gameObjectSpecificID + 100}";
                    m_GameObjectInUse = true;
                }
                else
                {
                    name = $"TargetGameObject{gameObjectSpecificID}";
                    m_OldGameObject = true;
                    m_GameObjectInUse = false;
                }
            }
        }
    }
}
