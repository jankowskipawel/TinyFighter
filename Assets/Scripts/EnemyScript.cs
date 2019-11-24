using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float maxHP;
    private float currentHP;
    public int goldWorth;
    public UIManager ui;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageTaken)
    {
        currentHP -= damageTaken;
        if (currentHP < 1)
        {
            Destroy(gameObject);
            ui.AddGold(goldWorth);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject bullet = GameObject.Find(collision.gameObject.name);
        if (bullet.name.Substring(0, 5) == "Bulle")
        {
            float damageDealt = bullet.GetComponent<BulletScript>().damage;
            TakeDamage(damageDealt);
        }
    }
}
