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
    [SerializeField] private float fillRate = 0.01f;
    [SerializeField] private float reductionRate = 0.1f;

    public float Amount {get; private set;}
    public bool isFuelActive {get; private set;} = true;

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
        if (isFuelActive) {
            amount -= reductionRate * Time.deltaTime;
            Amount -= reductionRate * Time.deltaTime;
        }
    }

    public void EnableFuel() {
        isFuelActive = true;
    }

    public void DisableFuel() {
        isFuelActive = false;
    }

    public void RefillAtRate() {
        if (amount <= 1 && Amount <= 1) {
            amount += fillRate* Time.deltaTime;
            Amount += fillRate * Time.deltaTime;
        }
    }



}
