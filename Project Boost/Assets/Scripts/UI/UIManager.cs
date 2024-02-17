using UnityEngine;


public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            EnablePauseMenu();
        }
    }  

    private void EnablePauseMenu() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void PlayWhiteFadeIn() {
        animator.SetTrigger("FadeIn");
    }
}
