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
    public BaseScript baseScript;
    public GameObject baseObject;
    public GameObject onHitParticle;
    public GameObject onDeathParticle;
    public float knockbackResistance;
    public bool isKnockbackable;
    public Animator animator;
    private static readonly int IsDead = Animator.StringToHash("isDead");
    private static readonly int Hit = Animator.StringToHash("hit");
    private float timer;
    public GameObject attackProjectile;

    // Start is called before the first frame update
    void Start()
    {
        attackRate = 1 / attackRate;
        currentHP = maxHP;
        ui = GameObject.Find("CanvasUI").GetComponent<UIManager>();
        _rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
        baseObject = GameObject.Find("Base");
        baseScript = baseObject.GetComponent<BaseScript>();
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
            gameObject.layer = 10;
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
        baseScript.currentHP -= damage;
        /*if (baseScript.currentHP < 0)
        {
            //player.animator.SetBool(IsDead, true);
        }*/
    }
    
    public void DestroyYourself()
    {
        ui.AddGold(goldWorth);
        Destroy(gameObject);
    }

    public void RemoveColission()
    {
        GameObject o = gameObject;
        o.GetComponent<BoxCollider2D>().size = Vector2.zero;
        o.tag = "Untagged";
        player.AddExp(exp);
    }

    public void RangeAttack()
    {
        GameObject b = Instantiate(attackProjectile);
        var position = transform.position;
        Vector3 difference = baseObject.transform.position - position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        b.transform.position = position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        float distance = difference.magnitude;
        Vector2 direction = difference / distance;
        direction.Normalize();
        b.GetComponent<Rigidbody2D>().velocity = direction * 10;
    }
}
