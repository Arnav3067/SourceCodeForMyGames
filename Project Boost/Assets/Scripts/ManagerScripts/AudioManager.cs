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

    // serialized
    [SerializeField] private AudioClip explosionSFX;
    [SerializeField] private AudioClip winSFX;
    [SerializeField] private AudioClip boostSFX;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        // event subscriptions
        Player.Instance.transform.TryGetComponent(out playerAudioSource);
        Player.Instance.OnBoostStart += GameInputs_OnBoostStart;
        Player.Instance.OnBoostFinish += GameInputs_OnBoostFinish;
        PlayerCollisions.Instance.OnPlayerCrash += PlayerCollisions_OnPlayerDeath;
        PlayerCollisions.Instance.OnPlayerVictory += PlayerCollisions_OnPlayerVictory;
    }


    #region onEventFire function declarations

    private void PlayerCollisions_OnPlayerVictory(object sender, EventArgs e) {
        PlaySFX(winSFX);
        PlayerCollisions.Instance.OnPlayerVictory -= PlayerCollisions_OnPlayerVictory;
    }

    private void PlayerCollisions_OnPlayerDeath(object sender, EventArgs e) {
        PlaySFX(explosionSFX);
        PlayerCollisions.Instance.OnPlayerCrash -= PlayerCollisions_OnPlayerDeath;
    }

    private void GameInputs_OnBoostFinish(object sender, EventArgs e){
        StopSFX();
    }

    private void GameInputs_OnBoostStart(object sender, EventArgs e){
        PlaySFX(boostSFX);
    }

    #endregion

    private void PlaySFX(AudioClip clip) {
        if (playerAudioSource != null) {
            playerAudioSource.clip = clip;
            playerAudioSource.Play();
        }
    }

    private void StopSFX() {
        if (playerAudioSource != null) playerAudioSource.Stop();
    }


}
