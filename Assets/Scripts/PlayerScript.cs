﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public float maxHP;
    public float currentHP;
    public HealthBarPlayerS healthBar;
    public Slider expBar;
    private Rigidbody2D rb;
    public Animator animator;
    public int gold;
    private float healthPrecentage;
    public float healthRegen;
    public float currentExp = 0;
    public float maxExp = 2;
    private int level;
    public int skillPoints;
    private static readonly int IsDead = Animator.StringToHash("isDead");


    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = Time.deltaTime * speed * tempVect.normalized;
        rb.MovePosition(rb.transform.position + tempVect);
        
        if (h > 0)
        {
            animator.SetFloat("Speed", Mathf.Abs(h));
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        
        if (h < 0)
        {
            animator.SetFloat("Speed", Mathf.Abs(h));
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        
        if (v > 0)
        {
            animator.SetFloat("Speed", Mathf.Abs(v));
        }
        
        if (v < 0)
        {
            animator.SetFloat("Speed", Mathf.Abs(v));
        }

        if (h == 0)
        {
            animator.SetFloat("Speed", 0);
        }
        if (currentHP <= maxHP)
        {
            currentHP += healthRegen * Time.deltaTime;
        }
        healthBar.SetSize(currentHP, maxHP);
    }

    public void AddExp(float exp)
    {
        if (currentExp + exp >= maxExp)
        {
            currentExp += exp;
            currentExp -= maxExp;
            level++;
            skillPoints++;
            maxExp *= 2;
        }
        else
        {
            currentExp += exp;
        }
        SetExpBar(currentExp/maxExp);
    }

    private void SetExpBar(float percentage)
    {
        expBar.value = percentage;
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
