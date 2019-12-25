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
    public Text projectileSpeedText;

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
        damageText.text = $"Damage: {towerScript.GetDamage()}";
        attackSpeedText.text = $"Attack Speed: {towerScript.attackRate}";
        rangeText.text = $"Rage: {Math.Round(towerScript.towerRange-59, 3)}";
        projectileSpeedText.text = $"Projectile Speed: {towerScript.spellSpeed}";
    }
}
