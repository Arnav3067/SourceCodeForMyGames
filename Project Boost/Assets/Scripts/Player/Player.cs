using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // singleton definition bellow 
    private static Player instance;
    public static Player Instance {
        get {
            if (instance != null) {
                return instance;
            } else {
                Debug.LogError("Player singleton definition: The instance is null");
                return null;
            }
        }
    }

    [SerializeField] private float rotationSpeed = 80;
    [SerializeField] private float boostAmount = 1000;

    private Rigidbody body;
    private Fuel fuel;
    public bool HasFuel {get; private set;} = true;

    #region event declarations

    public event EventHandler OnBoostStart;
    public event EventHandler OnBoostFinish;

    #endregion

    private void Awake() {
        instance = this;
        body = GetComponent<Rigidbody>();
        TryGetComponent(out fuel);

    }

    private void Start() {
        GameInputs.Instance.inputActions.Player.Boost.canceled += OnPlayerBoostCancel;
        GameInputs.Instance.inputActions.Player.Boost.started += OnPlayerBoostStarted;
        fuel.OnFuelFinished += Fuel_OnFuelFinished;
    }

    #region OnEventFire function declarations

    private void Fuel_OnFuelFinished(object sender, EventArgs e) {
        HasFuel = false;
    }

    private void OnPlayerBoostStarted(InputAction.CallbackContext context) {
        OnBoostStart?.Invoke(this, EventArgs.Empty);
    }

    private void OnPlayerBoostCancel(InputAction.CallbackContext context) {
        OnBoostFinish?.Invoke(this, EventArgs.Empty);
    }

    #endregion

    private void Update() {
        HandleMovement();
    }

    private void HandleMovement() {

        // rotation
        float rotationDir = GameInputs.Instance.GetRotationInputs();
        if (rotationDir != 0) {
            transform.Rotate(0f, 0f, rotationDir * rotationSpeed * Time.deltaTime);
        }

        // boost
        float propeller = GameInputs.Instance.GetBoostInputs();
        if (propeller == 1 && HasFuel) {
            body.AddForce(transform.up * propeller * boostAmount * Time.deltaTime, ForceMode.Acceleration);
            fuel.BurnFuel();
        } else {
            fuel.RefillAtRate();
        }
    }

    public void AddForce(Vector3 forceDir, float amount) {
        body.AddForce(forceDir * amount, ForceMode.Impulse);
    }


}
