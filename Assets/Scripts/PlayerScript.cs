﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public float maxHP;
    private float currentHP;
    public HealthBar healthBar;
    private Rigidbody2D rb;
    public Animator animator;
    public int gold;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        if (x > 0)
        {
            MoveLeft();
            animator.SetFloat("Speed", Mathf.Abs(x));
            
        }
        
        if (x < 0)
        {
            MoveRight();
            animator.SetFloat("Speed", Mathf.Abs(x));
        }
        
        if (y > 0)
        {
            MoveUp();
            animator.SetFloat("Speed", Mathf.Abs(y));
        }
        
        if (y < 0)
        {
            MoveDown();
            animator.SetFloat("Speed", Mathf.Abs(y));
        }

        if (x == 0)
        {
            animator.SetFloat("Speed", 0);
        }
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -17.3f, 17.3f);
        pos.y = Mathf.Clamp(pos.y, -9, 6);
        transform.position = pos;
        
    }

    void MoveLeft()
    {
        transform.Translate(speed*Time.deltaTime, 0, 0);
        gameObject.GetComponent<SpriteRenderer>().flipX = false;
    }
    
    void MoveRight()
    {
        transform.Translate(-speed*Time.deltaTime, 0, 0);
        gameObject.GetComponent<SpriteRenderer>().flipX = true;
    }
    
    void MoveUp()
    {
        transform.Translate(0, speed*Time.deltaTime, 0);
    }
    
    void MoveDown()
    {
        transform.Translate(0, -speed*Time.deltaTime, 0);
    }

    public void DealDamage(float damage)
    {
        currentHP -= damage;
        healthBar.SetSize(currentHP/maxHP);
        if (currentHP < 0)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collider = GameObject.Find(collision.gameObject.name);
        if (collider.CompareTag("Enemy"))
        {
            float damage = collider.GetComponent<EnemyScript>().damage;
            DealDamage(damage);
            AIScriptRB2D enemy = collision.gameObject.GetComponent<AIScriptRB2D>();
            //StartCoroutine(enemy.Knockback(200, 1, gameObject.transform.position));
        }
    }
}
