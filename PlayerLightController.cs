using UnityEngine;
using UnityEngine.Rendering.Universal;
using TMPro;
using UnityEngine.UI;

public class PlayerLightController : MonoBehaviour
{
    public Light2D playerLight;
    public KeyCode toggleKey = KeyCode.F;
    public float maxEnergy = 100f;
    public float energyDrainRate = 5f;
    public float replenishAmount = 50f;

    public TextMeshProUGUI energyText;  // TextMeshPro for energy display
    public Slider energySlider;  // Optional: To show energy on UI

    private float currentEnergy;
    private bool lightOn = true;

    void Start()
    {
        currentEnergy = maxEnergy;
        playerLight.enabled = lightOn;

        // Call ReplenishEnergy with replenishAmount
        ReplenishEnergy(replenishAmount);

        if (energySlider != null)
        {
            energySlider.maxValue = maxEnergy;
            energySlider.value = currentEnergy;
        }

        if (energyText != null)
        {
            energyText.text = $"Energy: {currentEnergy:F1}";
        }
    }

    void Update()
{
    if (Input.GetKeyDown(toggleKey))
    {
        lightOn = !lightOn;
        playerLight.enabled = lightOn;
    }

    if (lightOn)
    {
        currentEnergy -= energyDrainRate * Time.deltaTime;
        if (currentEnergy <= 0)
        {
            currentEnergy = 0;
            lightOn = false;
            playerLight.enabled = false;
        }
    }

    // Dynamically adjust light intensity based on remaining energy
    playerLight.intensity = Mathf.Lerp(0.2f, 1.5f, currentEnergy / maxEnergy); 

    if (energySlider != null)
    {
        energySlider.value = currentEnergy;
    }

    if (energyText != null)
    {
        energyText.text = $"Energy: {currentEnergy:F1}";
    }
}


    
    public void ReplenishEnergy(float amount)
    {
        currentEnergy = Mathf.Min(currentEnergy + amount, maxEnergy);
        if (!lightOn && currentEnergy > 0)
        {
            lightOn = true;
            playerLight.enabled = true;  
        }

      
        if (energySlider != null)
        {
            energySlider.value = currentEnergy;
        }

        if (energyText != null)
        {
            energyText.text = $"Energy: {currentEnergy:F1}";
        }
    }

    public bool IsLightOn()
{
    return playerLight.enabled;  
}

}
