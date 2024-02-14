using System.Collections;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    [SerializeField] private bool canFlicker = true;
    [SerializeField] private float minTimeDelay, maxTimeDelay;

    private Light pointLight;

    private void Awake() {
        TryGetComponent(out pointLight);
    }

    private void Start() {
        if (canFlicker) {
            StartCoroutine(FlickerSequence());
        }
    }

    private IEnumerator FlickerSequence() {
        
        while(true) {
            pointLight.enabled = false;
            yield return new WaitForSeconds(Random.Range(minTimeDelay, maxTimeDelay));
            pointLight.enabled = true;
            yield return new WaitForSeconds(Random.Range(minTimeDelay, maxTimeDelay));
        }
    }
}
