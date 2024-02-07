using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInputs playerInput;
    [SerializeField] private float moveSpeed;

    public event EventHandler Bumped;
    
    private void Update() {
        HandleMovement();
    }
    
    private void HandleMovement() {

        Vector2 inputVector = playerInput.GetInputVectorNormalized();       

        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        float playerSize = 1.5f;
        bool canMove = !Physics.BoxCast(transform.position,
                            transform.localScale * 0.5f,
                            moveDir,
                            Quaternion.identity,
                            playerSize);

        if (canMove) 
        {
            transform.position += moveDir * moveSpeed * Time.deltaTime;   
        }
        else 
        {
            Bumped?.Invoke(this, EventArgs.Empty)
        }
    }
}
