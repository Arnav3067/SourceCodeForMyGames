using UnityEngine.UI;
using UnityEngine;
using System;

public class FuelBar : MonoBehaviour
{
    private Image fuelBar;
    private Animator animator;
    
    private void Awake() {
        TryGetComponent(out animator);
        transform.GetChild(0).TryGetComponent(out fuelBar);
    }

    private void Start() {
        Fuel.fuel.OnFuelFinished += Fuel_OnFuelFinished;
        Fuel.fuel.OnFuelLow += Fuel_OnFuelLow;
        Fuel.fuel.OnFuelHigh += Fuel_OnFuelHigh;
    }

    private void Fuel_OnFuelHigh(object sender, EventArgs e) {
        SetFuelBarLowAnim(false);
    }

    private void Fuel_OnFuelLow(object sender, EventArgs e) {
        SetFuelBarLowAnim(true);
    }

    private void Fuel_OnFuelFinished(object sender, EventArgs e)
    {
        
        Fuel.fuel.OnFuelFinished -= Fuel_OnFuelFinished;
    }

    private void Update() {
       fuelBar.fillAmount = Fuel.fuel.Amount;
    }

    private void SetFuelBarLowAnim(bool isTrue) {
        animator.SetBool("IsFuelLow", isTrue);
    }

    
}
