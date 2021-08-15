using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class StartSpin : MonoBehaviour
    {
        public Text chanceText;
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

                GameLibrary.firstPartDone = true; 
            }
        }

        public void ContinueSpin()
        {
            if (GameElements.CheckHit() == true)
            {
                chanceText.text = GameElements.CalculateSymbolWin(out GameLibrary.removeSymbols);
                GameElements.RemoveSymbols();
            }
            else
            {
                m_SpinActive = false;
            }
        }

        void Update()
        {
            if ((GameLibrary.firstPartDone == true) && (GameLibrary.gameObjectID >= 30))
            {
                GameLibrary.firstPartDone = false;
                GameLibrary.gameObjectID = 0;
                Invoke("ContinueSpin", 3f);
            }
        }
    }
}
