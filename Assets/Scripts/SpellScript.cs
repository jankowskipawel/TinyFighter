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
            Destroy(gameObject);
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
