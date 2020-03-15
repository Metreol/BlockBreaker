using UnityEngine;

public class Ball : MonoBehaviour {
    // Config vars
    [SerializeField] GameObject paddle = null;
    [SerializeField] AudioClip[] audioClips = null;
    [SerializeField] float launchVelocityX = -1f;
    [SerializeField] float launchVelocityY = 13f;
    [SerializeField] float collisonVelocityModifierRange = 0;

    // Cached references
    private AudioSource audioSource;
    private Rigidbody2D myRigidbody2D;

    // State vars
    private bool launched = false;
    private int clipCount;

    private void Start() {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        clipCount = audioClips.Length;
    }

    void Update() {
        if (!launched && Input.GetMouseButtonDown(0)) {
            LaunchBallOnClick();
        }
        if (!launched) {
            AlignBallToPaddle();
        }
    }

    private void LaunchBallOnClick() {
        launched = true;
        GetComponent<Rigidbody2D>().velocity = new Vector2(launchVelocityX, launchVelocityY);
    }

    private void AlignBallToPaddle() {
        transform.position = new Vector2(paddle.transform.position.x, transform.position.y);
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (launched) {
            modifyVelocityOnCollision();
            audioSource.PlayOneShot(audioClips[Random.Range(0, clipCount)]);
        }
    }

    private void modifyVelocityOnCollision() {
        Vector2 collisionVelocityModifier = new Vector2(
            Random.Range(-collisonVelocityModifierRange, collisonVelocityModifierRange),
            Random.Range(-collisonVelocityModifierRange, collisonVelocityModifierRange));
        myRigidbody2D.velocity += collisionVelocityModifier;
    }
}
