using UnityEngine;

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
    [SerializeField] private float fuel = 50f;

    private Rigidbody body;

    private void Awake() {
        instance = this;
        body = GetComponent<Rigidbody>();
    }


    private void Update() {
        HandleMovement();
    }

    private void HandleMovement() {
        // rotation
        float rotationDir = GameInputs.Instance.GetInputDirection();
        if (rotationDir != 0) {
            transform.Rotate(0f, 0f, rotationDir * rotationSpeed * Time.deltaTime);
        }

        // boost
        float propeller = GameInputs.Instance.GetBoostInputs();
        if (propeller == 1) {
            body.AddForce(transform.up * propeller * boostAmount * Time.deltaTime, ForceMode.Acceleration);
            BurnFuel();
        } else {
        }
    }

    private void BurnFuel() {
        fuel -= Time.deltaTime;
    }
}
