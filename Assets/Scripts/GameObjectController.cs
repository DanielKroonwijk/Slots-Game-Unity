using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class GameObjectController : MonoBehaviour
{
    private bool m_Assigned = false;
    private bool m_DoTask = false;
    private int m_Column = -1;
    private int m_Row;

    private void Update()
    {
        for (int row = 0; row < GameDataSafe.gameInfo.boardRow; row++)
        {
            for (int column = GameDataSafe.gameInfo.boardColumn - 1; column > -1; column--)
            {
                if ((m_Assigned == false) && (GameDataSafe.onBoardOccupied[column, row] == false) && (m_Column == -1))
                {
                    GameDataSafe.onBoardOccupied[column, row] = true;
                    m_Assigned = true;
                    m_Column = column;
                    m_Row = row;
                }
            }
        }

        if((SpinDataSafe.onBoardCoordinates[0] == m_Column) && (SpinDataSafe.onBoardCoordinates[1] == m_Row))
        {
            m_DoTask = true;
        }
        //else if(GameDataSafe.onBoardOccupied[m_Column])

        if ((m_Assigned == true) && (transform.position.y <= GameDataSafe.onBoardVectors[m_Column, m_Row].y))
        {
            m_Assigned = false;
            Destroy(GetComponent<Rigidbody2D>());
            transform.position = GameDataSafe.onBoardVectors[m_Column, m_Row];
        }
        else if ((SpinDataSafe.gameObjectsInPlace == true) && (m_DoTask == true))
        {
            m_DoTask = false;
            gameObject.AddComponent<Rigidbody2D>();
        }

        if (transform.position.y <= -7)
        {
            Destroy(gameObject);
        }
        else if(SpinDataSafe.removeGameObject == gameObject)
        {
            Destroy(gameObject);
        }
    }
}
