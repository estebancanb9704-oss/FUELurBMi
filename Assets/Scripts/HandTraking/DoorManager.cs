using UnityEngine;

public class DoorManager : MonoBehaviour {
    public static DoorManager Instance;

    private Animator animator;

    void Awake() {
        Instance = this;
        animator = GetComponent<Animator>();
    }

    public void OpenDoor() {
        animator.SetTrigger("IsOpen");
    }
}
