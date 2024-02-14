using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameObject pauseMenu;

    private void Awake() {
        pauseMenu = transform.GetChild(2).gameObject;
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

}
