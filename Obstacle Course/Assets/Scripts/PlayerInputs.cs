using System;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    private PlayerInputActions inputActions;
 
    private void Awake() 
    {
        inputActions = new PlayerInputActions();
        inputActions.Enable();
    }

    public Vector2 GetInputVectorNormalized() 
    {
        return inputActions.Player.Move.ReadValue<Vector2>().normalized;
    }
}
