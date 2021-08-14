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

        public void OnButtonClick()
        {
            
            var initGameBoard = new GenerateNewBoard();
            initGameBoard.Generate(out GameLibrary.gameBoard);
            for (int column = 0; column < GameLibrary.gameInfo.boardColumn; column++)
            {
                for (int row = 0; row < GameLibrary.gameInfo.boardRow; row++)
                {
                    Instantiate(
                        GameLibrary.gameBoard[column, row].symbolPrefab,
                        GameLibrary.spawnVector[column, row],
                        GameLibrary.gameObjects[0].transform.rotation);

                    GameLibrary.symbolControllerActive = true;
                    GameLibrary.wait = true;
                }
            }

            m_FirstPartDone = true;
        }

        private void FixedUpdate()
        {
            if ((m_FirstPartDone == true) && (GameLibrary.wait == false))
            {
                m_FirstPartDone = false;
                if(GameElements.Check() == true)
                {
                    Debug.Log("Less Goo");
                }
            }
        }

        public void OnBuyBonus()
        {

        }
    }
}
