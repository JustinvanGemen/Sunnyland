using UnityEngine;

public class PlayerFinish : MonoBehaviour
{
    //Game object in the canvas containing all UI objects.
    [SerializeField] private GameObject _victoryUI;
    //The playermovement script
    [SerializeField] private MovementPlayer _movementPlayer;
    //Private bool tracking if the player has won already
    private bool _won = false;
    //Public bool equal to the private bool
    public bool Won => _won;
    ///<summary>
    /// When triggering a collider, check if the tag of the collider is Victory, if it is; set _won to true to indicate the player won, turn off movement and show the victoryUI
    ///</summary>
    private void OnTriggerEnter2D(Collider2D otherCol)
    {
        if (otherCol.tag == "Victory")
        {
            _won = true;
            _movementPlayer.enabled = false;
            _victoryUI.SetActive(true);
        }
    }
}
