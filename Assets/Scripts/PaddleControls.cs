using UnityEngine;

public class PaddleControls : MonoBehaviour {
    // Config vars
    [SerializeField] float unityUnitsOnXAxis = 16;

    // Cached references
    private float minXPos;
    private float maxXPos;
    private float paddleYPosInUnits;

    // State vars
    private float newPaddleXPosInUnits;

    void Start() {
        if (maxXPos <= 0) {
            // This is divided by 2 as the center of the screen = 0, so if screen width is 16, the edges are left=-8, right = 8
            maxXPos = unityUnitsOnXAxis/2 - 1;
            minXPos = -maxXPos;
        }
        paddleYPosInUnits = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update() {
        newPaddleXPosInUnits = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        newPaddleXPosInUnits = Mathf.Clamp(newPaddleXPosInUnits, minXPos, maxXPos);
        gameObject.transform.position = new Vector2(newPaddleXPosInUnits, paddleYPosInUnits);


    }
}
