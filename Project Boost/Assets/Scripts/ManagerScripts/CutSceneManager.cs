using System.Collections;
using UnityEngine;

public class CutSceneManager : MonoBehaviour
{
    private void Awake() {
        Cursor.visible = false;
    }

    private void Start() {
        StartCoroutine(ChangeSceneRoutine());
    }

    private IEnumerator ChangeSceneRoutine() {
        yield return new WaitForSeconds(97f);
        Loader.LoadNextLevel();
    }
}
