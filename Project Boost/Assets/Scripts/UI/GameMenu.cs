using UnityEngine.SceneManagement;
using UnityEngine;

public class GameMenu : MonoBehaviour
{

    public void Resume() {
        ResumeTime();
        gameObject.SetActive(false);
    }

    public void Quit() {
        Application.Quit();
    }

    public void Sandbox() {
        ResumeTime();
        int id = SceneManager.GetActiveScene().buildIndex;
        Loader.EnterSandbox(id);   
    }

    public void Return() {
        ResumeTime();
        DebugServices.DisableInputs();
        Loader.ReturnToPreviousScene();
    }

    private void ResumeTime() {
        Time.timeScale = 1;
    }
}

