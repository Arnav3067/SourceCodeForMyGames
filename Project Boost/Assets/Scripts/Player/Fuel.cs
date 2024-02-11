using System;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    // singleton definition bellow
    private static Fuel instance;
    public static Fuel fuel {
        get {
            if (instance != null) {
                return instance;
            } else {
                Debug.LogError("Fuel singleton definition: The instance is null");
                return null;
            }
        }
    }

    [SerializeField] private float amount = 50f;
    [SerializeField] private float rate = 0.01f;

    public float Amount {get; private set;}

    private void Awake() {
        instance = this;
    }

    private void Start() {
        Amount = amount;
    }

    public event EventHandler OnFuelFinished;

    private void Update() {
        if (amount <= Mathf.Epsilon) {
            OnFuelFinished?.Invoke(this, EventArgs.Empty);
        }
    }
    
    public void BurnFuel() {
        amount -= rate * Time.deltaTime;
        Amount -= rate * Time.deltaTime;
    }

}
