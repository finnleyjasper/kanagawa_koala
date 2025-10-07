using UnityEngine;

public class HeadBob : MonoBehaviour
{
    [SerializeField] private float distance = 0.05f; // how far it moves up/down
    [SerializeField] private float frequency = 1.5f;  // how fast it bobs

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.localPosition;
    }

    private void Update()
    {
        float bobOffset = Mathf.Sin(Time.time * frequency) * distance;
        transform.localPosition = startPos + new Vector3(0f, bobOffset, 0f);
    }
}
