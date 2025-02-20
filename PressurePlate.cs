using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject door; // Assign the door in the Inspector
    public bool IsActivated = false; // Track plate activation

    void Start()
    {
        if (door == null)
        {
            door = GameObject.FindWithTag("Door"); // Finds the door by tag
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pushable")) // If box is on the plate
        {
            IsActivated = true;
            door.SetActive(false); // Disable the door (make it disappear)
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Pushable")) // If box moves away
        {
            IsActivated = false;
            door.SetActive(true); // Reappear the door
        }
    }
}
