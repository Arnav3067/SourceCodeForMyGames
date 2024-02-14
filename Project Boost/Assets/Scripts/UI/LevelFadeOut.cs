using System;
using UnityEngine;

public class LevelFadeOut : MonoBehaviour
{
    private Animator animator;

    private void Awake() {
        TryGetComponent(out animator);
    }

    private void Start() {
        PlayerCollisions.Instance.OnPlayerCrash += PlayerCollisions_OnPlayerCrash;
        PlayerCollisions.Instance.OnPlayerVictory += PlayerCollisions_OnPlayerCrash;
    }

    private void PlayerCollisions_OnPlayerCrash(object sender, EventArgs e)
    {
        animator.SetTrigger("OnLevelEnd");
    }
}
