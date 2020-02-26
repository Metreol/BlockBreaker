using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour {

    [SerializeField] string nextScene;

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
