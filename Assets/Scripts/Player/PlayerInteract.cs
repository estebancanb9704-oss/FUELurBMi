using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerInteract : MonoBehaviour {

    private Camera Cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    private InputManager inputManager;
    private void Start() {
        Cam = GetComponent<PlayerLook>().Cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    private void Update() {
        playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(Cam.transform.position, Cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo; //Variable to store collition information 
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
           if(hitInfo.collider.GetComponent<Interactable>() != null) 
           {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                if (inputManager.OnFoot.Interact.triggered) {
                    interactable.BaseInteract();
                }
            }
        }

    }


}

