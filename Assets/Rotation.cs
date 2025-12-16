using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [Header("Rotation Settings")]
    [Tooltip("Degrees per second on each axis (set to 0 to disable that axis).")]
    public Vector3 rotationSpeed = Vector3.zero;

    [Header("Movement Settings")]
    [Tooltip("Direction and speed of motion in units/second (set to 0 to disable that axis).")]
    public Vector3 movementSpeed = Vector3.zero;

    [Tooltip("If true, movement is relative to object; if false, movement is world-based.")]
    public bool useLocalMovement = false;

    [Tooltip("Maximum distance (in Unity units) to move before returning.")]
    public float movementDistance = 2f;

    private Quaternion startRotation;
    private Vector3 startPosition;
    private float rotX, rotY, rotZ;
    private float moveTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startRotation = transform.localRotation;
        startPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        HandleRotation();
        HandleMovement();
    }
    void HandleRotation()
    {
        if (rotationSpeed.x != 0) rotX += rotationSpeed.x * Time.deltaTime;
        if (rotationSpeed.y != 0) rotY += rotationSpeed.y * Time.deltaTime;
        if (rotationSpeed.z != 0) rotZ += rotationSpeed.z * Time.deltaTime;

        transform.localRotation = startRotation * Quaternion.Euler(rotX, rotY, rotZ);
    }

    void HandleMovement()
    {
        if (movementSpeed == Vector3.zero) return;

        // Create a ping-pong cycle (go out and back)
        moveTimer += Time.deltaTime;

        // This gives a value that oscillates between 0 and 1
        float t = Mathf.PingPong(moveTimer * movementSpeed.magnitude / movementDistance, 1f);

        // Move between start and end position
        Vector3 offset = movementSpeed.normalized * movementDistance * t;

        if (useLocalMovement)
            transform.localPosition = startPosition + transform.TransformDirection(offset);
        else
            transform.localPosition = startPosition + offset;
    }
}
