using UnityEngine;

public class RotateBackAndForth : MonoBehaviour
{
    public float rotationAngle = 15f;
    public float rotationSpeed = 2f;

    private float startZ;

    void Start()
    {
        // Store the starting Z rotation
        startZ = transform.localEulerAngles.z;
    }

    void Update()
    {
        // Oscillate between -rotationAngle and +rotationAngle using sine wave
        float angle = Mathf.Sin(Time.time * rotationSpeed) * rotationAngle;
        transform.localEulerAngles = new Vector3(0f, 0f, startZ + angle);
    }
}

