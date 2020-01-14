using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsButtonsScript : MonoBehaviour
{
    private PlayerScript _playerScript;
    private BaseScript _baseScript;
    
    private int attackLevel = 0;
    public Text attackText;
    
    private int movementSpeedLevel = 0;
    public Text movementSpeedText;
    
    private int HPLevel = 0;
    public Text HPText;
    
    private int HPRegenLevel = 0;
    public Text HPRegenText;
    
    private int rangeLevel = 0;
    public Text rangeText;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerScript = FindObjectOfType<PlayerScript>();
        _baseScript = FindObjectOfType<BaseScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPlayerDamage()
    {
        if (_playerScript.skillPoints > 0)
        {
            _playerScript.AddDamage(10);
            _playerScript.skillPoints--;
            attackLevel++;
            attackText.text = attackLevel.ToString();
        }
    }

    public void IncreaseMovementSpeed()
    {
        if (_playerScript.skillPoints > 9 && movementSpeedLevel < 3)
        {
            _playerScript.IncreaseSpeed();
            _playerScript.skillPoints -= 10;
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

    public void IncreaseBaseHP()
    {
        if (_playerScript.skillPoints > 0)
        {
            _baseScript.IncreaseHP(10);
            _playerScript.skillPoints -= 1;
            HPLevel++;
            HPText.text = HPLevel.ToString();
        }
    }
    
    public void IncreaseBaseHPRegen()
    {
        if (_playerScript.skillPoints > 1)
        {
            _baseScript.IncreaseHPRegen(1);
            _playerScript.skillPoints -= 2;
            HPRegenLevel++;
            HPRegenText.text = HPRegenLevel.ToString();
        }
    }

    public void IncreaseRange()
    {
        if (_playerScript.skillPoints > 1 && rangeLevel < 10)
        {
            _playerScript.IncreaseBonusRange(0.1f);
            _playerScript.skillPoints -= 2;
            rangeLevel++;
            if (rangeLevel == 10)
            {
                rangeText.text = "MAX";
            }
            else
            {
                rangeText.text = rangeLevel.ToString();
            }
        }
    }
}
