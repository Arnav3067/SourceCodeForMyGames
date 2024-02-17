using Cinemachine;
using UnityEngine;

[RequireComponent (typeof(CinemachineVirtualCamera))]

public class CameraShake : MonoBehaviour {

    public static CameraShake instance {get; private set;}

    private CinemachineVirtualCamera virtualCam;
    private CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;
    private float elapsed;

    private void Awake() {
        instance = this;
        virtualCam = GetComponent<CinemachineVirtualCamera>();
        cinemachineBasicMultiChannelPerlin = virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void Shake(float duration = 0.3f, float intensity = 5) {
        elapsed = duration;
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
    }

    private void Update() {
        if (elapsed > 0 ) {
            elapsed -= Time.deltaTime;
            if (elapsed <= 0f) {
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }
        }
    }
}
