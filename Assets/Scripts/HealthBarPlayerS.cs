using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPlayerS : MonoBehaviour
{
    public PlayerScript player;
    public Image fill;
    public Slider healthSlider;
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        SetSize(player.currentHP, player.maxHP);
    }

    // Update is called once per frame
    void Update()
    {
        float healthPercentage = player.currentHP / player.maxHP;
        if (healthPercentage <= 0.9f)
        {
            fill.color = new Color(0.647f, 1f, 0f, 1);
        }
        if (healthPercentage <= 0.5f)
        {
            fill.color = new Color(1f, 1f, 0f, 1);
        }
        if (healthPercentage <= 0.3f)
        {
            fill.color = new Color(1f, 0f, 0f, 1);
        }
        if (healthPercentage <= 0.15f)
        {
            fill.color = new Color(0.75f, 0f, 0f, 1);
        }

        if (healthPercentage > 0.9f)
        {
            fill.color = new Color(0f, 1f, 0f, 1);
        }

        healthText.text = $"{Mathf.Round(player.currentHP)} / {Mathf.Round(player.maxHP)}";
    }
    
    public void SetSize(float a, float b)
    {
        healthSlider.value = a / b;
    }
    
    public void SetHealthText(float currentHealth, float maxHealth)
    {
        healthText.text = $"{currentHealth} / {maxHealth}";
    }
}
