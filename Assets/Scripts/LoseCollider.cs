using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {
    // Cached references
    private GameStats gameStats;

    private void Start() {
        if (gameStats == null) {
            gameStats = GameStats.GetGameStats();
        }
        if (gameStats.IsPractice()) {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!gameStats.IsPractice()) {
            Block.ResetBlockCounter();
            Destroy(gameStats.gameObject);
            SceneManager.LoadScene("GameOver");
        } 
    }
}
