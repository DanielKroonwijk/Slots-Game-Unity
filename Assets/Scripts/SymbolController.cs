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
        private Vector3 m_Vector;
        private GameObject m_GameObjectOld;
        private GameObject m_GameObjectNew;
        private bool m_gameObjectOldDone = false;
        private bool m_gameObjectNewDone = false;
        private bool m_Busy = false;

        private void FixedUpdate()
        {

            if ((GameLibrary.allgameObjectsAssigned == true) && (m_Busy == false))
            {
                GameLibrary.gameObjectID = GameLibrary.gameObjectIDReminder;

                if (GameLibrary.symbolControllerActive == true) 
                {
                    m_Busy = true;
                    m_GameObjectNew = GameObject.Find($"TargetGameObject{GameLibrary.gameObjectID}");
                    m_GameObjectOld = GameObject.Find($"TargetGameObject{GameLibrary.gameObjectID + 100}");
                    GameLibrary.gameObjectID = -1;
                    GameLibrary.gameObjectIDReminder++;

                    m_GameObjectOld.AddComponent<Rigidbody2D>();
                    m_GameObjectNew.AddComponent<Rigidbody2D>();
                }

                if (m_Busy == true)
                {
                    if ((m_GameObjectOld.transform.position.y <= 8) && (m_gameObjectOldDone == false))
                    {
                        Destroy(m_GameObjectOld);
                        m_gameObjectOldDone = true;
                    }
                    if ((m_GameObjectNew.transform.position.y < m_Vector.y) && (m_gameObjectNewDone == false))
                    {
                        Destroy(m_GameObjectNew.GetComponent<Rigidbody2D>());
                        m_GameObjectNew.transform.position = m_Vector;
                        m_gameObjectNewDone = true;
                    }
                    if ((m_gameObjectNewDone == true) && (m_gameObjectOldDone == true))
                    {
                        m_Busy = false;
                        m_gameObjectNewDone = false;
                        m_gameObjectOldDone = false;
                        GameLibrary.symbolControllerActive = false;
                        GameLibrary.wait = false;
                    }
                } 
            }
        }
    }
}
