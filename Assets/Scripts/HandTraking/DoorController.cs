using UnityEngine;

public class DoorController : MonoBehaviour {
    private Animator animator;

    void Awake() {
        animator = GetComponent<Animator>();
    }

    public void OpenDoor() {
        animator.SetBool("IsOpen", true);
    }

    public void CloseDoor() {
        animator.SetBool("IsOpen", false);
    }
}
