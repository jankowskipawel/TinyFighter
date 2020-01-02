using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour
{
    public float knockbackPower;
    public float damage;
    public GameObject shotParticle;

    private float timer;
    public GameObject trailParticle;
    public float spellSpeed;
    public float travelTime;
    public Animator animator;
    private static readonly int IsDestroyed = Animator.StringToHash("isDestroyed");

    // Start is called before the first frame update
    void Start()
    {
        //GameObject x =  Instantiate(shotParticle, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject x = Instantiate(trailParticle, transform.position, Quaternion.identity);
        //x.transform.parent = gameObject.transform;
        if (timer > travelTime)
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            gameObject.GetComponent<BoxCollider2D>().size = Vector2.zero;
            animator.SetBool(IsDestroyed, true);
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("MapCollision"))
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            gameObject.GetComponent<BoxCollider2D>().size = Vector2.zero;
            animator.SetBool(IsDestroyed, true);
        }
    }

    public void DestroyYourself()
    {
        Destroy(gameObject);
    }

    
}
