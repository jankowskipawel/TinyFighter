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
    public HealthBar healthBar;
    private PlayerScript _player;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        _player = gameObject.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageTaken)
    {
        currentHP -= damageTaken;
        healthBar.SetSize(currentHP/maxHP);
        if (currentHP < 1)
        {
            Destroy(gameObject);
            ui.AddGold(goldWorth);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collider = GameObject.Find(collision.gameObject.name);
        if (collider.name.Substring(0, 1) == "B")
        {
            float damageDealt = collider.GetComponent<BulletScript>().damage;
            TakeDamage(damageDealt);
        }
    }
}
