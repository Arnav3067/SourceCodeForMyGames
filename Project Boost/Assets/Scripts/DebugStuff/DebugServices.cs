using UnityEngine;
using UnityEngine.InputSystem;

public class DebugServices : MonoBehaviour
{
    private DebugInputActions inputActions;

    private void Awake() {
        inputActions = new DebugInputActions();
        inputActions.Debug.Enable();
    }

    private void Start() {
        inputActions.Debug.LoadNextLevel.performed += Debug_LoadNextLevel;
        inputActions.Debug.CollisionToggle.performed+= Debug_ToggleCollisions;
    }

    private void Debug_ToggleCollisions(InputAction.CallbackContext context) {
        if (PlayerCollisions.Instance.areCollisionsActive) {
            PlayerCollisions.Instance.DisableCollisions();
        } else {
            PlayerCollisions.Instance.EnableCollisions();
        }
    }


    private void Debug_LoadNextLevel(InputAction.CallbackContext context) {
        GameManager.Instance.LoadNextLevel();
    }
}
