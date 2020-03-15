using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

public class GameStats : MonoBehaviour {
    // Config vars
    [SerializeField] [Range(0.1f, 2f)] float gameSpeed = 1f;
    [SerializeField] private bool isPractice = false;

    // Cached references
    private TextMeshProUGUI levelTextField;

    // State var
    private int currLevel = 1;

    public void LevelUp() {
        currLevel++;
        levelTextField.text = currLevel.ToString();
    }

    public bool IsPractice() {
        return isPractice;
    }

    public static GameStats GetGameStats() {
        return FindObjectOfType<GameStats>();
    }

    /* This particular functionality is an example of a Singleton,
     * makes itself "DontDestroyOnLoad()" when the first is 
     * initialised and deletes itself if a GameStats obj already exists */
    private void Awake() {
        if (FindObjectsOfType<GameStats>().Length > 1) {
            /* We make the object inactive so that anything that may need this 
             * is aware that it is not available. (Not sure of this, may require some research!) */
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }

        if (levelTextField == null) {
            levelTextField = gameObject.GetComponentInChildren<Transform>().gameObject.GetComponentInChildren<TextMeshProUGUI>();
        }
        levelTextField.GetComponent<TextMeshProUGUI>().text = currLevel.ToString();

    }

    // Update is called once per frame
    void Update() {
        // Start at regular time
        Time.timeScale = gameSpeed;
    }

}
