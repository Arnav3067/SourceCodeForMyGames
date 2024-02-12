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
    [SerializeField] private AudioSource jumpSFX;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        // event subscriptions
        Player.Instance.OnBoostStart += GameInputs_OnBoostStart;
        Player.Instance.OnBoostFinish += GameInputs_OnBoostFinish;
        PlayerCollisions.Instance.OnPlayerCrash += PlayerCollisions_OnPlayerDeath;
        PlayerCollisions.Instance.OnPlayerVictory += PlayerCollisions_OnPlayerVictory;
        Fuel.fuel.OnFuelLow += Fuel_OnFuelLow;
        Fuel.fuel.OnFuelHigh += Fuel_OnFuelHigh;
        JumpPlate.OnPlayerJump += JumpPlate_OnPlayerJump;
    }

    private void JumpPlate_OnPlayerJump(object sender, EventArgs e) {
        PlaySFX(jumpSFX);
    }

    #region onEventFire function declarations

    private void Fuel_OnFuelLow(object sender, EventArgs e) {
        if (!outOfFuelSFX.isPlaying) PlaySFX(outOfFuelSFX);
    }

    private void Fuel_OnFuelHigh(object sender, EventArgs e) {
        if (outOfFuelSFX.isPlaying) StopSFX(outOfFuelSFX);
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
