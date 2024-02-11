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
    }

    private void Fuel_OnFuelFinished(object sender, EventArgs e)
    {
        animator.SetTrigger("OnOutOfFuel");
        Fuel.fuel.OnFuelFinished -= Fuel_OnFuelFinished;
    }

    private void Update() {
       fuelBar.fillAmount = Fuel.fuel.Amount;
    }

    
}
