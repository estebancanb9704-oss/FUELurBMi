using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;  

public abstract class Interactable : MonoBehaviour
{
    //Add or remove and intectation event for this game object.
    public bool useEvents; 
    [SerializeField]
    public string promptMessage;

    public virtual string OnLook() {
        return promptMessage;
    }
    public void BaseInteract() {
        if (useEvents)
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        Interact();
    }
    protected virtual void Interact() {
        //nothig here, just a template function to be overridden by a Subclass
    }

}