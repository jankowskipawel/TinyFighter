using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float knockbackPower;
    public float damage;
    public GameObject shotParticle;

    private float timer;

    public GameObject trailParticle;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(shotParticle, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(trailParticle, transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Border") || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
