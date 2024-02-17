using UnityEngine;
using TetraCreations.Attributes;
using System.Collections;
using System;

public class SpeedPlate : MonoBehaviour
{
    [SerializeField] private bool isPlateActive = false;

    [DrawIf("isPlateActive", true)]
    [SerializeField] private float boostAmount = 0;
    [DrawIf("isPlateActive", true)]
    [SerializeField] private float resetTime = 7;   

    private Animator animator;

    public static event EventHandler OnSpeedCollect;

    private void Awake() {
        TryGetComponent(out animator);
    }

    private void OnCollisionEnter(Collision other) {
        if (other.transform.TryGetComponent(out Player player) && isPlateActive && GameManager.Instance.IsAlive) {
            PlayerCollectSequence(player);
        }
    }

    private void PlayerCollectSequence(Player player) {
        player.ChangeBoostAmount(boostAmount);
        animator.SetTrigger("OnPlayerCollect");
        OnSpeedCollect?.Invoke(this, EventArgs.Empty);
        isPlateActive = false;
        StartCoroutine(BoostAmountResetRoutine(player));
    }

    private IEnumerator BoostAmountResetRoutine(Player player) {
        yield return new WaitForSeconds(resetTime);
        player.RestBoostAmount();
        animator.SetTrigger("OnTimerFinish");
        isPlateActive = true;
    }
}
