using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsButtonsScript : MonoBehaviour
{
    private PlayerScript playerScript;
    
    private int attackLevel = 0;
    public Text attackText;
    
    private int movementSpeedLevel = 0;
    public Text movementSpeedText;
    
    // Start is called before the first frame update
    void Start()
    {
        playerScript = FindObjectOfType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPlayerDamage()
    {
        if (playerScript.skillPoints > 0)
        {
            playerScript.AddDamage(10);
            playerScript.skillPoints--;
            attackLevel++;
            attackText.text = attackLevel.ToString();
        }
    }

    public void IncreaseMovementSpeed()
    {
        if (playerScript.skillPoints > 9 && movementSpeedLevel < 3)
        {
            playerScript.IncreaseSpeed();
            playerScript.skillPoints -= 10;
            movementSpeedLevel++;
            if (movementSpeedLevel == 3)
            {
                movementSpeedText.text = "MAX";
            }
            else
            {
                movementSpeedText.text += " I ";
            }
        }
    }
}
