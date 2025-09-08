using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : Interactable {

    [SerializeField]
    private GameObject door;
    private bool doorOpen;
    private void Start() {
        
    }

    private void Update() { 
    
    }

    protected override void Interact() {
        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);
    }
}
