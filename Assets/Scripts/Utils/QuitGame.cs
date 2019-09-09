using UnityEngine;

namespace PeppaSquad.Utils
{
    public class QuitGame : MonoBehaviour
    {
        ///<summary>
        ///Simply quits the game through a button in the menu. 
        ///</summary>
        public void QuittingGame()
        {
            Application.Quit();
        }
    }
}
