using System;
using UnityEngine;
using UnityEngine.EventSystems;

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
    [SerializeField] private float minimumFuelThreshold = 0.2f;

    public float Amount {get; private set;}
    public bool isFuelActive {get; private set;} = true; // used for the debug keys;
    private bool noFuel = false;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        Amount = amount;
        JumpPlate.OnPlayerJump += JumpPlate_OnPLayerJump;
    }

    private void JumpPlate_OnPLayerJump(object sender, EventArgs e)
    {
        amount = 1; Amount =1;
    }

    #region event declarations

    public event EventHandler OnFuelFinished;
    public event EventHandler OnFuelLow;
    public event EventHandler OnFuelHigh;

    #endregion

    private void Update() {
        if (amount <= Mathf.Epsilon) {
            noFuel = true;
            OnFuelFinished?.Invoke(this, EventArgs.Empty);
        }
        if (amount <= minimumFuelThreshold) {
            OnFuelLow?.Invoke(this, EventArgs.Empty);
        } else {
            OnFuelHigh?.Invoke(this, EventArgs.Empty);
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
        if (amount <= 1 && Amount <= 1 && !noFuel && isFuelActive) {
            amount += fillRate* Time.deltaTime;
            Amount += fillRate * Time.deltaTime;
        }
    }





}
