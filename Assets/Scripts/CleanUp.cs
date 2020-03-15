using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        if (FindObjectOfType<GameStats>() != null) {
            Destroy(FindObjectOfType<GameStats>().gameObject);
        }
    }
}
