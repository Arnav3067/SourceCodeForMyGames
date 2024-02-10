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
    
    public PlayerInputActons inputActions {get; private set;}

    #region event declarations

    #endregion

    private void Awake() {
        instance = this;
        inputActions = new PlayerInputActons();
        EnableInputs();
    }

    private void Start() {

        PlayerCollisions.Instance.OnPlayerCrash += DisablePlayerInputs;
        PlayerCollisions.Instance.OnPlayerVictory += DisablePlayerInputs;
    }


    #region onEventCall function declarations

    private void DisablePlayerInputs(object sender, EventArgs e) {
        DisableInputs();
    }
    #endregion

    // returns input for normal rotation (returns 1, 0 or -1)
    public float GetRotationInputs(){
        return inputActions.Player.Rotate.ReadValue<float>();
    }

    // returns input for propelling the player (returns 1 or 0)
    public float GetBoostInputs() {
        return inputActions.Player.Boost.ReadValue<float>();
    }

    public void DisableInputs() {
        inputActions.Player.Disable();
    }

    public void EnableInputs() {
        inputActions.Player.Enable();
    }
}
