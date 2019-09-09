using UnityEngine;
using TMPro;

namespace PeppaSquad.Collectable
{
    public class Collectable : MonoBehaviour
    {
        //Ints to track the amount of gems/cherries currently collected by the player.
        private int _cherriesCollected = 0;
        private int _gemsCollected = 0;

        //Text mesh pro text is used to display the collected gems/cherries to the player in the top right corner of the screen.
        [SerializeField] private TMP_Text _gemsText;
        [SerializeField] private TMP_Text _cherriesText;

        ///<summary>
        /// An ontriggerenter being used to check when the player enters a trigger with the tag Gem or Cherry.
        ///</summary>

        void OnTriggerEnter2D(Collider2D otherCol)
        {
            if (otherCol.tag == "Gem")
            {
                //Triggers the animator on the Gem Object to play the collected animation
                otherCol.gameObject.GetComponent<Animator>().SetTrigger("Collected");
                //Turns off the boxcollider to stop the gem from being gathered twice.
                otherCol.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                //Adds 1 to the gems collected variable
                _gemsCollected++;
                //Updates the text on the screen to match the amount collected
                UpdateText();
                return;
            }
            if (otherCol.tag == "Cherry")
            {
                otherCol.gameObject.GetComponent<Animator>().SetTrigger("Collected");
                otherCol.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                _cherriesCollected++;
                UpdateText();
                return;
            }
        }

        ///<summary>
        /// UpdateText function that sets the text from the TMP to the amount of cherries/gems currently collected after converting the int to a string.
        ///</summary>
        private void UpdateText()
        {
            _cherriesText.text = _cherriesCollected.ToString();
            _gemsText.text = _gemsCollected.ToString();
        }
    }
}
