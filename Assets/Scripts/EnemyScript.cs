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
    public float damage;
    private Rigidbody2D _rb;
    public float attackRate;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        attackRate = 1 / attackRate;
        currentHP = maxHP;
        ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = Vector2.zero;
        timer += Time.deltaTime;
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
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject collider = GameObject.Find(collision.gameObject.name);
        if (collider.CompareTag("Player"))
        {
            while (timer > attackRate)
            {
                collider.GetComponent<PlayerScript>().DealDamage(damage);
                timer = 0;
            }
        }
    }
    
}
