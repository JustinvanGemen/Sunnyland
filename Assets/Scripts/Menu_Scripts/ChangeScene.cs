
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
  public void LoadLevel(int sceneIndex){
        SceneManager.LoadScene(sceneIndex);
    }
}
