using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // singleton definition bellow
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

    public bool HasWon {get; private set;} = false;
    public bool IsAlive {get; private set;} = true;

    private float LoadingSceneDelay = 6;

    private void Awake() { 
        instance = this;
    }

    private void Start() {
        PlayerCollisions.Instance.OnPlayerCrash += PlayerCollisions_OnPlayerCrash;
        PlayerCollisions.Instance.OnPlayerVictory += PlayerCollisions_OnPlayerVictory;
    }


    #region OnEventFire function declarations

    private void PlayerCollisions_OnPlayerCrash(object sender, EventArgs e) {  
        IsAlive = false;
        StartCoroutine(PlayerStateRoutine(hasWon: false));
    }

    private void PlayerCollisions_OnPlayerVictory(object sender, EventArgs e) {
        HasWon = true;
        StartCoroutine(PlayerStateRoutine(hasWon: true));
    }

    #endregion

    // used for the coroutine when the PlayerCollisions_OnPlayerDeath function is fired
    private IEnumerator PlayerStateRoutine(bool hasWon = false) {

        yield return new WaitForSeconds(LoadingSceneDelay);
        if (hasWon) LoadNextLevel(); else RestartCurrentScene();
    }
    

    public void LoadNextLevel() {
        Loader.LoadNextLevel();
    }

    public void RestartCurrentScene() {
        Loader.RestartCurrentScene();
    }
}

