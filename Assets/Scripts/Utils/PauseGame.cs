using UnityEngine;

public class PauseGame : MonoBehaviour
{
    //UI for the pause menu gathered in 1 game object
    [SerializeField] private GameObject _pauseMenu;

    ///<summary>
    /// Start makes sure the game is unpaused at the beginning of the game
    ///</summary>
    private void Start()
    {
        Unpause();
    }
    ///<summary>
    /// Checks for input to pause the game
    ///</summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Q))
        {
            Pause();
        }
    }
    ///<summary>
    /// Pause sets the timescale to 0 effectively pausing the game, and activates the menu giving the player the option to unpause/check settings or go back to menu.
    ///</summary>
    public void Pause()
    {
        Time.timeScale = 0;
        _pauseMenu.SetActive(true);
    }
    ///<summary>
    /// Simply undoes what Pause did
    ///</summary>
    public void Unpause()
    {
        Time.timeScale = 1;
        _pauseMenu.SetActive(false);
    }
}
