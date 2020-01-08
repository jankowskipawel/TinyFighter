using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public BaseScript baseScript;
    public float damage;
    private static readonly int Hit = Animator.StringToHash("hit");

    // Start is called before the first frame update
    void Start()
    {
        baseScript = GameObject.Find("Base").GetComponent<BaseScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Base"))
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            baseScript.currentHP -= damage;
            gameObject.GetComponent<BoxCollider2D>().size = Vector2.zero;
            gameObject.GetComponent<Animator>().SetTrigger(Hit);
            if (baseScript.currentHP <= 0)
            {
                baseScript.currentHP = 0;
                FindObjectOfType<GameHandler>().GameOver();
            }
        }
    }

    public void DestroyYourself()
    {
        Destroy(gameObject);
    }
}
