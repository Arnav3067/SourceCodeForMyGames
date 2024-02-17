using UnityEngine;

public class BolderTrigger : MonoBehaviour {

    [SerializeField] private SphereChase sphere;
    [SerializeField] private AudioSource bigExplosionBlastSFX;

    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent(out Player _)) {
            sphere.BlastSphere();
            AudioManager.Instance.PlaySFX(bigExplosionBlastSFX);
            CameraShake.instance.Shake(duration: 0.7f, intensity: 9);
        }
    }
}
