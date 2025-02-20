using UnityEngine;

public class DoorController : MonoBehaviour
{
    public PressurePlate pressurePlate; // Assign in Inspector
    private Collider2D doorCollider; // Store reference to collider

    void Start()
    {
        doorCollider = GetComponent<Collider2D>(); // Get door collider
    }

    void Update()
    {
        if (pressurePlate != null && pressurePlate.IsActivated)
        {
            gameObject.SetActive(false); // Hide the door
            doorCollider.enabled = false; // Disable collision
        }
        else
        {
            gameObject.SetActive(true); // Show the door
            doorCollider.enabled = true; // Enable collision
        }
    }
}
