using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public GameObject attackPrefab;

    public float spellSpeed;

    public float attackRate;

    private float timer = 0;

    private GameObject[] enemiesInRange;

    public float towerRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > attackRate)
        {
            enemiesInRange = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemiesInRange.Length > 0)
            {
                foreach (var enemy in enemiesInRange)
                {
                    if (Vector3.Distance(transform.position, enemy.transform.position) < towerRange)
                    {
                        Attack(enemy.transform.position);
                        break;
                    }
                }
            }
            timer = 0;
        }
    }

    public void Attack(Vector3 targetPos)
    {
        GameObject b = Instantiate(attackPrefab) as GameObject;
        var position = transform.position;
        Vector3 difference = targetPos - position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        b.transform.position = position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ+90);
        float distance = difference.magnitude;
        Vector2 direction = difference / distance;
        direction.Normalize();
        b.GetComponent<Rigidbody2D>().velocity = direction * spellSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
    }
}
