using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    ///<summary>
    ///You can use this script with a button to switch between the scenes. The int in the inspector should match the number of the scene in the build settings.
    ///</summary>
    public void LoadLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
