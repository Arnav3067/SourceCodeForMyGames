using UnityEngine;

public class LightTrigger : MonoBehaviour {

    [SerializeField] private GameObject endPlateLight;
    [SerializeField] private AudioSource lightOnSFX;
    
    private void OnTriggerEnter(Collider other) {
        if (other.transform.TryGetComponent(out Player _) && GameManager.Instance.IsAlive) {
            endPlateLight.SetActive(true);
            lightOnSFX.Play();
        }
    }

}
