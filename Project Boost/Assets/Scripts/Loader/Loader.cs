using UnityEngine.SceneManagement;

public static class Loader
{
    private static int requestScene;

    public static void RestartCurrentScene() {
        int currentSceneId = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneId);
    }

    public static void LoadNextLevel() {
        int currentSceneId = SceneManager.GetActiveScene().buildIndex;
        Load(currentSceneId);
    }

    public static void LoadLevel(int buildIndex) {
        SceneManager.LoadScene(buildIndex);
    }
    
    private static void Load(int currentSceneId) {
        if (currentSceneId + 1 == SceneManager.sceneCountInBuildSettings - 1) {
            SceneManager.LoadScene(0);
        } else {
            SceneManager.LoadScene(currentSceneId + 1);
        }
    }

    public static void EnterSandbox(int calledFromScene) {
        SceneManager.LoadScene(3);
        requestScene = calledFromScene;
    }

    public static void ReturnToPreviousScene() {
        SceneManager.LoadScene(requestScene);
    }
}
