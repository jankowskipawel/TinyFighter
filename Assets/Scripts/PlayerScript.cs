using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditorInternal;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public float maxHP;
    public float currentHP;
    public HealthBar healthBar;
    private Rigidbody2D rb;
    public Animator animator;
    public int gold;
    private float healthPrecentage;
    public float healthRegen;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        rb = GetComponent<Rigidbody2D>();
        healthBar.SetSize(1);
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

        healthPrecentage = currentHP / maxHP;
        currentHP += healthRegen * Time.deltaTime;
        healthBar.SetSize(healthPrecentage);
    }

    public void DealDamage(float damage)
    {
        currentHP -= damage;
        healthBar.SetSize(healthPrecentage);
        if (currentHP < 0)
        {
            Destroy(gameObject);
        }
    }
}
