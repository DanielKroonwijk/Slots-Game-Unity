using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class SymbolController : MonoBehaviour
    {
        private GameObject m_GameObjectOld;
        private GameObject m_GameObjectNew;
        private int m_Count = 1;
        private bool m_Busy = false;

        private void Update()
        {
            if ((GameLibrary.allgameObjectsAssigned == true) && (m_Busy == false))
            {
                m_GameObjectNew = GameObject.Find($"TargetGameObject{GameLibrary.gameObjectID}");
                m_GameObjectOld = GameObject.Find($"TargetGameObject{GameLibrary.gameObjectID + 100}");

                if ((m_GameObjectNew != null) && (m_GameObjectOld != null) && (m_GameObjectNew.GetComponent<Rigidbody2D>() == null) && (m_GameObjectOld.GetComponent<Rigidbody2D>() == null))
                {
                    m_Busy = true;
                    GameLibrary.symbolStopPosition[GameLibrary.gameObjectID] = m_GameObjectOld.transform.position;
                    GameLibrary.gameObjectID++;

                    m_GameObjectOld.AddComponent<Rigidbody2D>();
                    m_GameObjectNew.AddComponent<Rigidbody2D>();
                }
            }
            else if (GameLibrary.reAssignGameObjectID == true)
            {
                var newGameObject = GameObject.Find($"TargetGameObject{GameLibrary.gameObjectID}");
                if ((newGameObject == null) && (GameLibrary.rowID != 6))
                {
                    GameLibrary.newGameObjectID = GameLibrary.gameObjectID;
                    var chanceGameObject = GameObject.Find($"TargetGameObject{GameLibrary.gameObjectID + m_Count}");
                    if ((chanceGameObject != null) && (GameLibrary.rowGameObjectsID[GameLibrary.rowID].Contains(GameLibrary.gameObjectID + m_Count) == true))
                    {
                        GameLibrary.chanceGameObjectID = GameLibrary.gameObjectID + m_Count;
                    }
                    else
                    {
                        m_Count++;
                    }

                    if ((GameLibrary.rowGameObjectsID[GameLibrary.rowID].Contains(GameLibrary.gameObjectID + m_Count) == false))
                    {
                        Debug.Log("RowInProcess++");
                        m_Count = 1;
                        GameLibrary.rowID++;
                        if (GameLibrary.rowID != 6)
                        {
                            var rowIDs = GameLibrary.rowGameObjectsID[GameLibrary.rowID];
                            GameLibrary.gameObjectID = rowIDs[0];
                        }
                    }
                }
                else if (GameLibrary.rowID == 6)
                {
                    GameLibrary.reAssignGameObjectID = false;
                }
                else
                {
                    m_Count = 1;
                    GameLibrary.gameObjectID++;
                }
            }

            m_Busy = false;
        }  
    }
}
