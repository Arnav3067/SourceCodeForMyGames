using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance {
        get {
            if (instance != null) {
                return instance;
            } else {
                Debug.LogError("GameManager singleton definition: The instance is null");
                return null;
            }
        }
    }

    public bool HasWon = false;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        PlayerCollisions.Instance.OnPlayerDeath += PlayerCollisions_OnPlayerDeath;
        PlayerCollisions.Instance.OnPlayerVictory += PlayerCollisions_OnPlayerVictory;
    }


    #region OnEventFire function declarations

    private void PlayerCollisions_OnPlayerDeath(object sender, EventArgs e){
        Player.Instance.transform.GetComponent<Player>().enabled = false;
        
        StartCoroutine(PlayerDeathRoutine());
    }

    private void PlayerCollisions_OnPlayerVictory(object sender, EventArgs e){
        HasWon = true;
        Loader.LoadNextLevel();
    }

    #endregion

    // used for the coroutine when the PlayerCollisions_OnPlayerDeath function is fired
    private IEnumerator PlayerDeathRoutine() {
        
        yield return new WaitForSeconds(5);
        Loader.RestartCurrentScene();
    }

    public void LoadNextLevel() {
        Loader.LoadNextLevel();
    }
}

