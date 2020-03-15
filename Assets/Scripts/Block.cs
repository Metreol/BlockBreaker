using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Block : MonoBehaviour {
    // Config vars
    [SerializeField] AudioClip breakSound = null;
    [SerializeField] GameObject sparkles = null;
    [SerializeField] Sprite[] sprites = null;

    // Cached references
    private static SceneLoader sceneLoader;
    private static GameStats gameStats;

    // State vars
    private static int blockCounter = 0;
    private int health;

    public static void ResetBlockCounter() {
        blockCounter = 0;
    }

    private void Start() {
        /* This tag condition is really stupid as the unbreakable blocks could 
         * just not have the script, but it's how it's done in the course. */
        if (tag != "Unbreakable") {
            health = sprites.Length + 1;
            blockCounter += 1;
        }

        if (sceneLoader == null) {
            sceneLoader = FindObjectOfType<SceneLoader>();
        }

        if (gameStats == null) {
            gameStats = GameStats.GetGameStats();
        }

    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (tag != "Unbreakable") {
            health--;
            if (health <= 0) {
                BlockExplodes();
                if (blockCounter <= 0) {
                    if (!gameStats.IsPractice()) {
                        PrepareNextLevel();
                    } else {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    }
                }
            } else {
                RenderNextSprite();
            }
        }
    }

    private void RenderNextSprite() {
        int spriteIndex = health - 1;
        if (sprites[spriteIndex] != null) {
            GetComponent<SpriteRenderer>().sprite = sprites[spriteIndex];
        } else {
            Debug.LogError(string.Format("Missing sprite at index \"{0}\" in asset \"{1}\"", spriteIndex, gameObject.name));
        }
    }

    private void PrepareNextLevel() {
        gameStats.LevelUp();
        sceneLoader.LoadNextSceneByIndex();
    }

    private void BlockExplodes() {
        AudioSource.PlayClipAtPoint(breakSound, transform.position);
        Destroy(gameObject);
        TriggerSparklesVFX();
        blockCounter--;
    }

    private void TriggerSparklesVFX() {
        GameObject sparklesInstance = Instantiate(sparkles, transform.position, transform.rotation);
        Destroy(sparklesInstance, 2);
    }

}
