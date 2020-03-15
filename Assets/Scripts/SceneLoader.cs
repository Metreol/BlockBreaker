using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour {
    // Config vars
    [SerializeField] string nextScene = "StartMenu";

    public void LoadNextSceneByName() {
        SceneManager.LoadScene(nextScene);
    }

    public void LoadNextSceneByIndex() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
