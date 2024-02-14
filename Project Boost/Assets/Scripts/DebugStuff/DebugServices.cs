using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DebugServices : MonoBehaviour
{
    private DebugInputActions inputActions;

    private void Awake() {
        inputActions = new DebugInputActions();
        EnableInputs();
    }

    private void Start() {
        inputActions.Debug.LoadNextLevel.performed += Debug_LoadNextLevel;
        inputActions.Debug.CollisionToggle.performed+= Debug_ToggleCollisions;
        inputActions.Debug.FuelToggle.performed += Debug_FuelToggle;
        PlayerCollisions.Instance.OnPlayerCrash += DisableInputs;
        PlayerCollisions.Instance.OnPlayerVictory += DisableInputs;
    }

    private void DisableInputs(object sender, EventArgs e) {
        inputActions.Debug.Disable();
    }

    private void Debug_FuelToggle(InputAction.CallbackContext context) {
        if (Fuel.fuel.isFuelActive) {
            Fuel.fuel.DisableFuel();
        } else {
            Fuel.fuel.EnableFuel();
        }
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

    private void EnableInputs() {
        inputActions.Debug.Enable();
    }
}
