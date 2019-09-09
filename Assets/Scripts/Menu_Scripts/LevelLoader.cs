using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace PeppaSquad.Menu_Scripts
{
    public class LevelLoader : MonoBehaviour
    {
        //Currently unity loads the game too fast to see the loading process

        //Loading screen object
        [SerializeField] private GameObject loadingScreen;
        //Loading bar slider
        [SerializeField] private Slider slider;
        //Text to display % of loading done
        [SerializeField] private TMP_Text text;

        /// <summary>
        /// Public function activated by a button, starts a coroutine to load the scene indicated by scene index
        /// </summary>
        public void LoadLevel(int sceneIndex)
        {
            StartCoroutine(LoadAsynchronously(sceneIndex));
        }

        /// <summary>
        /// Using coroutine to load scene
        /// </summary>
        private IEnumerator LoadAsynchronously(int sceneIndex)
        {
            //get the async operation for the loading of the scene and set the loadingscreen UI active
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
            loadingScreen.SetActive(true);

            //While the operation isn't done, progress the loading bar and update text/slider
            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                slider.value = progress;
                text.text = progress.ToString();
                loadingScreen.SetActive(false);

                yield return null;
            }
        }
    }
}
