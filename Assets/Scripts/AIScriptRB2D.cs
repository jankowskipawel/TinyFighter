using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AIScriptRB2D : MonoBehaviour
{
    public Transform player;
    public float moveSpeed;
    private Rigidbody2D _rb;
    public SpriteRenderer sr;
    private Vector2 _movement;
    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        _movement = direction;
        
        if (player.transform.position.x > transform.position.x)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        MoveCharacter(_movement);
    }

    void MoveCharacter(Vector2 direction)
    {
        _rb.MovePosition((Vector2)transform.position + (Time.deltaTime * moveSpeed * direction));
    }
}
