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
    [SerializeField] private AudioSource explosionSFX;
    [SerializeField] private AudioSource winSFX;
    [SerializeField] private AudioSource boostSFX;
    [SerializeField] private AudioSource outOfFuelSFX;
    
    private void Awake() {
        instance = this;
    }

    private void Start() {
        // event subscriptions
        Player.Instance.OnBoostStart += GameInputs_OnBoostStart;
        Player.Instance.OnBoostFinish += GameInputs_OnBoostFinish;
        PlayerCollisions.Instance.OnPlayerCrash += PlayerCollisions_OnPlayerDeath;
        PlayerCollisions.Instance.OnPlayerVictory += PlayerCollisions_OnPlayerVictory;
        Fuel.fuel.OnFuelFinished += Fuel_OnFuelFinished;
    }

    #region onEventFire function declarations

    private void Fuel_OnFuelFinished(object sender, EventArgs e) {
        StopSFX(boostSFX);
        PlaySFX(outOfFuelSFX);
        Fuel.fuel.OnFuelFinished -= Fuel_OnFuelFinished;
    }

    private void PlayerCollisions_OnPlayerVictory(object sender, EventArgs e) {
        PlaySFX(winSFX);
        PlayerCollisions.Instance.OnPlayerVictory -= PlayerCollisions_OnPlayerVictory;
    }

    private void PlayerCollisions_OnPlayerDeath(object sender, EventArgs e) {
        PlaySFX(explosionSFX);
        if (!Player.Instance.HasFuel) {
            StopSFX(outOfFuelSFX);
        }
        PlayerCollisions.Instance.OnPlayerCrash -= PlayerCollisions_OnPlayerDeath;
    }

    private void GameInputs_OnBoostFinish(object sender, EventArgs e){
        StopSFX(boostSFX);
    }

    private void GameInputs_OnBoostStart(object sender, EventArgs e){
        if (Player.Instance.HasFuel) {
            PlaySFX(boostSFX);
        }
    }

    #endregion

    private void PlaySFX(AudioSource source) {
        if (source != null) {
            source.Play();
        }   
    }

    private void StopSFX(AudioSource source) {
        if (source != null) {
            source.Stop();
        }
    }



    

}
