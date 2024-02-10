using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
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
    
    private AudioSource audioSource;

    private void Awake() {
        instance = this;
        transform.GetChild(0).transform.TryGetComponent(out audioSource);
    }

    private void Start() {
        // event subscriptions
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
        AudioSource.PlayClipAtPoint(explosionSFX, Camera.main.transform.position);
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
        if (audioSource != null) {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    private void StopSFX() {
        if (audioSource != null) audioSource.Stop();
    }


}
