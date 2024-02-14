using System;
using UnityEngine;

public class JumpPlate : MonoBehaviour
{
    [SerializeField] private float forceAmount = 20;

    public static event EventHandler OnPlayerJump;

    private void OnTriggerEnter(Collider other) {
        if (other.transform.TryGetComponent(out Player player) && GameManager.Instance.IsAlive) {
            PlayerJumped();
            player.AddForce(Vector3.up, forceAmount);
        }
    }

    private void PlayerJumped(){
        OnPlayerJump?.Invoke(this, EventArgs.Empty);
    }
}