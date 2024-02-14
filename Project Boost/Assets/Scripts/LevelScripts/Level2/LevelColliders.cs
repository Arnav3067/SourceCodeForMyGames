using System.Collections;
using UnityEngine;

public class LightReduction : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;

    private int counter1, counter2 = 0;

    private void OnTriggerEnter(Collider other) {
        if (other.transform.TryGetComponent(out Player _)) {

            

            if (animator != null && counter1 < 1) {
                counter1 ++; // to make sure it only plays once
                animator.SetTrigger("ReduceLights");
            }

            if (audioSource != null && counter2 < 1) {
                counter2 ++; // to make sure it only plays once
                audioSource.Play();
                StartCoroutine(LevelTwoEndingSequence());
            }

        }
    }

    private IEnumerator LevelTwoEndingSequence() {
        yield return new WaitForSeconds(7.1f);
        GameManager.Instance.LoadNextLevel();
    }
}
