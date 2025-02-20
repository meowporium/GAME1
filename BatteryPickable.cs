using UnityEngine;

public class BatteryPickable : MonoBehaviour
{
    public float energyAmount = 25f;  // Amount of energy the battery gives
    public AudioClip pickUpSound;     // Optional: Sound to play when picked up

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // If the player collided with the battery
        {
            // Replenish the player's energy by passing the energyAmount
            PlayerLightController playerController = other.GetComponent<PlayerLightController>();
            if (playerController != null)
            {
                playerController.ReplenishEnergy(energyAmount);
            }

            // Play sound if available
            if (pickUpSound != null)
            {
                AudioSource.PlayClipAtPoint(pickUpSound, transform.position);
            }

            // Destroy the battery after it's picked up
            Destroy(gameObject);
        }
    }
}

