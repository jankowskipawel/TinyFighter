using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public TowerScript towerScript;

    public UIManager UI;

    private float timer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("CanvasUI").GetComponent<UIManager>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.2f)
        {
            gameObject.GetComponent<Image>().color = Color.white;
        }
    }

    public void AddRange()
    {
        if (UI.gold >= towerScript.GetUpgradeCost() && !towerScript.IsMaxRange())
        {
            UI.gold -= towerScript.GetUpgradeCost();
            towerScript.IncreaseRange();
            UI.RefreshGoldAmount();
        }
        else
        {
            gameObject.GetComponent<Image>().color = Color.red;
            timer = 0;
        }
    }
    
    public void AddDamage()
    {
        if (UI.gold >= towerScript.GetUpgradeCost())
        {
            UI.gold -= towerScript.GetUpgradeCost();
            towerScript.IncreaseDamage();
            UI.RefreshGoldAmount();
        }
        else
        {
            gameObject.GetComponent<Image>().color = Color.red;
            timer = 0;
        }
    }

    public void AddAttackSpeed()
    {
        if (UI.gold >= towerScript.GetUpgradeCost() && towerScript.attackRate >= 0.11f)
        {
            UI.gold -= towerScript.GetUpgradeCost();
            towerScript.IncreaseAttackSpeed();
            UI.RefreshGoldAmount();
        }
        else
        {
            gameObject.GetComponent<Image>().color = Color.red;
            timer = 0;
        }
    }
}
