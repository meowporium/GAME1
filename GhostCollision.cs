using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with: " + other.gameObject.name);  // Debugging log

        if (other.CompareTag("Player")) 
        {
            Debug.Log("Player Died! Restarting Scene...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
