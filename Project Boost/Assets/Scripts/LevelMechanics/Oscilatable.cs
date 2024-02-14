using UnityEngine;

public class Oscilatable : MonoBehaviour
{
    [SerializeField] private Vector3 oscillationDir;
    [SerializeField] private float timePeriod = 2f;
    [SerializeField] private float amplitude = 5f;

    private Vector3 startingPos;

    private void Start() {
        startingPos = transform.position;   
    }

    private void Update() {
        Oscillate();
    }

    private void Oscillate() {
        float cycle = Time.time/ timePeriod;
        const float tau = Mathf.PI * 2;
        float moveDir = Mathf.Sin(cycle * tau);

        Vector3 newPos = moveDir * oscillationDir * amplitude;
        transform.position = startingPos + newPos;
    }
}
