using UnityEngine;

[RequireComponent (typeof(Rigidbody))]

public class SphereChase : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    public void BlastSphere(float _blastAmount = 65f) {
        rb.useGravity = true;
        rb.AddForce(transform.right * _blastAmount, ForceMode.Impulse);
    }
}
