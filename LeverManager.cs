using UnityEngine;

public class LeverManager : MonoBehaviour
{
    public Lever[] levers; // Assign all 4 levers in the Inspector
    public GameObject door; // Assign the door in the Inspector

    void Start()
    {
        CheckLevers(); // Initial check
    }

    public void CheckLevers()
    {
        foreach (Lever lever in levers)
        {
            if (!lever.isActivated)
            {
                door.SetActive(true); // Keep door closed if any lever is OFF
                return;
            }
        }
        door.SetActive(false); // Open the door when all levers are ON
    }
}
