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
        private bool m_SecondPartDone = false;

        public void OnButtonClick()
        {
            if (GameLibrary.spinActive == false)
            {
                GameLibrary.spinActive = true;
                GameLibrary.gameObjectID = 0;
                GameLibrary.newSpin = true;
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

        public void ContinueSpin1()
        {
            if (GameElements.CheckHit() == true)
            {
                GameLibrary.newSpin = false;
                chanceText.text = GameElements.CalculateSymbolWin(out GameLibrary.removeSymbols);
                GameElements.RemoveSymbols();
                m_SecondPartDone = true;
            }
            else
            {
                GameLibrary.spinActive = false;
            }
        }

        public void ContinueSpin2()
        {
            GameLibrary.destroySymbols = false;
            GameElements.ReAssignSymbolsID();
        }

        void Update()
        {
            if ((GameLibrary.firstPartDone == true) && (GameLibrary.gameObjectID >= 30))
            {
                GameLibrary.firstPartDone = false;
                GameLibrary.gameObjectID = -1;
                Invoke("ContinueSpin1", 3f);
            }
            else if (m_SecondPartDone == true)
            {
                GameLibrary.destroySymbols = true;
                m_SecondPartDone = false;
                Invoke("ContinueSpin2", 3f);
            }
        }
    }
}
