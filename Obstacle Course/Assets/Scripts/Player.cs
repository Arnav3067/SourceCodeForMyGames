using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInputs playerInput;
    [SerializeField] private float moveSpeed;

    private void Update() {
        HandleMovement();
    }

    private void HandleMovement() {

        Vector2 inputVector = playerInput.GetInputVectorNormalized();       

        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
}
