using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource playerAudioSource;

    // singleton definition bellow
    private static AudioManager instance;
    public static AudioManager Instance {
        get {
            if(instance != null) {
                return instance;
            } else {
                Debug.LogError("AudioManager singleton definition: The instance is null");
                return null;
            }
        }
    }

    private void Awake() {
        instance = this;
    }

    private void Start() {
        Player.Instance.transform.TryGetComponent(out playerAudioSource);
        GameInputs.Instance.OnBoostStart += GameInputs_OnBoostStart;
        GameInputs.Instance.OnBoostFinish += GameInputs_OnBoostFinish;
    }

    #region onEventFire function declarations

    private void GameInputs_OnBoostFinish(object sender, EventArgs e){
        if (playerAudioSource != null) {
            playerAudioSource.Stop();
        }
    }

    private void GameInputs_OnBoostStart(object sender, EventArgs e){
        if (playerAudioSource != null) {
            playerAudioSource.Play();
        }
    }

    #endregion
}
