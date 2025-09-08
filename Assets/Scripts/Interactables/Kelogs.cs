using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kelogs : Interactable {

    [SerializeField]
    private GameObject kelogs;
    private bool kelogsGrab;
    private void Start() {

    }

    private void Update() {

    }

    protected override void Interact() {
        kelogsGrab = !kelogsGrab;
        kelogs.GetComponent<Animator>().SetBool("IsOpen", kelogsGrab);
    }
}
