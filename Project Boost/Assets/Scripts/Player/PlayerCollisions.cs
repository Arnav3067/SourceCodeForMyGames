using System;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    // singleton definition bellow
    private static PlayerCollisions instance;
    public static PlayerCollisions Instance {
        get {
            if (instance != null) {
                return instance;
            } else {
                Debug.LogError("PLayerCollisions singleton definition: The instance is null"); 
                return null;
            }
        }
    }
    
    #region event declarations

    public event EventHandler OnPlayerCrash;
    public event EventHandler OnPlayerVictory;

    #endregion

    private void Awake() {
        instance = this;
    }

    private enum PlateReference {
        StartPlate,
        EndPlate,
    }

    private void OnCollisionEnter(Collision other) {
        if (other.transform.TryGetComponent(out LevelPlate plate)) {
            if (plate.PlateID == ((int)PlateReference.EndPlate)) {
                // the player won
                if (GameManager.Instance.IsAlive) OnPlayerVictory?.Invoke(this, EventArgs.Empty);
            }
        } else {
            if (!GameManager.Instance.HasWon) OnPlayerCrash?.Invoke(this, EventArgs.Empty);
        }
    }
}