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
    public float exp;
    public PlayerScript player;
    public GameObject onHitParticle;
    public GameObject onDeathParticle;
    public float knockbackResistance;
    public bool isKnockbackable;
    public Animator animator;
    private static readonly int IsDead = Animator.StringToHash("isDead");
    private static readonly int Hit = Animator.StringToHash("hit");
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        attackRate = 1 / attackRate;
        currentHP = maxHP;
        ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        _rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = Vector2.zero;
        timer += Time.deltaTime;
        if (timer > 0.15)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public void TakeDamage(float damageTaken)
    {
        currentHP -= damageTaken;
        if (currentHP < 1)
        {
            healthBar.SetSize(0/maxHP);
            animator.SetBool(IsDead, true);
            
            //Instantiate(onDeathParticle, transform.position, Quaternion.identity);
            ui.AddGold(goldWorth);
            player.AddExp(exp);
        }
        else
        {
            healthBar.SetSize(currentHP/maxHP);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collider = GameObject.Find(collision.gameObject.name);
        if (collider.CompareTag("SpellProjectile"))
        {
            //Instantiate(onHitParticle, transform.position, Quaternion.identity);
            float damageDealt = collider.GetComponent<SpellScript>().damage;
            animator.SetTrigger(Hit);
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            timer = 0;
            TakeDamage(damageDealt);
            if (isKnockbackable)
            {
                var thisPosition = transform.position;
                var moveDirection = player.transform.position - thisPosition;
                transform.position = Vector3.Lerp(thisPosition, 1/knockbackResistance * collider.GetComponent<SpellScript>().knockbackPower*-moveDirection, .1f);
            }
        }
    }

    public void DealDamage()
    {
        player.currentHP -= damage;
        player.healthBar.SetSize(currentHP, maxHP);
        if (player.currentHP < 0)
        {
            Destroy(player);
        }
    }

    public void DestroyYourself()
    {
        Destroy(gameObject);
    }
    
}
