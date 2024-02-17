using UnityEngine;

public class EndingTrigger : MonoBehaviour {

    [SerializeField] private UIManager ui;

    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent(out Player _) && GameManager.Instance.IsAlive) {
            print("Player");
            ui.PlayWhiteFadeIn();
        }
    }

}
