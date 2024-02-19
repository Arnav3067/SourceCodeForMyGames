using UnityEngine;

public class EndingTrigger : MonoBehaviour {

    [SerializeField] private UIManager ui;

    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent(out Player _) && GameManager.Instance.IsAlive) {
            ui.PlayWhiteFadeIn();
            Invoke(nameof(CreditSequence), 3); // 8  is the credits scene
        }
    }

    private void CreditSequence() {
        Loader.LoadLevel(8);
    }

}
