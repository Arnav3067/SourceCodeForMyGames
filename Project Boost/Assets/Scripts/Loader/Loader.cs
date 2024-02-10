using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public static void RestartCurrentScene() {
        int currentSceneId = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneId);
    }

    public static void LoadNextLevel() {
        int currentSceneId = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneId + 1 == SceneManager.sceneCountInBuildSettings) {
            SceneManager.LoadScene(0);
        } else {
            SceneManager.LoadScene(currentSceneId + 1);
        }
    }
    
}
