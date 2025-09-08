using UnityEngine;
using UnityEngine.InputSystem; // new Input System

public class ShoppingListToggleUI : MonoBehaviour {
    public GameObject shoppingListPanel;

    private PlayerInput playerInput;
    private InputAction toggleAction;

    void Awake() {
        playerInput = new PlayerInput(); // auto-generated input actions class (we’ll set it up)
    }

    void OnEnable() {
        toggleAction = playerInput.UI.ToggleList;
        toggleAction.Enable();
        toggleAction.performed += TogglePanel;
    }

    void OnDisable() {
        toggleAction.Disable();
    }

    private void TogglePanel(InputAction.CallbackContext context) {
        shoppingListPanel.SetActive(!shoppingListPanel.activeSelf);
    }
}
