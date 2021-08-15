using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class StartSpin : MonoBehaviour
    {
        private bool m_FirstPartDone = false;
        private bool m_SpinActive = false;

        public void OnButtonClick()
        {
            if (m_SpinActive == false)
            {
                m_SpinActive = true;
                var initGameBoard = new GenerateNewBoard();
                initGameBoard.Generate(out GameLibrary.gameBoard);
                for (int row = 0; row < GameLibrary.gameInfo.boardRow; row++)
                {
                    for (int column = GameLibrary.gameInfo.boardColumn - 1; column > -1; column--)
                    {
                        Instantiate(
                            GameLibrary.gameBoard[column, row].symbolPrefab,
                            GameLibrary.spawnVector[column, row],
                            GameLibrary.gameObjects[0].transform.rotation);
                    }
                }
                m_FirstPartDone = true; 
            }
        }

        private void FixedUpdate()
        {
            if ((m_FirstPartDone == true) && (GameLibrary.gameObjectID >= 5 * 6))
            {
                m_FirstPartDone = false;
                GameLibrary.gameObjectID = 0;
                if(GameElements.Check() == true)
                {

                }
                else
                {
                    m_SpinActive = false;
                }
            }
        }
    }
}
