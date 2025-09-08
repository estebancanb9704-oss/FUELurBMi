using UnityEngine;

public class CursorManager : MonoBehaviour {
    void Start() {
        // Hide cursor
        Cursor.visible = false;

        // Lock cursor to center of screen
        Cursor.lockState = CursorLockMode.Locked;
    }
}

