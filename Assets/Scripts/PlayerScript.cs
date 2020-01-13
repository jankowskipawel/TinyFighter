using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public Image expBarFill;
    private Rigidbody2D rb;
    public Animator animator;
    public float currentExp = 0;
    public float maxExp = 2;
    private int level = 1;
    public int skillPoints;
    private static readonly int IsDead = Animator.StringToHash("isDead");
    private static readonly int Speed = Animator.StringToHash("Speed");
    public Text levelText;
    public GameObject levelUpAnimation;
    private bool isGameOver = false;
    private float bonusDamage = 0;



    // Start is called before the first frame update
    void Start()
    {
        SetLevelText(level);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            Vector3 tempVect = new Vector3(h, v, 0);
            tempVect = Time.deltaTime * speed * tempVect.normalized;
            rb.MovePosition(rb.transform.position + tempVect);
        
            if (h > 0)
            {
                animator.SetFloat(Speed, 1);
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        
            if (h < 0)
            {
                animator.SetFloat(Speed, 1);
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        
            if (v > 0)
            {
                animator.SetFloat(Speed, 1);
            }
        
            if (v < 0)
            {
                animator.SetFloat(Speed, 1);
            }

            if (h == 0 && v == 0)
            {
                animator.SetFloat(Speed, 0);
            }
        }
    }

    public void AddExp(float exp)
    {
        if (currentExp + exp >= maxExp)
        {
            var g = Instantiate(levelUpAnimation, transform.position, Quaternion.identity);
            g.transform.parent = gameObject.transform;
            currentExp += exp;
            currentExp -= maxExp;
            level++;
            SetLevelText(level);
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
        expBarFill.fillAmount = percentage;
    }

    public void SetLevelText(int level)
    {
        levelText.text = $"Level\n{level}";
    }

    public void SetGameOver(bool x)
    {
        isGameOver = x;
    }

    public bool GetGameOver()
    {
        return isGameOver;
    }

    public void AddDamage(float amount)
    {
        bonusDamage += amount;
    }

    public float GetBonusDamage()
    {
        return bonusDamage;
    }
}
