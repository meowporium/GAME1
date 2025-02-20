using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool isActivated = false; // Track lever state
    public Sprite leverOnSprite;  // Assign "ON" sprite in Inspector
    public Sprite leverOffSprite; // Assign "OFF" sprite in Inspector

    private SpriteRenderer spriteRenderer;
    private LeverManager leverManager;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        leverManager = FindObjectOfType<LeverManager>(); // Find the manager script
        UpdateLeverSprite();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Player interacts with lever
        {
            isActivated = !isActivated; // Toggle ON/OFF
            UpdateLeverSprite();
            leverManager.CheckLevers(); // Notify the manager
        }
    }

    void UpdateLeverSprite()
    {
        spriteRenderer.sprite = isActivated ? leverOnSprite : leverOffSprite;
    }
}
