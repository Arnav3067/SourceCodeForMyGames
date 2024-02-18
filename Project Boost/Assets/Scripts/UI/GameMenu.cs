using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour
{
    public void Resume() {
        ResumeTimeAnCursor();
        gameObject.SetActive(false);
    }

    public void Quit() {
        Application.Quit();
    }

    public void Sandbox()
    {
        StartCoroutine(EnterSandboxRoutine());
    }

    public void EnterSandboxFromMainLevels() {
        SandboxSequence();
    }

    private IEnumerator EnterSandboxRoutine()
    {
        yield return new WaitForSeconds(5f);
        SandboxSequence();
    }
    
    private void SandboxSequence() {
        ResumeTimeAnCursor();
        int id = SceneManager.GetActiveScene().buildIndex;
        Loader.EnterSandbox(id);
    }

    public void Return() {
        ResumeTimeAnCursor();
        Cursor.visible = true;
        DebugServices.DisableInputs();
        Loader.ReturnToPreviousScene();
    }

    public void StartGame() {
        StartCoroutine(StartGameRoutine());
    }

    private IEnumerator StartGameRoutine() {
        yield return new WaitForSeconds(4f);
        Loader.LoadLevel(1);
    }

    private void ResumeTimeAnCursor() {
        Cursor.visible = false;
        Time.timeScale = 1;
    }

}

