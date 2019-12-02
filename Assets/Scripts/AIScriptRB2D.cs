using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AIScriptRB2D : MonoBehaviour
{
    public Transform player;
    public float moveSpeed;
    public SpriteRenderer sr;
    private Vector2 _movement;
    public Animator animator;
    public Rigidbody2D rb;
    private bool isColided;
    
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int IsAttacking = Animator.StringToHash("isAttacking");

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        _movement = direction;
        
        if (player.transform.position.x > transform.position.x)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }
        
        MoveCharacter(_movement);
    }

    void MoveCharacter(Vector2 direction)
    {
        var position = transform.position;
        var playerPosition = player.position;
        var distanceX = Math.Abs(playerPosition.x - position.x);
        var distanceY = playerPosition.y - position.y;
        if (!isColided)
        {
            animator.SetFloat(Speed, 1);
            position = Vector2.Lerp(position,
                (Vector2) position + (Time.deltaTime * moveSpeed * direction), Time.time);
            transform.position = position;
        }
        else
        {
            animator.SetFloat(Speed, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isColided = true;
            animator.SetFloat(IsAttacking, 1);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isColided = false;
            animator.SetFloat(IsAttacking, 0);
        }
    }
}
