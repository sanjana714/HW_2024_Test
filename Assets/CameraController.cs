using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform doofus; // Reference to the Doofus object
    public Transform pulpit; // Reference to the current Pulpit object

    public float distance = 10f; // Distance from the midpoint between Doofus and Pulpit
    public float height = 5f; // Height above the midpoint
    public float smoothSpeed = 0.125f; // Smoothing speed for camera movement

    private Vector3 offset;

    void Start()
    {
        // Calculate initial offset
        offset = new Vector3(0, height, -distance);
    }

    void LateUpdate()
    {
        if (doofus != null && pulpit != null)
        {
            // Calculate the midpoint between Doofus and Pulpit
            Vector3 midpoint = (doofus.position + pulpit.position) / 2;

            // Calculate the desired position for the camera
            Vector3 desiredPosition = midpoint + offset;

            // Smoothly move the camera to the desired position
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Optionally, make the camera look at the midpoint between Doofus and Pulpit
            transform.LookAt(midpoint);
        }
    }

    public void UpdatePulpitReference(Transform newPulpit)
    {
        pulpit = newPulpit;
    }
}