using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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
    public GameObject pfDamagePopup;
    private bool isCritical = false;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject x =  Instantiate(shotParticle, transform.position, Quaternion.identity);
        damage += Random.Range(-damage/2, damage/2);
        damage = Mathf.RoundToInt(damage);
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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var x = Instantiate(pfDamagePopup, transform.position, Quaternion.identity);
            if (isCritical)
            {
                x.GetComponent<TextMeshPro>().color = new Color(1f, 0.27f, 0.27f);
            }
            x.GetComponent<DamagePopupScript>().SetText(damage);
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            gameObject.GetComponent<BoxCollider2D>().size = Vector2.zero;
            animator.SetBool(IsDestroyed, true);
        }

        if (collision.gameObject.CompareTag("MapCollision"))
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

    public void SetIsCritical(bool x)
    {
        isCritical = x;
    }
}
