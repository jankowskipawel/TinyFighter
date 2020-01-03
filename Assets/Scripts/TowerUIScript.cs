using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUIScript : MonoBehaviour
{
    public Text damageText;
    public Text attackSpeedText;
    public Text rangeText;
    public Text sellPriceText;

    public TowerScript towerScript;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateText()
    {
        var damageTmp = towerScript.GetDamage();
        damageText.text = $"Damage: {damageTmp-damageTmp/2} - {damageTmp+damageTmp/2}";
        attackSpeedText.text = $"Attack Speed: {Math.Round(1/towerScript.attackRate, 2)}/SEC";
        rangeText.text = $"Range: {Math.Round(towerScript.towerRange-59, 3)}";
        sellPriceText.text = $"Sells for: {towerScript.GetTowerWorth()/2}";
    }
}
