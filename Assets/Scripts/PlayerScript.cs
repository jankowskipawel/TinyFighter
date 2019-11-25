using System;
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
