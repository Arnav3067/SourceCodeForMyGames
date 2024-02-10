using System;
using UnityEngine;

public class PlayerCrashVisuals : MonoBehaviour
{
    [SerializeField] private GameObject rBparts;
    [SerializeField] private GameObject normalParts;
    [SerializeField] private GameObject explosion_VFX;
    [SerializeField] private GameObject win_VFX;
    [SerializeField] private GameObject thruster_VFX;

    private float timer = 1.5f;
    
    private void Start() {
        // event subscriptions
        PlayerCollisions.Instance.OnPlayerCrash += PlayerCollisions_OnPlayerCrash;
        PlayerCollisions.Instance.OnPlayerVictory += PlayerCollisions_OnPlayerVictory;
        Player.Instance.OnBoostFinish += Player_OnBoostFinish;
        Player.Instance.OnBoostStart += Player_OnBoostStart;
    }

    private void Player_OnBoostStart(object sender, EventArgs e) {
        if (thruster_VFX != null) thruster_VFX.SetActive(true);
    }

    private void Player_OnBoostFinish(object sender, EventArgs e) {
        if (thruster_VFX != null) thruster_VFX.SetActive(false);
    }

    private void PlayerCollisions_OnPlayerVictory(object sender, EventArgs e) {
       Instantiate(win_VFX, transform.position, transform.rotation);
       PlayerCollisions.Instance.OnPlayerVictory -= PlayerCollisions_OnPlayerVictory;
    }

    private void PlayerCollisions_OnPlayerCrash(object sender, EventArgs e) {
        PlayerExplosionSequence();
        PlayerCollisions.Instance.OnPlayerCrash -= PlayerCollisions_OnPlayerCrash;
    }

    private void PlayerExplosionSequence() {
        GameObject currentExplosion = Instantiate(explosion_VFX, transform.position, transform.rotation);
        Destroy(currentExplosion, timer);
        rBparts.SetActive(true);
        normalParts.SetActive(false);
    }
}
