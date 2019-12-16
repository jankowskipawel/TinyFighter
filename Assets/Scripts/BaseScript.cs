using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    public float maxHP;
    public float currentHP;
    public HealthBarPlayerS healthBar;
    private float healthPrecentage;
    public float healthRegen;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP <= maxHP)
        {
            currentHP += healthRegen * Time.deltaTime;
        }
        healthBar.SetSize(currentHP, maxHP);
    }
}
