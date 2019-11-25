using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool knockBack;
    public float thrust;
    // Use this for initialization
    void Start () {
        rb = this.GetComponent<Rigidbody2D> ();
    }
	
    // Update is called once per frame
    void Update () {
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collider = GameObject.Find(collision.gameObject.name);
        if (collider.CompareTag("Player"))
        {
            if (knockBack) {
                knockBack = !knockBack;
                rb.AddForce (transform.right * thrust);
            }
        }
    }
}
