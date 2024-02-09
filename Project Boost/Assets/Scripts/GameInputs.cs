using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInputs : MonoBehaviour
{  
    // singleton definition bellow 
    private static GameInputs instance;
    public static GameInputs Instance {
        get {
            if (instance != null) {
                return instance;
            } else {
                Debug.LogError("GameInputs singleton Definition: the instance is null!");
                return null;
            }
        }
    }
    
    private PlayerInputActons inputActions;

    #region event declarations

    public event EventHandler OnBoostStart;
    public event EventHandler OnBoostFinish;

    #endregion

    private void Awake() {
        instance = this;
        inputActions = new PlayerInputActons();
        inputActions.Player.Enable();
    }

    private void Start() {
        inputActions.Player.Boost.canceled += OnPlayerBoostCancel;
        inputActions.Player.Boost.started += OnPlayerBoostStarted;
    }

    #region onEventCall function declarations

    private void OnPlayerBoostStarted(InputAction.CallbackContext context) {
        OnBoostStart?.Invoke(this, EventArgs.Empty);
    }

    private void OnPlayerBoostCancel(InputAction.CallbackContext context) {
        OnBoostFinish?.Invoke(this, EventArgs.Empty);
    }

    #endregion

    // returns input for normal rotation (returns 1, 0 or -1)
    public float GetInputDirection(){
        return inputActions.Player.Rotate.ReadValue<float>();
    }

    // returns input for propelling the player (returns 1 or 0)
    public float GetBoostInputs() {
        return inputActions.Player.Boost.ReadValue<float>();
    }
}
