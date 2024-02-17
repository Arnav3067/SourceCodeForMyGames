using UnityEngine;

public class BolderTriggerTwo : MonoBehaviour
{
    [SerializeField] private SphereChase sphere;

    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent(out Player _)) {
            sphere.BlastSphere(15f);
        }
    }
}
